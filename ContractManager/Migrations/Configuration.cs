using ContractManager.Domain;

namespace ContractManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContractManager.Infrastructure.ContractDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ContractManager.Infrastructure.ContractDb context)
        {
            context
                .AddressTypes
                .AddOrUpdate(at => at.URI,
                             new AddressType() {Name = "Main", URI = "MainURI"},
                             new AddressType() {Name = "Delivery", URI = "DeliveryURI"},
                             new AddressType() {Name = "Billing", URI = "BillingURI"}
                );

            context
                .ContactTypes
                .AddOrUpdate(ct => ct.URI,
                             new ContactType() {Name = "Telephone", URI = "TelephoneURI"},
                             new ContactType() {Name = "Fax", URI = "FaxURI"},
                             new ContactType() {Name = "Email", URI = "EmailURI"},
                             new ContactType() {Name = "Mobile", URI = "MobileURI"}
                );
        }
    }
}
