using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiorellaBackToFrontProject.Controllers;
using FiorellaBackToFrontProject.DataAccessLayer;
using FiorellaBackToFrontProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FiorellaBackToFrontProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = 0;
            var basket = Request.Cookies["basket"];
           
            if (!string.IsNullOrEmpty(basket))
            {
                var products = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);
                count = products.Count;
            }
            ViewBag.BasketCount = count;
            //var products2 = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);
            //double totalAmount = 0;

            //foreach (var amount in products2)
            //{
            //    totalAmount += amount.Count * amount.Price;
            //    ViewBag.totalamount = totalAmount;
            //}

            var bio = await _dbContext.Bios.SingleOrDefaultAsync();
            return View(bio);
        }
    }
}
