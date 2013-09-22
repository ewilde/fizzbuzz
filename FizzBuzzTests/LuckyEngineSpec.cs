// -----------------------------------------------------------------------
// <copyright file="LuckyEngineSpec.cs">
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

    [Subject(typeof(LuckyEngine), "Fizzbuzz extended rules")]
    public class When_running_the_lucky_engine_over_a_range_of_numbers : WithSubjectAndResult<LuckyEngine, IEnumerable<string>>
    {
        Establish context = () =>
            With(new EngineContext(1, 20));

        Because of = () =>
            Result = Subject.Generate();

        It should_replace_numbers_that_contain_a_three_with_the_text_lucky  = () =>
            {
                Result.ElementAt(Index(3)).ShouldEqual("lucky");
                Result.ElementAt(Index(13)).ShouldEqual("lucky");
            };

        It should_produce_an_entire_output_that_matches_the_test_pattern = () =>
            Result.Aggregate((current, next) => current + " " + next)
                    .ShouldEqual("1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz");
            

        static int Index(int value)
        {
            return value - 1;
        }
    }


    [Subject(typeof(LuckyEngine), "Statistics")]
    public class when_reporting_the_statistics_of_a_fizz_buzz_run_using_the_lucky_engine : WithSubject<LuckyEngine>
    {
        Establish context = () =>
           With(new LuckyEngineContext(1, 20));

        Because of = () =>
            Subject.Generate();

        It should_correctly_determine_the_number_of_fizz_occurances = () =>
            Subject.GetStatisticsForWord("fizz").ShouldEqual(4);

        It should_correctly_determine_the_number_of_buzz_occurances = () =>
            Subject.GetStatisticsForWord("buzz").ShouldEqual(3);

        It should_correctly_determine_the_number_of_fizzbuzz_occurances = () =>
            Subject.GetStatisticsForWord("fizzbuzz").ShouldEqual(1);
        
        It should_correctly_determine_the_number_of_lucky_occurances = () =>
            Subject.GetStatisticsForWord("lucky").ShouldEqual(2);

        It should_correctly_determine_the_number_of_integer_occurances = () =>
            Subject.GetStatisticsForIntegers().ShouldEqual(10);
    }

    internal class LuckyEngineContext : ContextBase
    {
        private static int start;
        private static int end;

        public LuckyEngineContext(int startingNumber, int endNumber)
        {
            start = startingNumber;
            end = endNumber;
        }

        OnEstablish context = engine =>
        {
            FakeAccessor = engine;
            Subject<LuckyEngine>().Range.Start = start;
            Subject<LuckyEngine>().Range.End = end;
        };
    }
}