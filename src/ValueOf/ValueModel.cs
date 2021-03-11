namespace ValueOfLib
{
    internal record ValueModel<TValue>
    {
        public TValue Value { get; private set; }
        public bool IsValid { get; set; }

        public ValueModel(TValue value)
        {
            Value = value;
            IsValid = true;
        }
    }
}
