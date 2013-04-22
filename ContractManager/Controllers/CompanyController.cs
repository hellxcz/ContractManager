using System;
using System.Collections.Generic;
using System.Web;
using ContractManager.Controllers.Base;
using ContractManager.Domain;
using ContractManager.Domain.Interfaces;
using ContractManager.Infrastructure;

namespace ContractManager.Controllers
{
    public class CompanyController : BaseController<Company>
    {
        public CompanyController(ContractDb contractDb) 
            : base(contractDb)
        {
        }

        protected override Company MapEntityBeforeSave(Company entity, Company savedEntity)
        {
            savedEntity.ICO = entity.ICO;
            savedEntity.DIC = entity.DIC;
            savedEntity.Name = entity.Name;

            return savedEntity;
        }

        protected override System.Data.Entity.IDbSet<Company> GetDbSet()
        {
            return ContractDb.Companies;
        }
    }
}
