using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Orders")]
    public class Order
    {

        public Order()
        {

            OrderDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public double Freight { get; set; }
        public DateTime? ShipDate { get; set; }
        public Double Discount { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [InverseProperty("Orders")]
        public virtual PersonContact PersonContact { get; set; }

        public virtual Company Company { get; set; }

        public virtual Company ShipCompany { get; set; }
    }
}
