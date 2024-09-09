using JWTSampleProject.Infrastructure.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTSampleProject.Services.Dto
{
    public class RoleDto : IdSupportDto<int>
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
