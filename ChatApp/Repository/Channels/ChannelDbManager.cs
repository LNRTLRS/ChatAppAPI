using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ChatApp.Repository.Channels
{
    public class ChannelDbManager : IChannel
    {
        private LiteDatabase Database { get; } = new LiteDatabase("database.db");
        
        public LiteCollection<Channel> Channels
        {
            get
            {
                return Database.GetCollection<Channel>("Channels");
            }
        }

        public IList<Channel> GetChannels()
        {
            return Channels.FindAll().ToList();
        }

        public void CreateChannel(Channel channel)
        {
            Channels.Insert(channel);
        }

        public void RemoveChannel(int id)
        {
            Channels.Delete(id);
        }

        public void ChangeChannelNameAndDesc(int id, string newChannelName, string newDescription)
        {
            Channel c = GetChannel(id);
            c.ChannelName = newChannelName;
            c.ChannelDesc = newDescription;
            Channels.Update(c);
        }

        public Channel GetChannel(int id)
        {
            return Channels.FindById(id);
        }
    }
}
