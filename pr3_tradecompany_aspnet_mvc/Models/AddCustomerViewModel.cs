using System.ComponentModel.DataAnnotations.Schema;

namespace pr3_tradecompany_aspnet_mvc.Models
{
    public class AddCustomerViewModel
    { 
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
