﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.EF.TableModels
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Reason { get; set; }

        [Required]
        public DateTime TransactionTime { get; set; }

        [Required]
        public int Amount { get; set; }

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

        public virtual Business Business { get; set; }
        [ForeignKey("Business")]
        [Required]
        public int BusinessId { get; set; }

    }
}
