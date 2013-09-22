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

        static int Index(int value)
        {
            return value - 1;
        }
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