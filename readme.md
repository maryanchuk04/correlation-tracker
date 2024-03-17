# Correlation Tracker 

**Glory for Ukraine!** 

**Created by: Maksym Marianchuk**


> A Nuget package that allows you to add RequestCorrelationId to the Header and also adds this ID to the LogContext, which makes it easy to filter Logs by this value

How to use:

1. In terminal or powershall

```
dotnet add package CorrelationTracking --version 0.0.2
```

2. Go to Program.cs 

 -  for .NET 6 and higher
```

using CorrelationTracking.Extensions;

// ****************************************
// Configure services
// ****************************************
builder.Services.AddCorrelationIdTrackingServices();

// All other services...

app.UseCorrelationIdTrackingMiddleware();
```

- for .NET app with Startup.cs class

```
using CorrelationTracking.Extensions;

// in configure services method

public void ConfigureServices(IServiceCollection services) 
{
    services.AddCorrelationIdTrackingServices();
    
    // other services...
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseCorrelationIdTrackingMiddleware();
}

```

You don't need anything else! 
If you want to use services (``IRequestCorrelationWritter``, ``IRequestCorrelationReader``) you can simply enable them with Dependency Injection

Thanks!