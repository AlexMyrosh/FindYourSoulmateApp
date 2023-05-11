using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly MssqlContext _sqlContext;

        public ContactRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            return (await _sqlContext.Contacts.AddAsync(contact)).Entity;
        }

        public async Task<List<Contact>> GetAllContactsForUserAsync(string userId)
        {
            return await _sqlContext.Contacts
                .Include(u=>u.ContactUser)
                .Include(u => u.User)
                .Where(c => c.User.Id == userId).ToListAsync();
        }
    }
}
