namespace Employee.Permissions.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; init; }

        internal Email(string value)
        {
            this.Value = value;
        }

        public static Email Create(string value)
        {
            Validate(value);
            return new Email(value);
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
