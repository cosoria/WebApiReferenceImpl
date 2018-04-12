using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using WebApiReferenceImpl.Core.Reflection;
using WebApiReferenceImpl.Core.Utils;

namespace WebApiReferenceImpl.Core
{
    public static class Ensure
    {
        public static void That(bool condition, string message = "Condition specified was not met for the expression")
        {
            That<InvalidOperationException>(condition, message);
        }

        public static void That<TException>(bool condition, string message = "Condition specified was not met for the expression")
            where TException : Exception
        {
            if (!condition)
            {
                throw (TException) Activator.CreateInstance(typeof (TException), message);
            }
        }

        public static void Not(bool condition, string message = "Condition specified was not met for the expression")
        {
            Not<Exception>(condition, message);
        }

        public static void Not<TException>(bool condition, string message = "Condition specified was not met for the expression")
            where TException : Exception
        {
            That<TException>(!condition, message);
        }

        public static void NotNull(object value, string message = "Value specified can not be null")
        {
            That<NullReferenceException>(value != null, message);
        }

        public static void NotNull<TValue>(Expression<Func<TValue>> argumentExpression) where TValue:class
        {
            if (argumentExpression.Compile()() != null)
            {
                return;
            }

            var paramName = Reflect.VariableName(argumentExpression);
            var message = StringUtil.FormatInvariant("Value {0} of type '{1}' can not be null", paramName, typeof(TValue).Name);
            throw new NullReferenceException(message);
        }

        public static class Argument
        {
            public static void Is(bool condition, string argumentName = "?",
                                  string message = "No descriptive messsage supplied")
            {
                throw new ArgumentException(message, argumentName);
            }

            public static void IsNot(bool condition, string argumentName = "?",
                                     string message = "No descriptive messsage supplied")
            {
                Is(!condition, argumentName, message);
            }

            public static void NotNull<TValue>(TValue value, string argumentName = "?") where TValue : class
            {
                if(value == null)
                {
                    throw new ArgumentNullException(argumentName, string.Format("Argument '{0}' of type '{1}' can not be null", argumentName, typeof(TValue).Name));
                }
            }

            public static void NotNull<TValue>(Expression<Func<TValue>> argumentReference) where TValue : class
            {
                if (argumentReference.Compile()() != null)
                {
                    return;
                }

                var message = StringUtil.FormatInvariant("Parameter of type '{0}' can't be null", typeof (TValue).Name);
                var paramName = Reflect.VariableName(argumentReference);
                throw new ArgumentNullException(paramName, message);
            }

            public static void NotNullOrEmpty<TValue>(Expression<Func<TValue>> argumentReference) where TValue: class, IEnumerable
            {
                var d = argumentReference.Compile();
                if (d() != null && d().OfType<object>().Any())
                {
                    return;
                }

                var message = StringUtil.FormatInvariant("Parameter of type '{0}' can't be null or empty", typeof(TValue).Name);
                var paramName = Reflect.VariableName(argumentReference);
                throw new ArgumentNullException(paramName, message);
            }

            public static void NotNullOrEmpty(object value, string argumentName = "?")
            {
                if (value == null)
                {
                    throw new ArgumentNullException(argumentName, string.Format("Argument '{0}'can not be null", argumentName));
                }

                var stringValue = value as string;
                if (stringValue != null && string.IsNullOrEmpty(stringValue))
                {
                    throw new ArgumentNullException(argumentName, string.Format("String argument '{0}' can not be null", argumentName));
                }

                var enumerableValue = value as IEnumerable;
                if (enumerableValue != null && !enumerableValue.Cast<object>().Any())
                {
                    throw new ArgumentNullException(argumentName, string.Format("String argument '{0}' can not be null", argumentName));
                }
            }
        }
    }
}