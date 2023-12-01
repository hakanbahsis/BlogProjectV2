using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.UserService.Validation;
public class UserValidator:AbstractValidator<AppUser>
{
    public UserValidator()
    {
        RuleFor(c => c.FirstName)
           .NotEmpty()
           .MinimumLength(3)
           .MaximumLength(100)
           .WithName("Kullanıcı Adı");

        RuleFor(c => c.LastName)
           .NotEmpty()
           .MinimumLength(3)
           .MaximumLength(100)
           .WithName("Kullanıcı Soyadı");

        RuleFor(c => c.PhoneNumber)
           .NotEmpty()
           .MinimumLength(11)
           .MaximumLength(11)
           .WithName("Telefon Numarası");
        
        RuleFor(c => c.Email)
           .NotEmpty()
           .EmailAddress()
           .MinimumLength(11)
           .WithName("Email");
        
      
    }
}
