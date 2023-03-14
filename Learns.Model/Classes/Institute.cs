using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Learns.Model.Classes
{
    public class Institute
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Subject> Subject { get; set; }
        public bool IsActive { get; set; }

    }
}
