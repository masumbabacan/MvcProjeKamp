using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(c => c.UserMail).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılabilir");

            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(c => c.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılabilir");

            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(c => c.UserName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılabilir");

            RuleFor(c => c.Message).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(c => c.Message).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılabilir");
        }
    }
}
