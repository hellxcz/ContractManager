using System.Data.Entity;
using ContractManager.Controllers.Base;
using ContractManager.Domain;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers
{
    public class ContactController : PartyController<Contact>
    {
        public ContactController(ContractDb contractDb) : base(contractDb)
        {}

        protected override IDbSet<Contact> GetDbSet()
        {
            return ContractDb.Contacts;
        }
    }
}