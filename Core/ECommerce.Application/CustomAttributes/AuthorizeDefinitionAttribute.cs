using ECommerce.Application.Enums;

namespace ECommerce.Application.CustomAttributes;

public class AuthorizeDefinitionAttribute
{
    public string Menu { get; set; }
    public string Definition { get; set; }
    public ActionType ActionType { get; set; }
}