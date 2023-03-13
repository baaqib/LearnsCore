using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Learns.Model.Classes;
using Learns.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Learns.Data.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly LearnsContext _appDBContext;
        public SubjectRepository(LearnsContext learnsContext)
        {
            _appDBContext = learnsContext ?? throw new ArgumentNullException(nameof (learnsContext));
        }

        public async Task<Subject> GetSubjectByID(long Id)
        {
            return await _appDBContext.Subjects.FindAsync(Id);
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _appDBContext.Subjects.ToListAsync();
        }

        public async Task<Subject> InsertSubject(Subject subject)
        {
            _appDBContext.Subjects.Add(subject);
            await _appDBContext.SaveChangesAsync();

            return subject;
        }

        public async Task<Subject> UpdateSubject(Subject subject)
        {
            _appDBContext.Subjects.Update(subject);
            await _appDBContext.SaveChangesAsync();

            return subject;
        }

        public bool DeleteSubject(long Id)
        {
            var subject = _appDBContext.Subjects.Find(Id);
            if (null != subject)
            {
                _appDBContext.Entry(subject).State = EntityState.Deleted;
                _appDBContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
