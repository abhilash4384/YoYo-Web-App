using System;

namespace YoYo_Web_App.Models
{
    public class FintessRatingModel
    {
        public int AccumulatedShuttleDistance { get; set; }
        public int SpeedLevel { get; set; }

        public int ShuttleNo { get; set; }

        public int Speed { get; set; }

        public float LevelTime { get; set; }

        public string CommulativeTime { get; set; }

        public string StartTime { get; set; }

        public string ApproxVo2Max { get; set; }
    }
}
