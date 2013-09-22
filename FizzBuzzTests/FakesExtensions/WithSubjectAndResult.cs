// -----------------------------------------------------------------------
// <copyright file="Class1.cs">
// Copyright (c) 2013.
// </copyright>
// -----------------------------------------------------------------------
namespace FizzBuzzTests.FakesExtensions
{
    using Machine.Fakes;

    public class WithSubjectAndResult<TSubject, TResult> : WithSubject<TSubject>
      where TSubject : class
    {
        public static TResult Result { get; set; }
    }
}