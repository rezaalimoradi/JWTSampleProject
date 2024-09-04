using JWTSampleProject.Infrastructure.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTSampleProject.Services.Dto
{
    public class UserDto : IdSupportDto<int>
    {
        public int ID { get; set; }

        
    }
}
