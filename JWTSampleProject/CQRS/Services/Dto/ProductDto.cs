using JWTSampleProject.Infrastructure.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTSampleProject.Services.Dto
{
    public class ProductDto : IdSupportDto<int>
    {
        public int ID { get; set; }

        
    }
}
