using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PS.NodeManagerFintech.Application.Mappings;
using PS.NodeManagerFintech.Application.Services.Interfaces;
using PS.NodeManagerFintech.Application.Services;
using PS.NodeManagerFintech.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace PS.NodeManagerFintech.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITreeService, TreeService>();
            services.AddScoped<ITreeNodeService, TreeNodeService>();
            services.AddScoped<IExceptionLogger, ExceptionLogger>();

            services.AddValidatorsFromAssemblyContaining<CreateTreeNodeRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateTreeRequestValidator>();

            services.AddFluentValidationAutoValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
            });

            TypeAdapterConfig.GlobalSettings.Scan(typeof(TreeMappingConfig).Assembly);

            return services;
        }
    }
}
