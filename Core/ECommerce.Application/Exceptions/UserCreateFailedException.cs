namespace ECommerce.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("Kullanıcı oluşturulurken beklenmeyen hata oluştu.")
        {
            
        }

        public UserCreateFailedException(string? message) : base(message)
        {
                
        }
        
        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
                
        }
    }
}
