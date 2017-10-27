using System;
using System.Collections.Generic;
using System.Linq;

namespace Rigel.Core
{
        public class Result
    {
        private readonly List<string> _errors;

        public bool Success { get { return _errors.Count == 0; } }
        public bool Failed { get { return _errors.Count > 0; } }
        public string[] Errors { get { return _errors.ToArray(); } }

        protected Result() : this(Enumerable.Empty<string>())
        {
        }

        protected Result(IEnumerable<string> errors)
        {
            _errors = new List<string>();
            _errors.AddRange(errors);
        }

        protected void AddError(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                return;
            }

            _errors.Add(error);
        }

        protected void AddErrors(IEnumerable<string> errors)
        {
            _errors.AddRange(errors);
        }

        public Result CombineWith(Result another)
        {
            if (another == null)
            {
                return this;
            }


            if (another.Failed)
            {
                _errors.AddRange(another._errors);
            }

            return this;
        }

        public Result CombineWith(IEnumerable<Result> others)
        {
            foreach (var r in others)
            {
                CombineWith(r);
            }

            return this;
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result Error(IEnumerable<string> errors)
        {
            if (!errors.Any())
            {
                throw new InvalidOperationException("Errors can not empty when result is set failure");
            }

            return new Result(errors);
        }

        public static Result<T> Error<T>(IEnumerable<string> errors)
        {
            return new Result<T>(errors);
        }

        public static Result Error(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException("Errors can not empty when result is set failure");
            }

            return new Result(new string[] { error });
        }

        public static Result<T> Error<T>(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException("Errors can not empty when result is set failure");
            }

            return new Result<T>(new string[] { error });
        }

        public static Result Combine(IEnumerable<Result> results)
        {
            var all = Ok();

            foreach (var r in results)
            {
                all.CombineWith(r);
            }

            return all;
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value { get { return _value; } }

        protected internal Result(T value) 
        {
            _value = value;
        }

        protected internal Result(IEnumerable<string> errors) : base(errors)
        {
            _value = default(T);
        }

        public new Result<T> CombineWith(IEnumerable<Result> others)
        {
            foreach (var r in others)
            {
                CombineWith(r);
            }

            return this;
        }

        public new Result<T> CombineWith(Result another)
        {
            if (another == null)
            {
                return this;
            }


            if (another.Failed)
            {
                AddErrors(another.Errors);
            }

            return this;
        }
    }
}
