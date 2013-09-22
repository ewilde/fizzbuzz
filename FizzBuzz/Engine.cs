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
        public Engine() : this(new Range(0, 0))
        {            
        }

        public Engine(Range range)
        {
            this.Range = range;
        }

        public Range Range { get; set; }

        public IEnumerable<string> Generate()
        {
            var items = new List<string>();
            for (int i = this.Range.Start; i <= this.Range.End ; i++)
            {
                items.Add(this.GetItem(i));    
            }

            return items;
        }

        private string GetItem(int index)
        {
            var result = string.Empty;
            
            if (index % 15 == 0)
            {
                result = "fizzbuzz";
            }
            else if (index % 3 == 0)
            {
                result = "fizz";
            }
            else if (index % 5 == 0)
            {
                result = "buzz";
            }
            else
            {
                result = index.ToString(CultureInfo.InvariantCulture);                
            }

            return result;
        }
    }
}