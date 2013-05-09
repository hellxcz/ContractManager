using System.Linq;

namespace ContractManager.Domain.Interfaces
{
    public interface IContractDataSource
    {
        IQueryable<Contract> Contracts { get; }    
    }

    public interface ICompanyDataSource
    {
        IQueryable<Company> Companies { get; } 
    }

    public interface IPersonDataSource
    {
        IQueryable<Person> Persons { get; } 
    }

}