using JWTSampleProject.Infrastructure.Base;

namespace JWTSampleProject.Models
{
    public class ReligionDto : IdSupportDto<int>
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }

    }
}
