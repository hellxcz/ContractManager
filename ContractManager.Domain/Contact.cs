using ContractManager.Domain.Interfaces;

namespace ContractManager.Domain
{
    public class Contact : IHaveId, IHaveCompanyId, IHavePersonId
    {
        public virtual int Id { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual string Value { get; set; }

        public virtual int? CompanyId { get; set; }
        public virtual int? PersonId { get; set; }
    }
}