using System.Collections.Generic;
using ContractManager.Domain.Interrfaces;

namespace ContractManager.Domain
{
    public class Person : IHaveId
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Title { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
        public virtual IList<Address> Addresses { get; set; } 
    }
}