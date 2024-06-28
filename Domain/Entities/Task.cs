namespace Domain.Entities
{
    public class Task : BaseEntity
    {

        public string? Name{ get; set; }        

        public DateTime DateTime { get; set; }

        public string? Description { get; set; }

        public bool Status { get; set; }
    }
}
