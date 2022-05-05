using CurrencyData.Models.DataObjects;
using CurrencyData.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CurrencyData.Controllers
{
    [Controller]
    [Route("{controller}/{action}")]
    public class CurrencyController : Controller
    {
        public readonly CurrencyService _service;

        public CurrencyController(CurrencyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var allCurrencyData = await _service.GetAllCurrencyDataAsync();

            if(allCurrencyData == null)
                return View("Index");

            return View(allCurrencyData);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrency(string key)
        {            
            var currencyInfo = await _service.GetCurrencyByKeyAsync(key);
            return View(currencyInfo);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
