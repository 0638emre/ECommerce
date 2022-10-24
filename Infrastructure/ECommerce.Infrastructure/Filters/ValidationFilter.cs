using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Filters
{
    //bu bir servistir bu sebeple infrastructer katmanında bulunmaktadır.
    //bu servis fluent validation ile devreye soktuğumuz validationları manuel olarak tamamen bizim kontrolümüz altına alan class tır.
    public class ValidationFilter : IAsyncActionFilter
    {
        //her filter kendi içerisinde bu fonksiyonu çalıştıracaktır ve her gelen istek buraya kesinlikle girecektir
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();
                context.Result = new BadRequestObjectResult(errors);

                return;
            }
            await next();
        }
    }
}
