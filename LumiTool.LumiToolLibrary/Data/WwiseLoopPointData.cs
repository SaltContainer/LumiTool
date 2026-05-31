namespace LumiTool.Data
{
    public class WwiseLoopPointData
    {
        public double InitialDelay { get; set; }
        public double LoopStart { get; set; }
        public double LoopEnd { get; set; }
        public double TotalSourceLength { get; set; }

        public double PlayAt => PlayAtFunc();
        public double BeginTrimOffset => BeginTrimOffsetFunc();
        public double EndTrimOffset => EndTrimOffsetFunc();
        public double SrcDuration => SrcDurationFunc();
        public double SegmentDuration => SegmentDurationFunc();
        public double SegmentArrayMarkerPosition => SegmentArrayMarkerPositionFunc();

        private Func<double> PlayAtFunc { get; set; }
        private Func<double> BeginTrimOffsetFunc { get; set; }
        private Func<double> EndTrimOffsetFunc { get; set; }
        private Func<double> SrcDurationFunc { get; set; }
        private Func<double> SegmentDurationFunc { get; set; }
        private Func<double> SegmentArrayMarkerPositionFunc { get; set; }

        // Math for Intro Section
        private double PlayAtIntro() => -InitialDelay;
        private double BeginTrimOffsetIntro() => InitialDelay;
        private double EndTrimOffsetIntro() => (TotalSourceLength == LoopStart) ? TotalSourceLength : -(TotalSourceLength - LoopStart);
        private double SrcDurationIntro() => TotalSourceLength;
        private double SegmentDurationIntro() => LoopStart - InitialDelay;
        private double SegmentArrayMarkerPositionIntro() => LoopStart - InitialDelay;

        // Math for Looping Section
        private double PlayAtLoop() => -LoopStart;
        private double BeginTrimOffsetLoop() => LoopStart;
        private double EndTrimOffsetLoop() => (TotalSourceLength == LoopEnd) ? TotalSourceLength : - (TotalSourceLength - LoopEnd);
        private double SrcDurationLoop() => TotalSourceLength;
        private double SegmentDurationLoop() => LoopEnd - LoopStart;
        private double SegmentArrayMarkerPositionLoop() => LoopEnd - LoopStart;

        public WwiseLoopPointData CloneForIntro()
        {
            var clone = new WwiseLoopPointData()
            {
                InitialDelay = InitialDelay,
                LoopStart = LoopStart,
                LoopEnd = LoopEnd,
                TotalSourceLength = TotalSourceLength,
            };

            clone.SetFuncsForIntro();

            return clone;
        }

        public WwiseLoopPointData CloneForLoop()
        {
            var clone = new WwiseLoopPointData()
            {
                InitialDelay = InitialDelay,
                LoopStart = LoopStart,
                LoopEnd = LoopEnd,
                TotalSourceLength = TotalSourceLength,
            };

            clone.SetFuncsForLoop();

            return clone;
        }

        public void SetFuncsForIntro()
        {
            PlayAtFunc = PlayAtIntro;
            BeginTrimOffsetFunc = BeginTrimOffsetIntro;
            EndTrimOffsetFunc = EndTrimOffsetIntro;
            SrcDurationFunc = SrcDurationIntro;
            SegmentDurationFunc = SegmentDurationIntro;
            SegmentArrayMarkerPositionFunc = SegmentArrayMarkerPositionIntro;
        }

        public void SetFuncsForLoop()
        {
            PlayAtFunc = PlayAtLoop;
            BeginTrimOffsetFunc = BeginTrimOffsetLoop;
            EndTrimOffsetFunc = EndTrimOffsetLoop;
            SrcDurationFunc = SrcDurationLoop;
            SegmentDurationFunc = SegmentDurationLoop;
            SegmentArrayMarkerPositionFunc = SegmentArrayMarkerPositionLoop;
        }
    }
}
