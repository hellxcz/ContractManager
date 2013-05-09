using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ContractManager.Domain.Interfaces;
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

        public virtual ActionResult Details(int id)
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

                Entities.Add(entity);
                ContractDb.SaveChanges();

                return GetCreateRedirectAction(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        protected virtual ActionResult GetCreateRedirectAction(TEntity entity)
        {
            return RedirectToAction("Index");
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

                var savedEntity = Entities.Find(entity.Id);

                if (!TryUpdateModel(savedEntity))
                {
                    return View();
                }

                ContractDb.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public virtual ActionResult Delete(int id)
        {
            try
            {
                var savedEntity = Entities.Find(id);

                var redirectAction = GetDeleteRedirectAction(savedEntity);

                if (!ModelState.IsValid)
                {
                    return View(savedEntity);
                }

                Entities.Remove(savedEntity);

                ContractDb.SaveChanges();

                return redirectAction;

            }
            catch(Exception e)
            {
                // maybe redirect to error page with some message
                // that he deletion has failed by reaseon

                return View();
            }
        }

        protected virtual ActionResult GetDeleteRedirectAction(TEntity entity)
        {
            return RedirectToAction("Index");
        }

        protected abstract IDbSet<TEntity> GetDbSet();
    }
}