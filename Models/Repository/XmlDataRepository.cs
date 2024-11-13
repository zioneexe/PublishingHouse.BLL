using System.Runtime.Serialization;

namespace PublishingHouse.Domain.Models.Repository
{
    public class XmlDataRepository(string filePath) : IDataRepository
    {
        private readonly string _filePath = filePath;

        public async Task SaveDataAsync(DataModel data)
        {
            var formatter = new DataContractSerializer(typeof(DataModel));
            await using var s = new FileStream(_filePath, FileMode.Create);
            formatter.WriteObject(s, data);
        }

        public async Task<DataModel?> LoadDataAsync()
        {
            if (!File.Exists(_filePath)) return null;

            var formatter = new DataContractSerializer(typeof(DataModel));
            await using var s = new FileStream(_filePath, FileMode.Open);
            return formatter.ReadObject(s) as DataModel;
        }
    }
}
