using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using TocantinsPay.Application.Validators;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(c =>
            {
                c.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            });

            services.AddValidatorsFromAssemblyContaining<CadastrarClienteValidator>();

            return services;
        }

        public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
        {
            public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
            {
                return new BadRequestObjectResult(
                    new RespostaPadraoViewModel(
                        context
                            .ModelState.SelectMany(ms => ms.Value?.Errors ?? [])
                            .Select(e => e.ErrorMessage)
                    )
                );
            }
        }
    }
}
