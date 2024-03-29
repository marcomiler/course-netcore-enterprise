using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Application.Interface;

namespace PackageGroup.Ecommerce.WebApi.Controllers.v2
{
    [Authorize]
    //[Route("api/customer")]
    [Route("api/v{version:apiVersion}/customer")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _customerApplication;
        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region SÍNCRONOS
        [HttpPost("create")]
        public IActionResult Insert([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = _customerApplication.Insert(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update/{curtomerId}")]
        public IActionResult Update(string curtomerId, [FromBody] CustomerDTO customerDTO)
        {
            var customerDto = _customerApplication.Get(curtomerId);

            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            if (customerDTO == null) return BadRequest();

            var response = _customerApplication.Update(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Delete(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-by-id/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Get(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-all-with-pagination")]
        public IActionResult GetAllPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = _customerApplication.GetAllWithPagination(pageNumber, pageSize);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion


        #region ASÍNCRONOS
        [HttpPost("create-async")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.InsertAsync(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update-async/{customerId}")]
        public async Task<IActionResult> UpdateAsync(string curtomerId, [FromBody] CustomerDTO customerDTO)
        {
            var customerDto = _customerApplication.Get(curtomerId);

            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.UpdateAsync(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("delete-async/{customerIdAsync}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customerApplication.DeleteAsync(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-by-id-async/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customerApplication.GetAsync(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-all-async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-all-with-pagination-async")]
        public async Task<IActionResult> GetAllPaginationAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _customerApplication.GetAllWithPaginationAsync(pageNumber, pageSize);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
