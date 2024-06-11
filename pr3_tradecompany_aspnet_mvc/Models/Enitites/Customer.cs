using System.ComponentModel.DataAnnotations.Schema;

namespace pr3_tradecompany_aspnet_mvc.Models.Enitites
{
    public class Customer
    {
        [Column("id")]
        public Guid Id { get; set; } 

        [Column("company_name")]
        public string? CompanyName { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }
    }
}
