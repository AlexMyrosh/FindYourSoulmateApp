using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IContactRepository
    {
        public Task<Contact> AddAsync(Contact contact);

        public Task<List<Contact>> GetAllContactsForUserAsync(string userId);
    }
}
