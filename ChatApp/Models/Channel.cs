using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    [DataContract]
    public class Channel
    {
        [DataMember]
        [Required]
        public int ID { get; set; }
        [DataMember]
        [Required]
        public string ChannelName { get; set; }
        [DataMember]
        [Required]
        public string ChannelDesc { get; set; }
    }
}
