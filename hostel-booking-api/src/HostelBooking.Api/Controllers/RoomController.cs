using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HostelBooking.Domain.AppService;
using HostelBooking.Domain.Repositories.Transaction;
using HostelBooking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace HostelBooking.Api.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomAppService _app;

        public RoomController(IRoomAppService app) 
        {
            _app = app;
        }

        [HttpGet]
        [Route("v1/rooms")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var rooms = _app.GetAll();
            return await Response(rooms, new[] { "Room Get Ok." });

        }

        [HttpPost]
        [Route("v1/rooms")]
        public async Task<IActionResult> Post([FromBody]Room room)
        {
            _app.Save(room);
            return await Response("", new[] { "Room Save Ok." });
        }

        [HttpPut]
        [Route("v1/rooms")]
        public async Task<IActionResult> Put([FromBody]Room room)
        {
            _app.Update(room);
            return await Response("", new[] { "Room Update Ok." });
        }

        [HttpDelete]
        [Route("v1/rooms")]
        public async Task<IActionResult> Delete([FromBody]Room room)
        {
            _app.Delete(room);
            return await Response("", new[] { "Room Delete Ok." });
        }
    }
}
