namespace NVerilogParser.Preprocessor.Directives
{
    public class Timescale : Directive
    {
        public int TimeUnit { get; set; }

        public string TimeUnitScaleFactor { get; set; }

        public int TimePrecision { get; set; }

        public string TimePrecisionScaleFactor { get; set; }
    }
}
