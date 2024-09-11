using JWTSampleProject.Infrastructure.Base;

namespace JWTSampleProject.Models
{
    public class GenderDto : IdSupportDto<int>
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }

    }
}
