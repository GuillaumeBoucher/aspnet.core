using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Order Details")]
    public class OrderDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderDetailID { get; set; }

        [Column(Order = 1)]
        public long OrderID { get; set; }

        [Column(Order = 2)]
        public long ProductID { get; set; }

        public double Price { get; set; }
        public double Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
