using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Models
{
    public class DeleteUserRequest
    {
        [JsonProperty("userId")]
        public string userId { get; set; }
    }
}
