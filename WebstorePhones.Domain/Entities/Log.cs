namespace WebstorePhones.Domain.Entities
{
    public class Log
    {
        public long Id { get; set; }
        public string DateTimeOfEvent { get; set; }
        public string NameOfEvent { get; set; }
        public string Details { get; set; }
    }
}
