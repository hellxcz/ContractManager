using ContractManager.Domain.Interrfaces;

namespace ContractManager.Domain
{
    public class Address : IHaveId
    {
        public virtual int Id { get; set; }
        public virtual string Street { get; set; }

        public virtual int? PersonId { get; set; }
        public virtual int? CompanyId { get; set; }
    }
}