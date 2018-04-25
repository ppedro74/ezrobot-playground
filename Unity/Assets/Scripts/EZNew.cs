namespace BioIK
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design.Serialization;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using EZ_B;
    using UnityEngine;
    using Debug = UnityEngine.Debug;

    public class EZNew : MonoBehaviour
    {
        //Head Horizontal: D0
        //Head Vertical: D1 / Min:70

        //Left Shoulder: D3
        //Left Upper Arm : D4
        //Left Forearm: D5
        //Left Gripper: D6 / Min:30 / Max:90
        //Left Upper Leg: D12
        //Left Knee: D13 
        //Left Ankle: D14 / Min:60 / Max:120

        //Right Shoulder: D2
        //Right Upper Arm : D7
        //Right Forearm: D8
        //Right Gripper: D9  / Min:30 / Max:90
        //Right Upper Leg: D16
        //Right Foot Knee: D17
        //Right Foot Ankle: D18 / Min:60 / Max: 120

        private static readonly ServoDefinition[] ServoDefinitions = new ServoDefinition[]
        {
            //DEFINE YOUR SERVOS HERE
            //Start with one only, but you can assign RotNew to all Joints

            new ServoDefinition("Head_Rotate", AxisType.Y, Servo.ServoPortEnum.D0),
            new ServoDefinition("Neck_Up_Down", AxisType.X, Servo.ServoPortEnum.D1, false, 70),

            new ServoDefinition("Left_Shoulder", AxisType.X, Servo.ServoPortEnum.D3),
            new ServoDefinition("Left_Upper_Arm", AxisType.Y, Servo.ServoPortEnum.D4),
            new ServoDefinition("Left_Lower_Arm", AxisType.Y, Servo.ServoPortEnum.D5),

            new ServoDefinition("Right_Shoulder", AxisType.X, Servo.ServoPortEnum.D2),
            new ServoDefinition("Right_Upper_Arm", AxisType.Y, Servo.ServoPortEnum.D7),
            new ServoDefinition("Right_Lower_Arm", AxisType.Y, Servo.ServoPortEnum.D8),
        };

        private int fps;
        private Stopwatch fpsStopwatch = new Stopwatch();
        private int frameCount;
        private Stopwatch servoStopwatch = new Stopwatch();
        private bool isFirstUpdate;

        private static void OnEzbConnect()
        {
            if (ServoDefinitions.Length == 0)
            {
                return;
            }

            //SET ALL SERVOS TO POSITION 90

            const int defaultPosition = 90;
            var servosToMove = ServoDefinitions
                .Select(s => new EZ_B.Classes.ServoPositionItem(s.Port, defaultPosition))
                .ToArray();

            EzbController.Instance.SetServosPositions(servosToMove);
        }

        private void Start()
        {
            this.isFirstUpdate = true;
            Debug.Log(string.Format("Start [{0}]", this.name));
            EzbController.Instance.Connect("192.168.18.60:23");
            this.fpsStopwatch.Start();
            this.servoStopwatch.Start();
        }

        private void OnApplicationQuit()
        {
            EzbController.Instance.Disconnect();
        }

        private void Update()
        {
            //time between updates
            const int intervalMilliseconds = 500;

            //measure the fps only for debug/info purpose 
            this.MeasureFramesPerSecond();

            if (this.isFirstUpdate)
            {
                this.isFirstUpdate = false;
            }
            else
            {
                if (this.servoStopwatch.ElapsedMilliseconds < intervalMilliseconds)
                {
                    //Not yet
                    return;
                }
            }

            //*** TIME TO UPDATE ***

            //reset the clock
            this.servoStopwatch = Stopwatch.StartNew();

            var joint = this.GetComponent<BioJoint>();

            var rotation = new int[]
            {
                Mathf.RoundToInt((float)joint.X.GetTargetValue()),
                Mathf.RoundToInt((float)joint.Y.GetTargetValue()),
                Mathf.RoundToInt((float)joint.Z.GetTargetValue()),
            };

            this.SendServosPositions(rotation);
        }

        private void MeasureFramesPerSecond()
        {
            this.frameCount++;
            if (this.fpsStopwatch.ElapsedMilliseconds >= 1000)
            {
                this.fps = this.frameCount;
                this.frameCount = 0;
                //this.fpsStopwatch.Restart();
                this.fpsStopwatch = Stopwatch.StartNew();
            }
        }

        private bool IsTimeToRun()
        {
            //Note: Start with a conservative value here
            //a high value slows down.
            const int interval = 30;
            return (Time.frameCount % interval) == 0;
        }


        private void SendServosPositions(int[] rotation)
        {
            var debugInfo = new StringBuilder();
            debugInfo.AppendFormat("fps=[{0} j=[{1}]", this.fps, this.name);

            var servosToMove = new List<EZ_B.Classes.ServoPositionItem>();
            var jointServos = ServoDefinitions.Where(js => js.JointName.Equals(this.name, StringComparison.OrdinalIgnoreCase)).ToArray();

            debugInfo.AppendFormat(" X=[{0}:{1}]", FixRotation(rotation[0], false), rotation[0]);
            foreach (var servoDefinition in jointServos.Where(s => s.Axis == AxisType.X))
            {
                servosToMove.Add(new EZ_B.Classes.ServoPositionItem(servoDefinition.Port, servoDefinition.AdjustValue(rotation[0])));
            }

            debugInfo.AppendFormat(" Y=[{0}:{1}]", FixRotation(rotation[1], false), rotation[1]);
            foreach (var servoDefinition in jointServos.Where(s => s.Axis == AxisType.Y))
            {
                servosToMove.Add(new EZ_B.Classes.ServoPositionItem(servoDefinition.Port, servoDefinition.AdjustValue(rotation[1])));
            }

            debugInfo.AppendFormat(" Z=[{0}:{1}]", FixRotation(rotation[2], false), rotation[2]);
            foreach (var servoDefinition in jointServos.Where(s => s.Axis == AxisType.Z))
            {
                servosToMove.Add(new EZ_B.Classes.ServoPositionItem(servoDefinition.Port, servoDefinition.AdjustValue(rotation[2])));
            }

            if (servosToMove.Count > 0)
            {
                debugInfo.AppendFormat(" Servos=[{0}]", string.Join("; ", servosToMove.Select(s => s.Port)));
                Debug.Log(debugInfo.ToString());

                EzbController.Instance.SetServosPositions(servosToMove.ToArray());
            }
        }








        private static int FixRotation(int deg, bool inverted, int middleAngle = 90)
        {
            return !inverted ? middleAngle + deg : middleAngle * 2 - (middleAngle + deg);
        }

        private enum AxisType
        {
            X = 0,
            Y = 1,
            Z = 2
        }

        private class EzbController
        {
            private readonly EZB ezb;
            private readonly object lockObject = new object();
            private bool isConnected;

            private EzbController()
            {
                this.ezb = new EZB("MyEzb");
                this.ezb.OnConnectionChange += this.EzbOnConnectionChange;
            }

            public static EzbController Instance
            {
                get { return Creator.Singleton; }
            }

            public void Connect(string hostname)
            {
                lock (this.lockObject)
                {
                    if (!this.ezb.IsConnected)
                    {
                        Debug.Log("Connecting to EZB hostname:" + hostname);
                        this.ezb.Connect(hostname);
                    }
                }
            }

            public void Disconnect()
            {
                lock (this.lockObject)
                {
                    if (this.ezb.IsConnected)
                    {
                        this.ezb.Servo.ReleaseAllServos();
                        this.ezb.Disconnect();
                    }
                }
            }

            public void SetServoPosition(Servo.ServoPortEnum servoPort, int position)
            {
                if (!this.ezb.IsConnected)
                {
                    Debug.LogWarning("EZB is not connected, SetServoPosition will be ignored");
                    return;
                }

                try
                {
                    this.ezb.Servo.SetServoPosition(servoPort, position);
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex);
                }
            }

            public void SetServosPositions(EZ_B.Classes.ServoPositionItem[] servoPositionItems)
            {
                if (!this.ezb.IsConnected)
                {
                    Debug.LogWarning("EZB is not connected, SetServosPositions will be ignored");
                    return;
                }

                try
                {
                    this.ezb.Servo.SetServoPosition(servoPositionItems);
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex);
                }
            }

            private void EzbOnConnectionChange(bool connectionState)
            {
                lock (this.lockObject)
                {
                    Debug.Log("EZB connection changed to: " + (connectionState ? "Connected" : "Disconnect"));
                    if (!this.isConnected && connectionState)
                    {
                        OnEzbConnect();
                    }

                    this.isConnected = connectionState;
                }
            }

            private sealed class Creator
            {
                private static readonly EzbController Instance = new EzbController();

                internal static EzbController Singleton
                {
                    get { return Instance; }
                }
            }
        }

        private class ServoDefinition
        {
            public readonly string JointName;
            public readonly AxisType Axis;
            public readonly Servo.ServoPortEnum Port;
            private readonly bool inverted;
            private readonly int minValue;
            private readonly int maxValue;
            private readonly int middleValue;

            public ServoDefinition(string jointName, AxisType axis, Servo.ServoPortEnum port, bool inverted = false, int minValue = 1, int maxValue = 180, int middleValue = 90)
            {
                this.Port = port;
                this.JointName = jointName;
                this.Axis = axis;
                this.inverted = inverted;
                this.minValue = minValue;
                this.maxValue = maxValue;
                this.middleValue = middleValue;
            }

            private int ClampValue(int degrees)
            {
                return degrees < this.minValue ? this.minValue : degrees > this.maxValue ? this.maxValue : degrees;
            }

            public int AdjustValue(int degrees)
            {
                var servoValue = FixRotation(degrees, this.inverted, this.middleValue);
                var clampedValue = this.ClampValue(servoValue);
                return clampedValue;
            }
        }
    }
}