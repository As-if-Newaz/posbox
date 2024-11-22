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
    public class TransactionDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        [Required]
        public DateTime TransactionTime { get; set; }

        [Required]
        public int Amount { get; set; }

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


        [Required]
        public int BusinessId { get; set; }
    }
}
