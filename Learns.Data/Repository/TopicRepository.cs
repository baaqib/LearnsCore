using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Learns.Model.Classes;
using Learns.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Learns.Data.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly LearnsContext _appDBContext;
        public TopicRepository(LearnsContext learnsContext)
        {
            _appDBContext = learnsContext;
        }

        public async Task<Topic> GetTopic(long Id)
        {
            return await _appDBContext.Topics.FindAsync(Id);
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            return await _appDBContext.Topics.ToListAsync();
        }

        public async Task<Topic> InsertTopic(Topic topic)
        {
            _appDBContext.Topics.Add(topic);
            await _appDBContext.SaveChangesAsync();

            return topic;
        }

        public async Task<Topic> UpdateTopic(Topic topic)
        {
            _appDBContext.Entry(topic).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();

            return topic;
            //return true;
        }

        public bool DeleteTopic(long Id)
        {
            var topic = _appDBContext.Topics.Find(Id);
            if (null != topic)
            {
                _appDBContext.Entry(topic).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
