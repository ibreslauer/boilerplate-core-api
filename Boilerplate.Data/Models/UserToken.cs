using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Data.Models
{
    public partial class UserToken
    {
        [Key]
        public long UserId { get; set; }
        [Required]
        [StringLength(850)]
        public string Token { get; set; }
        [Required]
        [StringLength(100)]
        public string DeviceId { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserToken")]
        public virtual User User { get; set; }
    }
}
