namespace ContractManager.Domain
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual string Value { get; set; }
    }
}