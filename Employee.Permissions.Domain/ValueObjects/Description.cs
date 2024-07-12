namespace Employee.Permissions.Domain.ValueObjects
{
    public record Description
    {
        public string Value { get; init; }
        
        internal Description(string value) {
            this.Value = value;
        }

        public static Description Create(string value)
        {
            Validate(value);
            return new Description(value);
        }

        private static void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El valor no puede ser nulo o vacío");
            }
        }

    }
}
