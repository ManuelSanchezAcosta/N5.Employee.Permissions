namespace Employee.Permissions.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; init; }
        
        internal Name(string value) {
            this.Value = value;
        }

        public static Name Create(string value)
        {
            Validate(value);
            return new Name(value);
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
