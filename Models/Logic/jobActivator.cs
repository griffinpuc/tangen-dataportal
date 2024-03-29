﻿using System;

public class jobActivator : Hangfire.JobActivator
{
    private readonly IServiceProvider _serviceProvider;

    public jobActivator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public override object ActivateJob(Type type)
    {
        return _serviceProvider.GetService(type);
    }
}