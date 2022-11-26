namespace ECommerce.Application.Exceptions
{
    public  class NotFoundUserException : Exception
    {
        public NotFoundUserException() : base("Kullanıcı adı veya parola hatalı")
        {
            
        }

        public NotFoundUserException(string? message) : base(message)
        {
            
        }

        public NotFoundUserException(string? message, Exception? innException) : base(message, innException) 
        {
            
        }
    }
}
