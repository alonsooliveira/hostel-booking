using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostelBooking.Domain.Repositories.Transaction;
using HostelBooking.Domain.AppService;
using Microsoft.AspNetCore.Mvc;
using HostelBooking.Domain.Entities;

namespace HostelBooking.Api.Controllers
{
    public class GuestController : BaseController
    {
        private readonly IGuestAppService _app;

        public GuestController(IGuestAppService app) 
        {
            _app = app;
        }

        [HttpGet]
        [Route("v1/guests/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await Response(_app.Get(id), new[] { "Guest Get Ok." });
        }

        [HttpPost]
        [Route("v1/guests")]
        public async Task<IActionResult> Post([FromBody]Guest guest)
        {
            _app.Save(guest);
            return await Response("", new[] { "Guest Save Ok." });
        }

        [HttpPut]
        [Route("v1/guests")]
        public async Task<IActionResult> Put([FromBody]Guest guest)
        {
            _app.Update(guest);
            return await Response("", new[] { "Guest Update Ok." });
        }
    }
}
