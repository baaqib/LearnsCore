using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Learns.Model.Classes
{
    public class Subject
    {
        [Key]
        public long ID { get; set; }
        public string SubjectName { get; set; }
        public bool IsActive { get; set; }
        public Institute Institute { get; set; }
         
    }
}
