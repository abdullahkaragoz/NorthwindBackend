using FluentValidation;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
              RuleFor(r=>r.ProductName).NotEmpty(); 
              RuleFor(r=>r.ProductName).Length(2,30); 
              RuleFor(r=>r.ProductName).Must(StartWithWithA); 

              RuleFor(r=>r.UnitPrice).NotEmpty(); 
              RuleFor(r=>r.UnitPrice).GreaterThanOrEqualTo(1); 
              RuleFor(r=>r.UnitPrice).GreaterThanOrEqualTo(1).When(c=>c.CategoryId == 1);
            

        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
