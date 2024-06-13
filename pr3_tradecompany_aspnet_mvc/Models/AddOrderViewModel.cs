using pr3_tradecompany_aspnet_mvc.Models.Enitites;
using System.ComponentModel.DataAnnotations.Schema;

namespace pr3_tradecompany_aspnet_mvc.Models
{
    public class AddOrderViewModel
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
