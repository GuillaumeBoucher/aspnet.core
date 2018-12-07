using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("AddressType")]
    public class AddressType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(120)]
        public string AddressTitle { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(20)]
        public string Region { get; set; }

        [MaxLength(15)]
        public string PostalCode { get; set; }

        [MaxLength(20)]
        public string Country { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }

        [MaxLength(25)]
        public string Fax { get; set; }
    }
}
