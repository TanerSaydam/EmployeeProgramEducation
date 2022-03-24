using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidaiton
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(r=> r.Name).NotEmpty().WithMessage("Personel adı boş olamaz");
            RuleFor(r=> r.Name).MinimumLength(3).WithMessage("Personel adı en az 3 karakter olmalıdır");
            RuleFor(r => r.LastName).NotEmpty().WithMessage("Personel soyadı boş olamaz");
            RuleFor(r => r.LastName).MinimumLength(3).WithMessage("Personel soyadı en az 3 karakter olmalıdır");
            RuleFor(r => r.Salary).GreaterThan(0).WithMessage("Personel ücreti asgari ücretten büyük olmalıdır");
            RuleFor(r=> r.BirthDate).LessThan(DateTime.Now.AddYears(-18)).WithMessage("18 yaşından küçükler işe alınamaz");
            RuleFor(r => r.DepartmentId).GreaterThan(0).WithMessage("Personel bölümü seçmelisiniz");
            RuleFor(r => r.IdentityNumber).NotEmpty().WithMessage("Tc numarası 11 karakter olmalıdır ve boş olamaz").MinimumLength(11).WithMessage("Tc numarası 11 karakter olmalıdır ve boş olamaz").MaximumLength(11).WithMessage("Tc numarası 11 karakter olmalıdır ve boş olamaz");
        }
    }
}
