using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Repository.Messages
{
    public class Message
    {
        [LiteDB.BsonId]
        [Required]
        public int ID { get; set; }
        [Required]
        public int CreatorID { get; set; }
        [Required]
        public int ChannelID { get; set; }
        [Required]
        public string MessageContent { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
