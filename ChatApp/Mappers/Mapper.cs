using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using ChatApp.Repository.Users;
using ChatApp.Repository.Channels;
using ChatApp.Repository.Messages;

namespace ChatApp.Mappers
{
    public class Mapper
    {
        public static Repository.Users.User Map(Models.User model)
        {
            return new Repository.Users.User()
            {
                ID = model.ID,
                Username = model.Username,
                Password = model.Password
            };
        }
        public static Models.User Map(Repository.Users.User user)
        {
            return new Models.User()
            {
                ID = user.ID,
                Username = user.Username,
                Password = user.Password
            };
        }
        public static IEnumerable<Models.User> Map(IEnumerable<Repository.Users.User> users)
        {
            List<Models.User> AllUsers = new List<Models.User>();
            foreach(Repository.Users.User user in users)
            {
                AllUsers.Add(Mapper.Map(user));
            }
            return AllUsers;
        }
        public static Repository.Channels.Channel Map(Models.Channel model)
        {
            return new Repository.Channels.Channel()
            {
                ID = model.ID,
                ChannelName = model.ChannelName,
                ChannelDesc = model.ChannelDesc
            };
        }
        public static Models.Channel Map(Repository.Channels.Channel channel)
        {
            return new Models.Channel()
            {
                ID = channel.ID,
                ChannelName = channel.ChannelName,
                ChannelDesc = channel.ChannelDesc
            };
        }
        public static IEnumerable<Models.Channel> Map(IEnumerable<Repository.Channels.Channel> channels)
        {
            List<Models.Channel> AllChannels = new List<Models.Channel>();
            foreach (Repository.Channels.Channel channel in channels)
            {
                AllChannels.Add(Mapper.Map(channel));
            }
            return AllChannels;
        }
        public static Repository.Messages.Message Map(Models.Message model)
        {
            return new Repository.Messages.Message()
            {
                ID = model.ID,
                CreatorID = model.CreatorID,
                ChannelID = model.ChannelID,
                MessageContent = model.MessageContent,
                CreationDate = model.CreationDate
            };
        }
        public static Models.Message Map(Repository.Messages.Message message)
        {
            return new Models.Message()
            {
                ID = message.ID,
                CreatorID = message.CreatorID,
                MessageContent = message.MessageContent,
                CreationDate = message.CreationDate
            };
        }
        public static IEnumerable<Models.Message> Map(IEnumerable<Repository.Messages.Message> messages)
        {
            List<Models.Message> AllMessages = new List<Models.Message>();
            foreach (Repository.Messages.Message message in messages)
            {
                AllMessages.Add(Mapper.Map(message));
            }
            return AllMessages;
        }
    }
}
