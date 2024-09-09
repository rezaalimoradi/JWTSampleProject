using FluentValidation;
using JWTSampleProject.CQRS.InputModel;

namespace JWTSampleProject.ControllerFilters
{
    public class ProductValidation : AbstractValidator<ProductQueryInputModel>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName Is Empty");
        }
    }

    public class RoleValidation : AbstractValidator<RoleQueryInputModel>
    {
        public RoleValidation()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("RoleName Is Empty");
        }
    }
}
