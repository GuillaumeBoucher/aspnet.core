using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Company")]
    public class Company
    {

        public Company()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyID { get; set; }

        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        public string Web { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public virtual AddressType Address { get; set; }

        [InverseProperty(nameof(Order.Company))]
        public virtual ICollection<Order> Orders { get; set; }

        [InverseProperty(nameof(Order.ShipCompany))]
        public virtual ICollection<Order> ShippedOrders { get; set; }

        [InverseProperty(nameof(PersonContact.Companies))]
        public virtual PersonContact PrimaryContact { get; set; }

        [InverseProperty(nameof(PersonContact.Company))]
        public virtual ICollection<PersonContact> Contacts { get; set; }

    }
}
