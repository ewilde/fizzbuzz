// -----------------------------------------------------------------------
// <copyright file="RangeSpec.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------


using System;

using Machine.Fakes;
using Machine.Specifications;

namespace FizzBuzzTests
{
    using FizzBuzz;

    using FizzBuzzTests.FakesExtensions;

    [Subject(typeof(Range))]
    public class when_calculating_the_number_of_items_in_a_range : WithSubjectAndResult<Range, int>
    {
        Establish context = () =>
            {
                Subject.Start = 2;
                Subject.End = 5;
            };

        Because of = () => 
            Result = Subject.Count;

        It should_include_the_start_and_end_number = () =>
            {
                Result.ShouldEqual(4);
            };
    }
}