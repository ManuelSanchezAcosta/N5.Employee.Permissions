namespace Employee.Permissions.Domain.ValueObjects
{
    public record Id
    {

        public string Value { get; init; }

        internal Id(string value)
        {
            Value = value;
        }

        public static Id Create(string value)
        {
            return new Id(value);
        }
        public static implicit operator string(Id id)
        {
            return id.Value;
        }

    }
}
