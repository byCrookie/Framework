﻿using DependencyInjection.Microsoft.Modules;
using Framework.EntityFramework.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.EntityFramework.Access.Session;

internal class SessionModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(ISession), typeof(Session));
        
        base.Load(services);
    }
}