using System;

namespace Rigel.Core
{
    public struct Maybe<T> : IEquatable<Maybe<T>> where T:class
    {
        private readonly T _value;

        public T Value { get { return _value; } }

        public bool HasValue { get { return _value != null; } }

        public Maybe(T value) : this()
        {
            _value = value;
        }
       
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (maybe._value == null)
            {
                return false;
            }
            
            return maybe._value.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<T>))
            {
                return false;
            }
            
            var other = (Maybe<T>)obj;
            return Equals(other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (_value == null && other._value == null)
            {
                return true;
            }

            if (_value == null || other._value == null)
            {
                return false;
            }
            
            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            if (HasValue)
            {
                return _value.ToString();
            }

            return "No value";
        }

        public T Unwrap()
        {
            if (HasValue)
                return _value;

            return default(T);
        }

        
        public K Unwrap<K>(Func<T, K> selector)
        {
            if (HasValue)
            {
                return selector(_value);
            }
            
            return default(K);
        }

    }
}