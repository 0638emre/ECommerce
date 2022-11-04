namespace ECommerce.Application.Abstraction.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName{ get; }
    }
}
