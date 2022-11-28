namespace ECommerce.Application.Abstraction.Token
{
    //burada token ve refresh token üretiminden sorumlu servisin interfaceini yapıyoruz.
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute);
    }
}
