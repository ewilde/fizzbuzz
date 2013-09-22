// -----------------------------------------------------------------------
// <copyright file="LuckyEngine.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace FizzBuzz
{
    using System.Globalization;

    public class LuckyEngine : Engine
    {
        public const string Lucky = "lucky";

        public LuckyEngine()
        {
        }

        public LuckyEngine(Range range) : base(range)
        {
        }

        protected override string GetItem(int index)
        {
            if (index.ToString(CultureInfo.InvariantCulture).Contains("3"))
            {
                this.UpdateStatisticForWord(Lucky);
                return Lucky;
            }

            return base.GetItem(index);
        }
    }
}