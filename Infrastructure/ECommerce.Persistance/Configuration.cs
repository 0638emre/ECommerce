using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace ECommerce.Persistance
{
    public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                #region Local
                /*
                 * aşağıdaki yorum satırındaki şekilde kendi makinamızda çalışabiliriz ancak.
                 * //ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerce.WebAPI"));//uygulama kendi makinamızda olduuğnda bu şekilde bir klasör dizinyapılanmasına gidebiliriz. fakat uygulama deploy olduğunda deploy olduğu klasör yalnızca 1 dir. bu sebeple bu şekilde bir path belirleyemeyiz.
                //configurationManager.AddJsonFile("appsettings.json");
                 */
                #endregion


                ConfigurationManager configurationManager = new();
                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerce.WebAPI"));
                    configurationManager.AddJsonFile("appsettings.json");

                }
                catch
                {
                    configurationManager.GetConnectionString("appsettings.Production.json");
                }

                return configurationManager.GetConnectionString("ECommerceDB");
            }
        }
    }
}
