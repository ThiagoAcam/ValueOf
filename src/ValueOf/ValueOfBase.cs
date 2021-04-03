using System.Collections.Generic;
using ValueOfLib.Exceptions;

namespace ValueOfLib
{
    /// <summary>
    /// This class is a base to create ways to implement a standardized Value Objects
    /// </summary>
    /// <typeparam name="TValue">TValue is a value of Value Object, like a string to represents a Zip Code</typeparam>
    /// <typeparam name="TThis">The class that is inheriting from ValueOfBase</typeparam>
    public abstract class ValueOfBase<TValue, TThis> where TThis : ValueOfBase<TValue, TThis>
    {
        #region Fields

        private readonly TValue _value;

        #endregion

        #region Properties

        /// <summary>
        /// IsValid returns true if this ValueObject is valid and false if is invalid
        /// </summary>
        public readonly bool IsValid = true;

        /// <summary>
        /// Value is de value passed when the ValueObject was create, if this is valid returns value, but if is invalid this throw a ValueObjectInvalidException
        /// </summary>
        public TValue Value
        {
            get
            {
                if (!IsValid)
                    throw new ValueObjectInvalidException();

                return _value;
            }
        }

        #endregion

        /// <summary>
        /// This constructor always has to be called when building a ValueObject
        /// </summary>
        /// <param name="value">Value is the value of ValueObject</param>
        protected ValueOfBase(TValue value)
        {
            _value = value;
            IsValid = Validate();
        }

        /// <summary>
        /// This function determines whether the value passed is valid. The return of this function is assigned to the IsValid property
        /// </summary>
        /// <returns></returns>
        protected abstract bool Validate();

        /// <summary>
        /// This function determines a way to verify if two Value Objects is equal by the values
        /// </summary>
        /// <param name="obj">The object that will be compared to the current instance</param>
        /// <returns></returns>
        protected abstract bool Equals(TThis obj);

        /// <summary>
        /// This function determines a way to check if two Value Objects are the same, if two objects are of the same type the specific Equal is called
        /// </summary>
        /// <param name="obj">The object that will be compared to the current instance</param>
        /// <returns></returns>
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

        public static bool operator ==(ValueOfBase<TValue, TThis> a, ValueOfBase<TValue, TThis> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueOfBase<TValue, TThis> a, ValueOfBase<TValue, TThis> b)
        {
            return !(a == b);
        }

        public static implicit operator TValue(ValueOfBase<TValue, TThis> a)
        {
            return a.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}