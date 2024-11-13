namespace PublishingHouse.Domain.Models.Repository
{
    public interface IDataRepository
    {
        Task SaveDataAsync(DataModel data);

        Task<DataModel?> LoadDataAsync();
    }
}
