
// This will create service locator helper, and must be registered under startup.cs

/*
    USAGE:
    ServiceLocatorHelper.Current.GetInstance<ANYCLASSHERE>();
    
    REGISTRATION: [ must register at the very bottom of configure services ]
    ServiceLocatorHelper.SetLocatorProvider(services.BuildServiceProvider());
*/

public class ServiceLocatorHelper
{
    private ServiceProvider _currentServiceProvider;
    private static ServiceProvider _serviceProvider;

    public ServiceLocatorHelper(ServiceProvider currentServiceProvider)
    {
        _currentServiceProvider = currentServiceProvider;            
    }

    public static ServiceLocatorHelper Current => new ServiceLocatorHelper(_serviceProvider);

    public static void SetLocatorProvider(ServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object GetInstance(Type serviceType) => _currentServiceProvider.GetService(serviceType);

    public TService GetInstance<TService>() => _currentServiceProvider.GetService<TService>();

}
