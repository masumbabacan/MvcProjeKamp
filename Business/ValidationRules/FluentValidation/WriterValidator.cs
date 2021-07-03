using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez.");
            RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("Kullanıcı Adı En Az 2 Karakterli Olabilir.");
            RuleFor(w => w.WriterName).MaximumLength(50).WithMessage("Kullanıcı Adı En Fazla 50 Karakterli Olabilir.");

            RuleFor(w => w.WriterSurName).NotEmpty().WithMessage("Kullanıcı Soyadı Boş Geçilemez.");
            RuleFor(w => w.WriterSurName).MinimumLength(2).WithMessage("Kullanıcı Soyadı En Az 2 Karakterli Olabilir.");
            RuleFor(w => w.WriterSurName).MaximumLength(50);

            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(w => w.WriterMail).MaximumLength(50).WithMessage("Mail en fazla 50 karakter olabilir.");

            RuleFor(w => w.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez.");
            RuleFor(w => w.WriterAbout).MaximumLength(100).WithMessage("Hakkında kısmı en fazla 100 karakter olabilir.");

            RuleFor(w => w.WriterTitle).NotEmpty().WithMessage("Ünvan Boş Geçilemez.");
        }
    }
}
