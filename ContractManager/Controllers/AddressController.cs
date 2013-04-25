using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContractManager.Controllers.Base;
using ContractManager.Domain;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers
{
    public class AddressController : BaseController<Address>
    {
        public AddressController(ContractDb contractDb)
            : base(contractDb)
        {

        }

        protected override Address MapEntityBeforeUpdate(Address entity, Address savedEntity)
        {
            savedEntity.Street = entity.Street;

            return savedEntity;
        }

        protected override IDbSet<Address> GetDbSet()
        {
            return ContractDb.Addresses;
        }

        [RequireRequestValues("companyId", "personId")]
        public ActionResult Create(int? companyId, int? personId)
        {
            return View();
        }

        protected override ActionResult CreateRedirectAction(Address entity)
        {
            if (entity.PersonId.HasValue)
            {
                return RedirectToAction("Edit", "Person", new { Id = entity.PersonId.Value });     
            }

            if (entity.CompanyId.HasValue)
            {
                return RedirectToAction("Edit", "Company", new { Id = entity.CompanyId.Value });     
            }

            return base.CreateRedirectAction(entity);
        }
    }
}
