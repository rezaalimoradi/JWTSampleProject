namespace JWTSampleProject.Infrastructure.Base
{
    public interface IAPIHandler<TRequest,TResponse> where TRequest : IAPIResult<TResponse>
    {
        public TResponse Handle(TRequest inputModel);
    }
}
