namespace PublishingHouse.Domain.Models.Repository
{
    public class JsonDataRepository(string filePath) : IDataRepository
    {
        private readonly string _filePath = filePath;

        public async Task SaveDataAsync(DataModel data)
        {
            var ser = new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };

            var jsonString = JsonConvert.SerializeObject(data, Formatting.Indented, ser);
            await File.WriteAllTextAsync(_filePath, jsonString);
        }

        public async Task<DataModel?> LoadDataAsync()
        {
            if (!File.Exists(_filePath)) return null;

            var ser = new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };

            var jsonString = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<DataModel>(jsonString, ser);
        }
    }
}
