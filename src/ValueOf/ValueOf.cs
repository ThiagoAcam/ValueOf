namespace ValueOfLib
{
    /// <summary>
    /// This class is to guarantee the standard behaviors and properties of a value object
    /// </summary>
    /// <typeparam name="TValue">TValue is a value of Value Object, like a string to represents a Zip Code</typeparam>
    /// <typeparam name="TThis">The class that is inheriting from ValueOf</typeparam>
    public abstract class ValueOf<TValue, TThis> : ValueOfBase<TValue, TThis> where TThis : ValueOfBase<TValue, TThis>
    {
        /// <summary>
        /// Standard builder for call Value Of Base's builder
        /// </summary>
        /// <param name="value">Value is the value of ValueObject</param>
        protected ValueOf(TValue value)
            :base(value)
        { }
    }
}