using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    using FizzBuzz;

    class Program
    {
        private readonly Options options;

        private Program(Options options)
        {
            this.options = options;
        }

        static void Main(string[] args)
        {
            var options = new Options();
            var result = CommandLine.Parser.Default.ParseArguments(args, options);
            if (result)
            {
                new Program(options).Run();            
            }

            Console.ReadKey();
        }

        private void Run()
        {
            var engine = new LuckyEngine(new Range(this.options.Start, this.options.End));
            var results = engine.Generate();

            Console.WriteLine(Concat(results));
            foreach (var item in engine.Statistics)
            {
                Console.WriteLine("{0,-10} : {1,10}", item.Key, item.Value);
            }
        }

        private string Concat(IEnumerable<string> results)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (var result in results)
            {
                buffer.Append(result + " ");
            }

            return buffer.ToString().TrimEnd();
        }
    }
}
