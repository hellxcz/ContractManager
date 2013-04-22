using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContractManager.Domain;
using ContractManager.Domain.Interfaces;

namespace ContractManager.Infrastructure
{
    public class ContractDb : DbContext, 
        IContractDataSource, ICompanyDataSource, IPersonDataSource
    {
        public ContractDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

        IQueryable<Contract> IContractDataSource.Contracts
        {
            get { return Contracts; }
        }

        IQueryable<Company> ICompanyDataSource.Companies
        {
            get { return Companies; }
        }

        IQueryable<Person> IPersonDataSource.Persons
        {
            get { return Persons; }
        }
    }
}