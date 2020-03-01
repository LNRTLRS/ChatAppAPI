using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Repository.Channels
{
    public interface IChannel
    {
        IList<Channel> GetChannels();
        void CreateChannel(Channel channel);
        void RemoveChannel(int id);
        void ChangeChannelNameAndDesc(int id, string newChannelName, string newDescription);
        Channel GetChannel(int id);
    }
}
