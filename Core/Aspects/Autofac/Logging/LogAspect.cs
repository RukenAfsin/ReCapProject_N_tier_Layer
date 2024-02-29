using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Serilog;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class LogAspect : MethodInterception
{
    private readonly ILogger _logger;

    public LogAspect()
    {
        _logger = Log.ForContext<LogAspect>();
    }

    public override void Intercept(IInvocation invocation)
    {
        try
        {
            _logger.Information("Method {MethodName} is starting.", invocation.Method.Name);
            invocation.Proceed(); // Metodu çağır
            _logger.Information("Method {MethodName} has finished.", invocation.Method.Name);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred in method {MethodName}", invocation.Method.Name);
            throw; // Hata yeniden fırlat
        }
    }
}
