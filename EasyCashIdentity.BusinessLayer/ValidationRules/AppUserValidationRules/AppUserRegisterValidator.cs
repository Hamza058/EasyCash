using EashCashIdentity.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCashIdentity.DtoLayer.Dtos.AppUserDtos;

namespace EasyCashIdentity.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter girebilirsiniz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girebilirsiniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş geçilmez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar Eşleşmemektedir");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        }
    }
}
