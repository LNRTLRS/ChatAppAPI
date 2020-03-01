using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace ChatApp.Repository.Messages
{
    public class MessageDbManager : IMessage
    {
        private LiteDatabase Database { get; } = new LiteDatabase("database.db");
        public LiteCollection<Message> Messages
        {
            get
            {
                return Database.GetCollection<Message>("Messages");
            }
        }

        public IList<Message> GetMessages()
        {
            return Messages.FindAll().ToList();
        }
        public IList<Message> GetFromChannel(int id)
        {
            List<Message> MessagesInChannel = new List<Message>();
            foreach(Message message in GetMessages())
            {
                if(message.ChannelID == id)
                {
                    MessagesInChannel.Add(message);
                }
            }
            return MessagesInChannel;
        }

        public void CreateMessage(Message msg)
        {
            Messages.Insert(msg);
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        public void EditMessage(int id, string newMessage)
        {
            throw new NotImplementedException();
        }

        public Message GetMessage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
