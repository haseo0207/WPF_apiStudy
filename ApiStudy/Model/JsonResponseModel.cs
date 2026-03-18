using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class JsonResponseModel
    {
        [JsonPropertyName("response")]
        public ResponseModel Response { get; set; } = new();
    }
}
