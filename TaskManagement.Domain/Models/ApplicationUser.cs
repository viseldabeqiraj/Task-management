using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Domain.Models
{
    public class ApplicationUser : IdentityUser, IAuditableEntity
    {
        public string FullName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }

}
