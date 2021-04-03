using FluentValidation;
using FluentValidation.Results;

namespace ValueOfLib.FluentValidation
{
    public static class ValueOfWithFluentValidation
    {
        /// <summary>
        /// This class is to guarantee the standard behaviors and properties of a value object
        /// When built, it stores the FluentValidation validation result in the ValidationResult property
        /// </summary>
        /// <typeparam name="TValue">TValue is a value of Value Object, like a string to represents a Zip Code</typeparam>
        /// <typeparam name="TThis">The class that is inheriting from ValueOf</typeparam>
        /// <typeparam name="TValidator">Precisa ser uma classe que herda de AbstractValidator do FluentValidation para validar o Value Object</typeparam>
        public abstract class WithNotifications<TValue, TThis, TValidator> : ValueOfBase<TValue, TThis>
                                                                             where TThis : ValueOfBase<TValue, TThis>
                                                                             where TValidator : AbstractValidator<TThis>, new()
        {
            /// <summary>
            /// ValidationResult is the result of the validation done by FluentValidation
            /// </summary>
            public ValidationResult ValidationResult { get; private set; }

            /// <summary>
            /// Standard builder for call Value Of Base's builder
            /// </summary>
            /// <param name="value">Value is the value of ValueObject</param>
            public WithNotifications(TValue value)
                :base(value)
            { }

            /// <summary>
            /// This function validates the value through FluentValidation and stores the result in the ValidationResult property. The return of this function is attributed to the IsValid property
            /// </summary>
            /// <returns></returns>
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
            /// <summary>
            /// Standard builder for call Value Of Base's builder
            /// </summary>
            /// <param name="value">Value is the value of ValueObject</param>
            public WithExceptions(TValue value)
                : base(value)
            { }

            /// <summary>
            /// This function validates the value through FluentValidation and if is inválid this throw a ValidationException
            /// </summary>
            /// <returns></returns>
            protected override sealed bool Validate()
            {
                new TValidator().ValidateAndThrow(this as TThis);
                return true;
            }
        }

    }
}
