using JWTSampleProject.Infrastructure.Base;

namespace JWTSampleProject.Models
{
    public class CountryDto : IdSupportDto<int>
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
}
