using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;

namespace Mnemosyne.Web.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        private readonly IApplicationContext _applicationContext;
        private readonly ICategoriesQueryService _categoriesQueryService;

        public CategoriesController(IApplicationContext applicationContext,
                                    ICategoriesQueryService categoriesQueryService)
        {
            _applicationContext = applicationContext;
            _categoriesQueryService = categoriesQueryService;
        }

        [HttpGet("all")]
        public IEnumerable<Categories> GetAllRoles() =>
            _applicationContext.Categories.All();
    }
}
