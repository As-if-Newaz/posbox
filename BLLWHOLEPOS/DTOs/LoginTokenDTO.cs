using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLWHOLEPOS.DTOs
{
    public class LoginTokenDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Key { get; set; }
        [Required]
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime? ExpiredAt { get; set; }

        [Required]
        public bool IsValid { get; set; }

        [Required]
        public int BusinessId { get; set; }
    }
}
