using System.Collections.Generic;
using ContractManager.Domain.Interrfaces;

namespace ContractManager.Domain
{
    public class Company : IHaveId
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ICO { get; set; }
        public virtual string DIC { get; set; }

        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Contact> Contacts { get; set; }

        public virtual IList<Person> Persons { get; set; } 
        //public virtual Address MainAddress { get; set; }

    }
}