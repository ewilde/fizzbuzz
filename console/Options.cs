// -----------------------------------------------------------------------
// <copyright file="Options.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace console
{
    using CommandLine;
    using CommandLine.Text;

    public class Options
    {
        [Option('s', DefaultValue = 1, HelpText = "Start of range")]
        public int Start { get; set; }

        [Option('e', DefaultValue = 20, HelpText = "End of range")]
        public int End { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}