using System;
using System.Collections.Generic;

namespace ValueOfLib
{
    public abstract class ValueOf<TValue, TThis> where TThis : ValueOf<TValue, TThis>
    {
        private TValue _value;
        public TValue Value => _value;

        protected ValueOf(TValue value)
        {
            _value = value;
            Validate();
        }

        protected abstract void Validate();

        protected abstract bool Equals(TThis obj);

        public override bool Equals(object obj)
        {
            var valueOf = obj as TThis;
            if (valueOf == null)
                return false;

            return ReferenceEquals(this, obj) || Equals(valueOf);
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