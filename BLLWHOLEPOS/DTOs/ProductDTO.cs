using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        [StringLength(50)]
        public string CostCode { get; set; }

        [Required]
        public int Stock { get; set; }


        [StringLength(50)]
        public string Barcode { get; set; }

        [Required]
        public DateTime AddingDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }


        [StringLength(100)]
        public string Comment { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [StringLength(50)]
        public string UpdatedBy { get; set; }


        public DateTime? UpdatedAt { get; set; }


        [StringLength(50)]
        public string DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
