using System.Linq;
using DomainDrivenDatabaseDeployer;
using MiniAmazon.Domain.Entities;
using NHibernate;
using NHibernate.Linq;

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
            var role1 = _session.Query<Role>().First(x => x.Name == "Admin");
            var role2 = _session.Query<Role>().First(x => x.Name == "Patito");

            var account = new Account
                {
                    Name = "Camilo",
                    Email = "camilo.aguilar@me.com",
                    Password = "pass123",
                    
                };

            _session.Save(account);

            account.AddRole(role1);
            account.AddRole(role2);

            _session.Update(account);
        }
    }
}