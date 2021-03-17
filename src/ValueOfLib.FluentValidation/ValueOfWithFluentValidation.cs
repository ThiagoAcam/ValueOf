using FluentValidation;
using FluentValidation.Results;

namespace ValueOfLib.FluentValidation
{
    public static class ValueOfWithFluentValidation
    {

        public abstract class WithNotifications<TValue, TThis, TValidator> : ValueOfBase<TValue, TThis>
                                                                             where TThis : ValueOfBase<TValue, TThis>
                                                                             where TValidator : AbstractValidator<TThis>, new()
        {
            public ValidationResult ValidationResult { get; private set; }

            public WithNotifications(TValue value)
                :base(value)
            { }

            protected override sealed bool Validate()
            {
                ValidationResult = new TValidator().Validate(this as TThis);
                return ValidationResult.IsValid;
            }
        }

        public abstract class WithExceptions<TValue, TThis, TValidator> : ValueOfBase<TValue, TThis>
                                                                          where TThis : ValueOfBase<TValue, TThis>
                                                                          where TValidator : AbstractValidator<TThis>, new()
        {
            public WithExceptions(TValue value)
                : base(value)
            { }

            protected override sealed bool Validate()
            {
                new TValidator().ValidateAndThrow(this as TThis);
                return true;
            }
        }

    }
}
