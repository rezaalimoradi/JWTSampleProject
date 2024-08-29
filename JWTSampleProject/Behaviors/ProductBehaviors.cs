using MediatR;

namespace JWTSampleProject.Behaviors
{
    public class ProductBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Befor Response");
            //کارهائی که قبل از درخواست انجام می شود
            var response = await next();
            //کارهائی که بعد از درخواست انجام می شود
            Console.WriteLine("After Response");
            return response;
        }
    }
}
