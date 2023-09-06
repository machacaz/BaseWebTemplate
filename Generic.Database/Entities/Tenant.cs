namespace Generic.Database.Entities
{
    using Generic.Database.Entities.BaseEntities.Interfaces;

    public class Tenant : IIdentifier
    {
        public int Id { get; set; }

        public Guid Identifier { get; set; }

        public required string TenantName { get; set; }

        public string TenantDescription { get; set; } = string.Empty;

        public required bool IsMainTenant { get; set; } = false;
    }
}
