using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Services;
using Mnemosyne.ViewModels;

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

        [HttpGet]
        public IEnumerable<Categories> GetCategories() =>
            _applicationContext.Categories.All();

        #region CRUD Operations
        [HttpPost]
        public async Task<ActionResult<Categories>> CreateCategory(CategoriesViewModel categoriesViewModel)
        {
            var category = new Categories(categoriesViewModel.Category);
            _applicationContext.Categories.Add(category);
            await _applicationContext.CommitAsync();

            return CreatedAtAction(nameof(category), category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> ReadCategory(int id)
        {
            var category = await _applicationContext.Categories.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categories>> UpdateCategory(int id, CategoriesViewModel categoriesViewModel)
        {
            if (id != categoriesViewModel.Id)
            {
                return BadRequest(id);
            }

            var category = await _applicationContext.Categories.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            // Update our entity model
            category.Update(categoriesViewModel.Category);

            // Stage our entity
            _applicationContext.Categories.Update(category);

            // Commit changes to Db
            await _applicationContext.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> DeleteCategory(int id)
        {
            var category = await _applicationContext.Categories.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            _applicationContext.Categories.Delete(category);
            await _applicationContext.CommitAsync();

            return NoContent();
        }
        #endregion
    }
}
