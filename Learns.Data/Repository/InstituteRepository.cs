using Learns.Model.Classes;
using Learns.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learns.Data.Repository
{
    public class InstituteRepository : IInstituteRepository
    {
        private readonly LearnsContext _appDBContext;
        public InstituteRepository(LearnsContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Institute>> GetInstitutes()
        {
            return await _appDBContext.Institutes.ToListAsync();
        }

        public async Task<Institute> GetInstituteByID(long ID)
        {
            return await _appDBContext.Institutes.FindAsync(ID);
        }
        public async Task<Institute> InsertInstitute(Institute objInstitute)
        {
            _appDBContext.Institutes.Add(objInstitute);

            //_appDBContext.Subjects.Where(y =>y.SubjectName == "sajid").Select(x => new { 
            //    sname = x.SubjectName,
            //    kk = x.Institute.Name
            //});

            await _appDBContext.SaveChangesAsync();
            return objInstitute;
        }
        public async Task<Institute> UpdateInstitute(Institute objInstitute)
        {
            _appDBContext.Entry(objInstitute).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objInstitute;
        }
        public bool DeleteInstitute(long ID)
        {
            bool result = false;
            var Institute = _appDBContext.Institutes.Find(ID);
            if (Institute != null)
            {
                _appDBContext.Entry(Institute).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
