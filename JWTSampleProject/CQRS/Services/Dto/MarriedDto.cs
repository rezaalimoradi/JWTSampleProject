using JWTSampleProject.Infrastructure.Base;

namespace JWTSampleProject.Models
{
    public class MarriedDto : IdSupportDto<int>
    {
        public int MarriedId { get; set; }
        public string MarriedName { get; set; }
    }
}
