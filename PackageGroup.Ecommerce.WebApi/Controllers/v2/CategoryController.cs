using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.Application.Main;

namespace PackageGroup.Ecommerce.WebApi.Controllers.v2
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/category")]
    [ApiVersion("2.0")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;
        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpGet("get-all-async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _categoryApplication.GetAll();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
