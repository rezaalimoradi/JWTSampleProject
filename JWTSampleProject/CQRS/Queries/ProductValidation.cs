using FluentValidation;
using JWTSampleProject.CQRS.InputModel;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProductValidation : AbstractValidator<ProductQueryInputModel>
    {
        public ProductValidation() 
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Name Is Empty");
        }
    }
}
