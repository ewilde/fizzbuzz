// -----------------------------------------------------------------------
// <copyright file="Engine.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace FizzBuzz
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// A fizz buzz engine.
    /// </summary>
    public class Engine
    {
        private readonly Dictionary<string, int> statistics;

        public const string Fizzbuzz = "fizzbuzz";

        public const string Fizz = "fizz";

        public const string Buzz = "buzz";

        public Engine() : this(new Range(0, 0))
        {
        }

        public Engine(Range range)
        {
            this.statistics = new Dictionary<string, int>();
            this.Range = range;
        }

        public Range Range { get; set; }

        public Dictionary<string, int> Statistics
        {
            get
            {
                return this.statistics;
            }
        }

        public IEnumerable<string> Generate()
        {
            var items = new List<string>();
            for (int i = this.Range.Start; i <= this.Range.End ; i++)
            {
                items.Add(this.GetItem(i));    
            }

            return items;
        }

        public int GetStatisticsForWord(string word)
        {
            return this.Statistics[word];
        }

        public int GetStatisticsForIntegers()
        {
            return this.Statistics["integer"];
        }

        protected virtual string GetItem(int index)
        {
            var result = string.Empty;
            
            if (index % 15 == 0)
            {
                result = Fizzbuzz;
                this.UpdateStatisticForWord(result);
            }
            else if (index % 3 == 0)
            {
                result = Fizz;
                this.UpdateStatisticForWord(result);
            }
            else if (index % 5 == 0)
            {
                result = Buzz;
                this.UpdateStatisticForWord(result);
            }
            else
            {
                result = index.ToString(CultureInfo.InvariantCulture);                
                this.UpdateStatisticForInteger(index);
            }

            return result;
        }

        private void UpdateStatisticForInteger(int index)
        {
            this.UpdateStatisticForWord("integer");
        }

        protected void UpdateStatisticForWord(string word)
        {
            int currentCount = 0;
            if (this.Statistics.ContainsKey(word))
            {
                currentCount = this.Statistics[word];
            }

            this.Statistics[word] = currentCount + 1;
        }
    }
}