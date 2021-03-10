using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Data.Models
{
	public class ApplicantValidator : AbstractValidator<Applicant>
	{

		public ApplicantValidator()
		{
			RuleFor(x => x.ApplicantId).NotNull();
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("please enter correct name");
			RuleFor(x => x.FamilyName).MinimumLength(5).WithMessage("please enter correct family name"); 
			RuleFor(x => x.Address).MinimumLength(10).WithMessage("Address is invalid"); 
			RuleFor(x => x.CountryOfOrigin).NotNull().WithMessage("Country does not exist"); 
			RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email Id is invalid");
			RuleFor(x => x.Age).InclusiveBetween(20, 60).WithMessage("please enter correct age");
		}

	}
}
