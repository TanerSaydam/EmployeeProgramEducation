using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidaiton
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Bölüm adı boş olamaz");
            RuleFor(r => r.Name).MinimumLength(3).WithMessage("Bölüm adı en az 3 karakter olmalıdır");
            RuleFor(r => r.Name).MaximumLength(25).WithMessage("Bölüm adı en fazla 25 karakter olmalıdır");
        }
    }
}
