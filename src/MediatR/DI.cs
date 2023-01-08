/*
 * DI.cs
 *
 *   Created: 2022-12-30-04:57:17
 *   Modified: 2022-12-30-04:57:17
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

using System.Reflection;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatR<T>(this IServiceCollection services)
    {
        services.AddMediatR(typeof(T).Assembly);
        return services;
    }
#if NET6_0_OR_GREATER
    public static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR();
        return builder;
    }
#endif
}
