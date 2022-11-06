using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDto
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        public string  Token { get; set; }
        public string PhotoUrl { get; set; }
        
    }
}