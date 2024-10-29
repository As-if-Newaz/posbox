using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.EF.TableModels
{
    public class LoginToken
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Key { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ExpiredAt { get; set; }

        [Required]
        public bool IsValid { get; set; }
        public virtual Business Business { get; set; }
        [ForeignKey("Business")]
        [Required]
        public int BusinessId { get; set; }
    }
}
