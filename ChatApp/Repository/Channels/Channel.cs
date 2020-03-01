using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Repository.Channels
{
    public class Channel
    {
        [LiteDB.BsonId]
        public int ID { get; set; }
        public string ChannelName { get; set; }
        public string ChannelDesc { get; set; }
    }
}
