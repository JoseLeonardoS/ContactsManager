using ContactsManager.Models;
using ContactsManager.Models.DTOs;
using ContactsManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactInterface _contactInterface;

        public ContactController(IContactInterface contactInterface)
        {
            _contactInterface = contactInterface;
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<ActionResult<List<ContactModel>>> GetContacts()
        {
            var contacts = await _contactInterface.GetContacts();
            return Ok(contacts);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<List<ContactModel>>> CreateContact(CreateContactDTO cont)
        {
            var contacts = await _contactInterface.CreateContact(cont);
            return Ok(contacts);
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task<ActionResult<List<ContactModel>>> UpdateContact(UpdateContactDTO cont)
        {
            var contacts = await _contactInterface.UpdateContact(cont);
            return Ok(contacts);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<List<ContactModel>>> DeleteContact(int id)
        {
            var contacts = await _contactInterface.DeleteContact(id);
            return Ok(contacts);
        }
    }
}
