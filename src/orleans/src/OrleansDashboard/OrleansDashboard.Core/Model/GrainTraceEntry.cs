﻿using System;

namespace OrleansDashboard.Model
{
    [Serializable]
    public class GrainTraceEntry
    {
        public string PeriodKey { get; set; }
        public DateTime Period { get; set; }
        public string SiloAddress { get; set; }
        public string Grain { get; set; }
        public string Method { get; set; }
        public long Count { get; set; }
        public long ExceptionCount { get; set; }
        public double ElapsedTime { get; set; }
    }
}