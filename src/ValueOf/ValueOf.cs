using ValueOfLib.Exceptions;

namespace ValueOfLib
{
    public abstract class ValueOf<TValue, TThis> : ValueOfBase<TValue, TThis> where TThis : ValueOfBase<TValue, TThis>
    {

        protected ValueOf(TValue value)
            :base(value)
        { }
    }
}