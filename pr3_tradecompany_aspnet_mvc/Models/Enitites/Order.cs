using System.ComponentModel.DataAnnotations.Schema;

namespace pr3_tradecompany_aspnet_mvc.Models.Enitites
{
    public class Order
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("customer_id")] 
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("amount")]
        public double Amount { get; set; }
    }
}
