using MediatR;
using System.Diagnostics;

namespace JWTSampleProject.Behaviors
{
    //چک کردن api ها که چه زمانی طول میکشد تا جواب دهند جهت بهینه سازی
    public class PerformanceHelperBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var response = await next();
            stopwatch.Stop();
            if(stopwatch.ElapsedMilliseconds > 2000)
            {
                Console.WriteLine("API : " + request.GetType().Name + " Lapsed : " + stopwatch.ElapsedMilliseconds.ToString() + "milisecond");
            }
            return response;

        }
    }
}
