namespace NVerilogParser.Preprocessor.Directives
{
    public class Timescale : Directive
    {
        string TimeUnit { get; set; }

        string TimePrecision { get; set; }
    }
}
