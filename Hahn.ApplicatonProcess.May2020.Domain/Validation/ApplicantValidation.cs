using FluentValidation;
using FluentValidation.Validators;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Validation
{
    public class ApplicantValidation : AbstractValidator<Applicant>
    {
        public ApplicantValidation()
        {
            RuleFor(o => o.Name).MinimumLength(5);
            RuleFor(o => o.FamilyName).MinimumLength(5);
            RuleFor(o => o.Address).MinimumLength(10);
            RuleFor(o => o.CountryOfOrigin).MustAsync(async (o, cancellation) => await CheckCountryExist(o)).WithMessage("must be a valid Country.");
            RuleFor(o => o.EmailAddress).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(o => o.Age).InclusiveBetween(20, 60);
            RuleFor(o => o.Hired).NotNull();
        }

        private async Task<bool> CheckCountryExist(string country)
        {
            var url = $"https://restcountries.eu/rest/v2/name/{country}?fullText=true";
            
            var request = WebRequest.Create(url);

            try
            {
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch 
            {
                return false;
            }
            
        }
    }
}
