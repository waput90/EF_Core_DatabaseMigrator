// dotnet net core configure service
public void ConfigureServices(IServiceCollection services)
{
      ...
      // must registered at the very bottom of the configure service
      ServiceLocatorHelper.SetLocatorProvider(services.BuildServiceProvider());
}

