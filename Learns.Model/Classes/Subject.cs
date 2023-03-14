using System;
using System.Collections.Generic;
using System.Text;

namespace Learns.Model.Classes
{
    public class Subject
    {
        public long ID { get; set; }
        public string SubjectName { get; set; }
        public string InstituteId { get; set; }
        public bool IsActive { get; set; }
    }
}
