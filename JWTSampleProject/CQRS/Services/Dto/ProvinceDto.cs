using JWTSampleProject.Infrastructure.Base;

namespace JWTSampleProject.Models
{
    public class ProvinceDto : IdSupportDto<int>
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
