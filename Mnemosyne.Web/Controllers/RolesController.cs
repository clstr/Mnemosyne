﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Web.Controllers
{
    public class RolesController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IRolesQueryService _rolesQueryService;

        public RolesController(IApplicationContext applicationContext, IRolesQueryService rolesQueryService)
        {
            _applicationContext = applicationContext;
            _rolesQueryService = rolesQueryService;
        }

        [HttpGet("all")]
        public IEnumerable<Roles> GetAllRoles() =>
            _applicationContext.Roles.All();
    }
}
