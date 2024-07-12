namespace Employee.Permissions.Domain.ValueObjects
{
    public record LastName
    {
        public string Value { get; init; }

        internal LastName(string value)
        {
            this.Value = value;
        }

        public static LastName Create(string value)
        {
            Validate(value);
            return new LastName(value);
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
