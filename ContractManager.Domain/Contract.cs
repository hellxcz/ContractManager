namespace ContractManager.Domain
{
    public class Contract
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }

        public virtual Company Company { get; set; }
    }
}