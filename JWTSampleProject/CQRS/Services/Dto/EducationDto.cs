using JWTSampleProject.Infrastructure.Base;

namespace JWTSampleProject.Models
{
    public class EducationDto : IdSupportDto<int>
    {
        public int EducationId { get; set; }
        public string EducationName { get;}
    }
}
