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
    public class TransferDTO
    {
        public int Id { get; set; }


        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime TransferTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Comment { get; set; }

        [Required]
        public int TransferCost { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }


        [Required]
        public int FromBusinessId { get; set; }


        [Required]
        public int ToBusinessId { get; set; }


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
