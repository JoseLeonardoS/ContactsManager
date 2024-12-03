using ContactsManager.Models;
using ContactsManager.Models.DTOs;
using ContactsManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactInterface _contactInterface;

        public ContactController(IContactInterface contactInterface)
        {
            _contactInterface = contactInterface;
        }

        [HttpGet("listar-contatos")]
        public async Task<ActionResult<List<ContactModel>>> GetContacts()
        {
            var contacts = await _contactInterface.GetContacts();
            return Ok(contacts);
        }

        [HttpPost("criar-contato")]
        public async Task<ActionResult<List<ContactModel>>> CreateContact(CreateContactDTO cont)
        {
            var contacts = await _contactInterface.CreateContact(cont);
            return Ok(contacts);
        }

        [HttpPut("editar-contato/{cont.id}")]
        public async Task<ActionResult<List<ContactModel>>> UpdateContact(UpdateContactDTO cont)
        {
            var contacts = await _contactInterface.UpdateContact(cont);
            return Ok(contacts);
        }

        [HttpDelete("deletar-contato/{id}")]
        public async Task<ActionResult<List<ContactModel>>> DeleteContact(int id)
        {
            var contacts = await _contactInterface.DeleteContact(id);
            return Ok(contacts);
        }
    }
}
