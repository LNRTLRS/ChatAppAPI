using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        [Required]
        public int ID { get; set; }
        [DataMember]
        [Required]
        public string Username { get; set; }
        [DataMember]
        [Required]
        public string Password { get; set; }
    }
}
