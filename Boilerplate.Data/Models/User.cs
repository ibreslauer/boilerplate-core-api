using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Data.Models
{
    public partial class User
    {
        public User()
        {
            UserToken = new HashSet<UserToken>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserToken> UserToken { get; set; }
    }
}
