namespace PublishingHouse.Domain.Models.Repository
{
    public enum RepositoryType
    {
        Xml,
        Json
    }

    public static class RepositoryTypeExtensions
    {
        public static string ToLowerString(this RepositoryType repositoryType)
        {
            return repositoryType.ToString().ToLower();
        }
    }

    public static class DataRepositoryFactory
    {
        public static IDataRepository CreateRepository(RepositoryType type, string filePath)
        {
            return type switch
            {
                RepositoryType.Json => new JsonDataRepository(filePath),
                RepositoryType.Xml => new XmlDataRepository(filePath),
                _ => throw new ArgumentException("Invalid repository type", nameof(type))
            };
        }
    }
}
