using DALWHOLEPOS.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.DTOs
{
    public class QuickSellDTO
    {
        public int Id { get; set; }

        public virtual Invoice Invoice { get; set; }
        [ForeignKey("Invoice")]
        [Required]
        public int InvoiceId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ProductName { get; set; }

        public virtual Customer Customer { get; set; }
        [ForeignKey("Customer")]
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }


        public DateTime? UpdatedAt { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
