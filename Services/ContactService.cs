using ContactsManager.Data;
using ContactsManager.Models;
using ContactsManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Services
{
    public class ContactService : IContactInterface
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ContactModel>>> GetContacts()
        {
            ResponseModel<List<ContactModel>> response = new ResponseModel<List<ContactModel>>();

            try
            {
                var contacts = await _context.Contacts.ToListAsync();

                response.Data = contacts;
                response.Message = "Contacts listed!";
                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ContactModel>>> CreateContact(CreateContactDTO cont)
        {
            ResponseModel<List<ContactModel>> response = new ResponseModel<List<ContactModel>>();

            try
            {
                var contact = new ContactModel()
                {
                    Name = cont.Name,
                    Email = cont.Email,
                    Phone = cont.Phone,
                    Img = cont.Img
                };

                _context.Add(contact);
                await _context.SaveChangesAsync();

                response.Data = await _context.Contacts.ToListAsync();
                response.Message = "Contact created successfully";
                return response;

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ContactModel>>> UpdateContact(UpdateContactDTO cont)
        {
            ResponseModel<List<ContactModel>> response = new ResponseModel<List<ContactModel>>();

            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x=> x.Id == cont.Id);

                if (contact == null)
                {
                    response.Data = await _context.Contacts.ToListAsync();
                    response.Message = "Contact not found";
                    return response;
                }

                contact.Name = cont.Name;
                contact.Email = cont.Email;
                contact.Phone = cont.Phone;
                contact.Img = cont.Img;

                _context.Update(contact);
                await _context.SaveChangesAsync();

                response.Data = await _context.Contacts.ToListAsync();
                response.Message = "Contact edited successfully";
                return response;

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ContactModel>>> DeleteContact(int id)
        {
            ResponseModel<List<ContactModel>> response = new ResponseModel<List<ContactModel>>();

            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);

                if(contact == null)
                {
                    response.Data = await _context.Contacts.ToListAsync();
                    response.Message = "Contact not found";
                    return response;
                }

                _context.Remove(contact);
                await _context.SaveChangesAsync();

                response.Data= await _context.Contacts.ToListAsync();
                response.Message = "Contact deleted successfully";
                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
