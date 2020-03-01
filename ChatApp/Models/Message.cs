using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    [DataContract]
    public class Message
    {
        [DataMember]
        [Required]
        public int ID { get; set; }
        [DataMember]
        [Required]
        public int CreatorID { get; set; }
        [DataMember]
        [Required]
        public int ChannelID { get; set; }
        [DataMember]
        [Required]
        public string MessageContent { get; set; }
        [DataMember]
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
