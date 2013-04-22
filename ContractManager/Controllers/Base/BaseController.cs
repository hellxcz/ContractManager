using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ContractManager.Domain.Interrfaces;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers.Base
{
    public abstract class BaseController<TEntity> : Controller
        where TEntity : class, IHaveId
    {
        public ContractDb ContractDb { get; set; }

        public IDbSet<TEntity> Entities { get; set; }

        protected BaseController(ContractDb contractDb)
        {
            ContractDb = contractDb;
            Entities = GetDbSet();
        }

        public virtual ActionResult Index()
        {
            return View(Entities);
        }

        public ActionResult Details(int id)
        {
            var entity = Entities.Find(id);

            if (entity == null)
            {
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(entity);
                }

                // TODO: Add insert logic here

                Entities.Add(entity);
                ContractDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(entity);
            }
        }

        public virtual ActionResult Edit(int id)
        {
            var entity = Entities.Find(id);

            if (entity == null)
            {
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        [HttpPost]
        public virtual ActionResult Edit(TEntity entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(entity);
                }

                // TODO: Add update logic here

                var savedEntity = Entities.Find(entity.Id);

                // what will be updated
                MapEntityBeforeSave(entity, savedEntity);
    
                ContractDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        protected abstract TEntity MapEntityBeforeSave(TEntity entity, TEntity savedEntity);
        protected abstract IDbSet<TEntity> GetDbSet();
    }
}