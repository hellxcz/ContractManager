using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContractManager.Controllers.Base;
using ContractManager.Domain;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers
{
    public class AddressController : PartyController<Address>
    {
        public AddressController(ContractDb contractDb)
            : base(contractDb)
        {}
        
        protected override IDbSet<Address> GetDbSet()
        {
            return ContractDb.Addresses;
        }
    }
}
