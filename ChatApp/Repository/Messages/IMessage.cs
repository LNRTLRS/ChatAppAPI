using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Repository.Messages
{
    public interface IMessage
    {
        IList<Message> GetMessages();
        IList<Message> GetFromChannel(int id);
        void CreateMessage(Message msg);
        void DeleteMessage(int id);
        void EditMessage(int id, string newMessage);
        Message GetMessage(int id);
    }
}
