using FinancialManagement.Controllers.Dtos;
using FinancialManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FinancialManagementController : ControllerBase
    {
        private readonly IFinancialManagementService _financialManagementService;
        public FinancialManagementController(IFinancialManagementService financialManagementService)
        {
            _financialManagementService = financialManagementService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ExpensesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var expenses = await _financialManagementService.GetAll();

            return expenses.Any()
                ? Ok(expenses)
                : NoContent();
        }

        [ProducesResponseType(typeof(ExpensesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(ExpensesDto expenses)
        {
            return Ok(await _financialManagementService.Create(expenses));
        }

        [HttpGet("GetTotalExpensesValue")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTotalExpensesValue()
        {
            return Ok(await _financialManagementService.GetTotalExpensesValue());
        }
    }
}

