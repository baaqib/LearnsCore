using Learns.Model.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learns.Model.Interfaces
{
    public interface IInstituteRepository
    {
        Task<IEnumerable<Institute>> GetInstitutes();
        Task<Institute> GetInstituteByID(long ID);
        Task<Institute> InsertInstitute(Institute objInstitute);
        Task<Institute> UpdateInstitute(Institute objInstitute);
        bool DeleteInstitute(long ID);
    }
}
