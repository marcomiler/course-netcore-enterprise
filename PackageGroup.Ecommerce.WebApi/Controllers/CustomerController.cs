using Microsoft.AspNetCore.Mvc;
using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Application.Interface;

namespace PackageGroup.Ecommerce.WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _customerApplication;
        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region SÍNCRONOS
        [HttpPost]
        public IActionResult Insert([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = _customerApplication.Insert(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = _customerApplication.Update(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Delete(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Get(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion


        #region ASÍNCRONOS
        [HttpPost("insert-async")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.InsertAsync(customerDTO);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("update-async")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerDTO customerDTO)
        {
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

        [HttpGet("get-async/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customerApplication.GetAsync(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("get-async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
