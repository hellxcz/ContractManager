using System.Web.Mvc;
using ContractManager.Domain.Interfaces;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers.Base
{
    public abstract class PartyController<TEntity> : BaseController<TEntity>
        where TEntity : class, IHaveId, IHaveCompanyId, IHavePersonId
    {
        protected PartyController(ContractDb contractDb) : base(contractDb)
        {
        }

        protected override ActionResult GetCreateRedirectAction(TEntity entity)
        {
            return GetRedirectAction(entity) ?? base.GetCreateRedirectAction(entity);
        }

        protected override ActionResult GetDeleteRedirectAction(TEntity entity)
        {
            return GetRedirectAction(entity) ?? base.GetDeleteRedirectAction(entity);
        }

        protected ActionResult GetRedirectAction(TEntity entity)
        {
            if (entity.PersonId.HasValue)
            {
                return RedirectToAction("Edit", "Person", new { Id = entity.PersonId.Value });
            }

            if (entity.CompanyId.HasValue)
            {
                return RedirectToAction("Edit", "Company", new { Id = entity.CompanyId.Value });
            }
            return null;
        }

        [RequireRequestValues("companyId", "personId")]
        public ActionResult Create(int? companyId, int? personId)
        {
            return View();
        }
    }
}