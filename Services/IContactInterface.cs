using ContactsManager.Models;
using ContactsManager.Models.DTOs;

namespace ContactsManager.Services
{
    public interface IContactInterface
    {
        public Task<ResponseModel<List<ContactModel>>> GetContacts();
        public Task<ResponseModel<List<ContactModel>>> CreateContact(CreateContactDTO cont);
        public Task<ResponseModel<List<ContactModel>>> UpdateContact(UpdateContactDTO cont);
        public Task<ResponseModel<List<ContactModel>>> DeleteContact(int id);
    }
}
