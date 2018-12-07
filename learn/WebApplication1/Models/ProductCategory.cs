using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryID { get; set; }

        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }

        public virtual ProductCategory ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ChildCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

}
