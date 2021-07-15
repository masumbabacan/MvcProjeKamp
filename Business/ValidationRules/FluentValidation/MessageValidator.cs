using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");
            RuleFor(m => m.ReceiverMail).EmailAddress().WithMessage("Lütfen geçerli bir email giriniz");

            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(m => m.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılabilir");

            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(m => m.MessageContent).MinimumLength(3).WithMessage("En az 3 karakter girişi yapılabilir");

        }
    }
}
