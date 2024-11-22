using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.DTOs
{
    public class ReportDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BusinessName { get; set; }

        [Required]
        public int NetSell { get; set; }

        [Required]
        public int NetCost { get; set; }


        [Required]
        public int NetProfit { get; set; }


        [Required]
        public int SellNo { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [StringLength(50)]
        public string UpdatedBy { get; set; }


        public DateTime? UpdatedAt { get; set; }


        [StringLength(50)]
        public string DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }


        [Required]
        public int BusinessId { get; set; }
    }
}
