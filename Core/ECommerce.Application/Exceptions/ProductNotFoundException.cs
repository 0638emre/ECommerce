namespace ECommerce.Application.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Ürün bulunamadı.")
        {

        }
        public ProductNotFoundException(string? message) : base(message)
        {

        }
        public ProductNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
