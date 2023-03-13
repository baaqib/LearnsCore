using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Learns.Model.Classes;

namespace Learns.Model.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetTopics();
        Task<Topic> GetTopic(long Id);
        Task<Topic> InsertTopic(Topic topic);
        Task<Topic> UpdateTopic(Topic topic);

        bool DeleteTopic(long Id);
    }
}
