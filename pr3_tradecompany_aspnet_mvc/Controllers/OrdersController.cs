using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pr3_tradecompany_aspnet_mvc.Data;
using pr3_tradecompany_aspnet_mvc.Models;
using pr3_tradecompany_aspnet_mvc.Models.Enitites;

namespace pr3_tradecompany_aspnet_mvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            foreach (var order in orders)
            {
                order.Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == order.CustomerId);
            }
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == order.CustomerId);

            return View(order);
        }

        //private void PopulateCustomerList()
        //{
        //    IEnumerable<SelectListItem> customers =
        //        _context.Customers.Select(i => new SelectListItem
        //        {
        //            Text = i.CompanyName,
        //            Value = i.Id.ToString()
        //        });
        //    ViewBag.CustomersList= customers;
        //}
        [HttpGet]
        public IActionResult Add()
        {
            SelectList customers = new SelectList(_context.Customers, "Id", "CompanyName");
            ViewBag.Customers = customers;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddOrderViewModel viewModel)
        {
            var order = new Order
            {
                CustomerId = viewModel.CustomerId,
                Date = viewModel.Date,
                Amount = viewModel.Amount
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var order = await _context.Orders.FindAsync(id);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Order updatedOrder)
        {
            var order = await _context.Orders.FindAsync(updatedOrder.Id);

            if (order is not null)
            {
                order.Customer = updatedOrder.Customer;
                order.Date = updatedOrder.Date;
                order.Amount = updatedOrder.Amount;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Orders");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Order deletingOrder)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == deletingOrder.Id);
            if (order is not null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Orders");
        }
    }
}
