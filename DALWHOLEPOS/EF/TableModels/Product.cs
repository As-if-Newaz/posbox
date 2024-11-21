﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.EF.TableModels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string CostCode { get; set; }

        [Required]
        public int Stock {  get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Barcode { get; set; }

        [Required]
        public DateTime AddingDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Comment { get; set; }

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

        public virtual Supplier Supplier { get; set; }
        [ForeignKey("Supplier")]
        [Required]
        public int SupplierId { get; set; }



    }
}
