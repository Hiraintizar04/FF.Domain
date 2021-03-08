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
			RuleFor(x => x.Name).MinimumLength(5);
			RuleFor(x => x.FamilyName).MinimumLength(5);
			RuleFor(x => x.Address).MinimumLength(10);
			RuleFor(x => x.CountryOfOrigin).NotNull();
			RuleFor(x => x.EmailAddress).EmailAddress();
			RuleFor(x => x.Age).InclusiveBetween(20, 60);
		}

	}
}
