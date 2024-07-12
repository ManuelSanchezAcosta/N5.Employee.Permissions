namespace Employee.Permissions.Domain.Entities
{
    public class Audit
    {
        public string User { get; set; }
        public DateTime CreationDate { get; set; }


        public Audit()
        {
            this.User = "N5";
            this.CreationDate = DateTime.Now;
        }

    }
}
