namespace Generic.Database.Entities.BaseEntities
{
    using Generic.Database.Entities;
    using Generic.Database.Entities.BaseEntities.Interfaces;


    public class BaseEntity : IIdentifier
    {
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        public PlatypusLib.Enums.EntityStatus Status { get; set; }

        public virtual User? CreateUser { get; set; }

        public virtual User? UpdateCreateUser { get; set; } = null;

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}