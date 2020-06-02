using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public class ApplicantRepository : BaseRepository<Applicant>, IApplicantRepository
    {
    }
}
