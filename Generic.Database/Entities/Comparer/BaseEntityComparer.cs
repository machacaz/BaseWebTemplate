namespace Generic.Database.Entities.Comparer
{
    using Generic.Database.Entities.BaseEntities;
    using System.Diagnostics.CodeAnalysis;


    internal class BaseEntityComparer<T> : IEqualityComparer<T> where T : BaseEntity
    {
        public bool Equals(T? x, T? y)
        {
            return x?.Identifier == y?.Identifier;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}