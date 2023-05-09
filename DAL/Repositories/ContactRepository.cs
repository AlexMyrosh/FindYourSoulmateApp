using DAL.Context;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly MssqlContext _sqlContext;

        public ContactRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
