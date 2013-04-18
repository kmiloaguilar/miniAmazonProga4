using DomainDrivenDatabaseDeployer;
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
            //_session.Save(new Account{Name = ""});
        }
    }
}