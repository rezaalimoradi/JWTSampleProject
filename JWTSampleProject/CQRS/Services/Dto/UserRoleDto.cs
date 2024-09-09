using JWTSampleProject.Infrastructure.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTSampleProject.Services.Dto
{
    public class UserRoleDto : IdSupportDto<int>
    {
        public int UserRoleId { get; set; }

        
    }
}
