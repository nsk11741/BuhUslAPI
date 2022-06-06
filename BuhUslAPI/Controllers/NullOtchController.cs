using BuhUsl;
using BuhUsl.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BuhUslAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NullOtchController : ControllerBase
	{


		public ClientDetailViewModel Client { get; set; }
		public IEnumerable<ClientSummaryViewModel> Clients { get; private set; }
		private readonly ClientService _service;

		public NullOtchController(ClientService service)
		{
			_service = service;
		}

		// GET: api/<NullOtchController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			Clients = await _service.GetClients();
			if (Clients is null)
			{
				return NotFound();
			}
			return new JsonResult(Clients);
		}

		// GET api/<NullOtchController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			Client = await _service.GetClientDetail(id);
			if (Client is null)
			{
				return NotFound();
			}
			return new JsonResult(Client);
		}

		// POST api/<NullOtchController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateClientCommand Input)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var id = await _service.CreateClient(Input);

			return Ok();

		}


	}
}
