using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContractManager.Controllers.Base;
using ContractManager.Domain;
using ContractManager.Domain.Interfaces;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers
{
    public class PersonController : BaseController<Person>
    {
        public PersonController(ContractDb contractDb )
            : base(contractDb)
        {
        }
        
        //protected override ActionResult CreateRedirectAction(Person entity)
        //{
        //    return base.Edit(entity.Id);
        //}

        protected override IDbSet<Person> GetDbSet()
        {
            return ContractDb.Persons;
        }
    }
}
