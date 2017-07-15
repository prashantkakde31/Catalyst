using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
   public interface ITopicMasterRepository
    {
        IEnumerable<TopicMaster> GetAll();
        TopicMaster GetById(IdentifiableData id);
        void Add(TopicMaster TopicMaster);
        void Update(TopicMaster TopicMaster);
        void Delete(IdentifiableData id);
    }
}
