using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pr3_tradecompany_aspnet_mvc.Data;
using pr3_tradecompany_aspnet_mvc.Models;
using pr3_tradecompany_aspnet_mvc.Models.Enitites;

namespace pr3_tradecompany_aspnet_mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();

            return View(customers);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    CompanyName = viewModel.CompanyName,
                    Address = viewModel.Address,
                    Phone = viewModel.Phone
                };
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
            } 
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(updatedCustomer.Id);

            if (customer is not null)
            {
                customer.CompanyName = updatedCustomer.CompanyName;
                customer.Address = updatedCustomer.Address;
                customer.Phone = updatedCustomer.Phone;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer deletingCustomer)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == deletingCustomer.Id);
            if (customer is not null)
            {
                _context.Customers.Remove(deletingCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}
