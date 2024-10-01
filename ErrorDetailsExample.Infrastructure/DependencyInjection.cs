﻿using ErrorDetailsExample.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorDetailsExample.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}