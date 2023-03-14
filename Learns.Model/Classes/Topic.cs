using System;
using System.Collections.Generic;
using System.Text;

namespace Learns.Model.Classes
{
    public class Topic
    {
        public long ID { get; set; }
        public string TopicName { get; set; }
        public bool IsActive { get; set; }
        public string SubjectId { get; set; }
    }
}
