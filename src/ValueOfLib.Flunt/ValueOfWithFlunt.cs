using Flunt.Notifications;
using System;
using System.Collections.Generic;
using ValueOfLib.Flunt.Exceptions;

namespace ValueOfLib.Flunt
{
    /// <summary>
    /// This class is to guarantee the standard behaviors and properties of a value object
    /// When built, it stores the Flunt validation result in the Notifications property
    /// </summary>
    /// <typeparam name="TValue">TValue is a value of Value Object, like a string to represents a Zip Code</typeparam>
    /// <typeparam name="TThis">The class that is inheriting from ValueOf</typeparam>
    public abstract class ValueOfWithFlunt<TValue, TThis> : ValueOfBase<TValue, TThis> where TThis : ValueOfBase<TValue, TThis>
    {
        #region Fields

        private readonly InternalNotifiable _internalNotifiable = new InternalNotifiable();
        private readonly bool _builtObject = false;

        #endregion

        #region Propriedades

        /// <summary>
        /// Notifications is the result of the validation done by Flunt
        /// </summary>
        public IReadOnlyCollection<Notification> Notifications => _internalNotifiable.Notifications;

        /// <summary>
        /// HasNotifications is true if Notifications Count greater than zero
        /// </summary>
        public bool HasNotifications => _builtObject ? !IsValid : !_internalNotifiable.IsValid;

        #endregion

        /// <summary>
        /// Standard builder for call Value Of Base's builder
        /// </summary>
        /// <param name="value">Value is the value of ValueObject</param>
        public ValueOfWithFlunt(TValue value)
            : base(value)
        {
            _builtObject = true;
        }

        /// <summary>
        /// The validations using Flunt only must be written in this method
        /// </summary>
        protected abstract void Validations();

        protected override sealed bool Validate()
        {
            Validations();

            return _internalNotifiable.IsValid;
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotification(string key, string message)
        {
            ValidOperation();

            _internalNotifiable.AddNotification(key, message);
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotification<T>(T notification) where T : Notification
        {
            ValidOperation();

            _internalNotifiable.AddNotification(notification);
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotifications<T>(Notifiable<T> notification) where T : Notification
        {
            ValidOperation();

            _internalNotifiable.AddNotifications(notification.Notifications);
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotification(Type property, string message)
        {
            ValidOperation();

            _internalNotifiable.AddNotification(property, message);
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotifications<T>(IReadOnlyCollection<T> notifications) where T : Notification
        {
            ValidOperation();

            _internalNotifiable.AddNotifications(notifications);
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotifications<T>(IList<T> notifications) where T : Notification
        {
            ValidOperation();

            _internalNotifiable.AddNotifications((IList<Notification>)notifications);
        }

        /// <summary>
        /// This method is to add Flunt notifications, and only can be using in Validations method
        /// </summary>
        protected void AddNotifications<T>(ICollection<T> notifications) where T : Notification
        {
            ValidOperation();

            _internalNotifiable.AddNotifications((ICollection<Notification>)notifications);
        }

        private void ValidOperation()
        {
            if (_builtObject)
                throw new InvalidCallMomentException("This operation can only be invoked in the Validations method");
        }
    }
}
