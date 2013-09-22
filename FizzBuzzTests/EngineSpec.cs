// -----------------------------------------------------------------------
// <copyright file="EngineSpec.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------


using System;

using Machine.Fakes;
using Machine.Specifications;

namespace FizzBuzzTests
{
    using System.Collections.Generic;
    using System.Linq;

    using FizzBuzz;

    using FizzBuzzTests.FakesExtensions;

    [Subject(typeof(Engine), "Instantiation")]
    public class when_creating_an_instance_of_the_fizzbuzz_engine : WithResult<Engine>
    {
        Establish context = () => 
            {};

        Because of = () => 
            Result = new Engine();

        It should_return_the_start_range_of_numbers_as_unintialized = () => 
            Result.Range.Start.ShouldEqual(0);

        It should_return_the_end_range_of_numbers_as_unintialized = () => 
            Result.Range.End.ShouldEqual(0);
    }
    [Subject(typeof(Engine), "Instantiation")]
    public class when_creating_an_instance_of_the_fizzbuzz_engine_specifying_start_and_end_range : WithResult<Engine>
    {
        Establish context = () => 
            {};

        Because of = () => 
            Result = new Engine(new Range(1, 20));

        It should_return_the_start_range_of_numbers = () => 
            Result.Range.Start.ShouldEqual(1);
        
        It should_return_the_end_range_of_numbers = () => 
            Result.Range.End.ShouldEqual(20);
    }

    [Subject(typeof(Engine), "Generating items")]
    public class when_generating_items : WithSubjectAndResult<Engine, IEnumerable<string>>
    {
        Establish context = () =>
           With(new EngineContext(1, 20));

        Because of = () =>
            Result = Subject.Generate(); 

        It should_return_an_element_for_each_number_in_the_input_range = () => 
            Result.Count().ShouldEqual(20);
    }

    [Subject(typeof(Engine), "Fizzbuzz Rules")]
    public class When_running_the_engine_over_a_range_of_numbers : WithSubjectAndResult<Engine, IEnumerable<string>>
    {
        Establish context = () => 
            With(new EngineContext(1, 20));

        Because of = () => 
            Result = Subject.Generate();

        It should_generate_fizz_for_numbers_that_are_multiples_of_3 = () =>
            {
                Result.ElementAt(Index(3)).ShouldEqual("fizz");
                Result.ElementAt(Index(6)).ShouldEqual("fizz");
            };

        It should_generate_buzz_for_numbers_that_are_multiples_of_5 = () =>
            {
                Result.ElementAt(Index(5)).ShouldEqual("buzz");
                Result.ElementAt(Index(10)).ShouldEqual("buzz");
            };

        It should_generate_fizzbuzz_for_numbers_that_are_multiples_of_15 = () =>
            {
                Result.ElementAt(Index(15)).ShouldEqual("fizzbuzz");
            };

        It should_produce_an_entire_output_that_matches_the_test_pattern = () =>
            Result.Aggregate((current, next) => current + " " + next)
                    .ShouldEqual("1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz");

        static int Index(int value)
        {
            return value - 1;
        }
    }

    [Subject(typeof(Engine), "Statistics")]
    public class when_reporting_the_statistics_of_a_fizz_buzz_run : WithSubject<Engine>
    {
        Establish context = () =>
           With(new EngineContext(1, 20));

        Because of = () =>
            Subject.Generate();

        It should_correctly_determine_the_number_of_fizz_occurances = () =>
            Subject.GetStatisticsForWord("fizz").ShouldEqual(5);

        It should_correctly_determine_the_number_of_buzz_occurances = () =>
            Subject.GetStatisticsForWord("buzz").ShouldEqual(3);

        It should_correctly_determine_the_number_of_fizzbuzz_occurances = () =>
            Subject.GetStatisticsForWord("fizzbuzz").ShouldEqual(1);

        It should_correctly_determine_the_number_of_integer_occurances = () =>
            Subject.GetStatisticsForIntegers().ShouldEqual(11);
    }

    internal class EngineContext : ContextBase
    {
        private static int start;
        private static int end;

        public EngineContext(int startingNumber, int endNumber)
        {
            start = startingNumber;
            end = endNumber;
        }

          OnEstablish context = engine =>
              {
                  FakeAccessor = engine;
                  Subject<Engine>().Range.Start = start;
                  Subject<Engine>().Range.End = end;
              };
    }
}