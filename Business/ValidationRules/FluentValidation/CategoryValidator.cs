using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez.");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakterli Olabilir.");
            RuleFor(c => c.CategoryName).MaximumLength(25).WithMessage("Kategori Adı En Fazla 25 Karakterli Olabilir.");
        }
    }
}
