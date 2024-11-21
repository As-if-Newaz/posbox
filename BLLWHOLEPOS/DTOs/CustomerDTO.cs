﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int Due { get; set; }

        [Required]
        [StringLength(50)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

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