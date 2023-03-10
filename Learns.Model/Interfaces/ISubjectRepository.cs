using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Learns.Model.Classes;

namespace Learns.Model.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubjectByID(long Id);
        Task<Subject> InsertSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        bool DeleteSubject(long Id);
    }
}
