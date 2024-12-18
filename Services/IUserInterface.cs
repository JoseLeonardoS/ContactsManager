using ContactsManager.Models;
using ContactsManager.Models.DTOs;

namespace ContactsManager.Services
{
    public interface IUserInterface
    {
        public Task<string> Regiter(UserModel user);
        public Task<string> Login(LoginDto login);
        public Task<List<UserModel>> ListUsers();
    }
}
