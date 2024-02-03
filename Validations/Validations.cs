using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Entities;
using FluentValidation;

namespace WebShopInc.Validations;

public class ProductValidator : AbstractValidator<ProductModel>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name).NotEmpty().MaximumLength(50);
        RuleFor(product => product.Description).NotEmpty().MaximumLength(200);
        RuleFor(product => product.Unit).MaximumLength(10);
    }
}
