using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using DAL.Model;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class SweetsController : ControllerBase
    {

        IitemBAL itemsBL;
        public SweetsController(IitemBAL _itemsBL)
        {
            itemsBL = _itemsBL;
        }
        // GET api/values
        [HttpGet("GetAllItems")]
        public async Task<ActionResult<List<Item>>> GetAllItems()
        {
            return await itemsBL.GetAllItems();
        }
        // put api/values
        [HttpPut("UpdateItems/{id}/{price}")]
        public async Task<ActionResult<List<Item>>> UpdateItems(long  id, int price)
        {
            return await itemsBL.UpdateItems(id, price);
        }
        // GET api/values
        [HttpGet("findById/{id}")]
        public async Task<ActionResult<List<Item>>> findById(long id)
        {
            return await itemsBL.findById(id);
        }
        [HttpGet("findByName/{name}")]
        public async Task<ActionResult<List<Item>>> findByName(string name)
        {
            return await itemsBL.findByName(name);
        }
        [HttpGet("findBySupleir/{Supleir}")]
        public async Task<ActionResult<List<Item>>> findBySupleir(string Supleir)
        {
            return await itemsBL.findBySupleir(Supleir);
        }

    }
}
