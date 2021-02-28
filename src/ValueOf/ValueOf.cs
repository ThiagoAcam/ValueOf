using System;
using System.Collections.Generic;

namespace ValueOfLib
{
    public abstract class ValueOf<TValue, TThis> where TThis : ValueOf<TValue, TThis>, IEquatable<ValueOf<TValue, TThis>>
    {
        private TValue _value;
        public TValue Value => _value;

        protected ValueOf(TValue value)
        {
            _value = value;
            Validate();
        }

        protected abstract void Validate();

        public override bool Equals(object obj)
        {
            var valueOf = obj as ValueOf<TValue, TThis>;
            if (valueOf == null)
                return false;

            return Equals(valueOf);
        }

        public bool Equals(ValueOf<TValue, TThis> obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals(obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TValue>.Default.GetHashCode(Value);
        }

        public static bool operator ==(ValueOf<TValue, TThis> a, ValueOf<TValue, TThis> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueOf<TValue, TThis> a, ValueOf<TValue, TThis> b)
        {
            return !(a == b);
        }

        public static implicit operator TValue(ValueOf<TValue, TThis> a)
        {
            return a.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}