using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SignupValidator : AbstractValidator<Admin>
    {
        public SignupValidator()
        {
            RuleFor(x => x.AdminUserName).EmailAddress().WithMessage("@gmail.com alanını ekleyiniz...");
        }
    }
}
