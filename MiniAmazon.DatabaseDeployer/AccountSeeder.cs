using DomainDrivenDatabaseDeployer;
using MiniAmazon.Domain.Entities;
using NHibernate;

namespace MiniAmazon.DatabaseDeployer
{
    public class AccountSeeder : IDataSeeder
    {
        private readonly ISession _session;

        public AccountSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var account = new Account
                {
                    Name = "Camilo",
                    Email = "camilo.aguilar@me.com",
                    Password = "pass123"
                };

            _session.Save(account);
        }
    }
}