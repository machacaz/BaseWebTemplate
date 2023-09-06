namespace Generic.Database.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public bool IsAPIUser { get; set; }

        public PlatypusLib.Enums.EntityStatus Status { get; set; }

        public virtual User? CreateUser { get; set; }

        public virtual User? UpdateCreateUser { get; set; } = null;

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public virtual Tenant? Tenant { get; set; }
    }
}