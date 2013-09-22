// -----------------------------------------------------------------------
// <copyright file="Range.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace FizzBuzz
{
    public class Range
    {
        public int Start { get; set; }

        public int End { get; set; }

        public int Count
        {
            get
            {
                return (this.End - this.Start) + 1;
            }
        }

        public Range(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}