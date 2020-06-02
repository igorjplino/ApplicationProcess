using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Web.Service
{
    public class ApplicantService : BaseService<Applicant>, IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository) 
            : base(applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }
    }
}
