using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierManagementSystem.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? createdAt { get; set; }
        [MaxLength(120)]
        public string? createdBy { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(120)]
        public string? updatedBy { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Code { get; set; }
        public int? userTypeId { get; set; }
        public int? isActive { get; set; }
        [MaxLength(120)]
        public string? org { get; set; }
    }
}
