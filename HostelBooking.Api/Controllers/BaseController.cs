﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HostelBooking.Domain.Repositories.Transaction;

namespace HostelBooking.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUoW _uow;

        public BaseController(IUoW uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<string> notifications)
        {
            if (notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    // Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }

    }
}
