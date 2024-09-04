namespace JWTSampleProject.Infrastructure.Base
{
    public class IdTitleSupportDto<TIdType> 
    {
        public TIdType ID {  get; set; }

        public string Title { get; set; }
    }
}
