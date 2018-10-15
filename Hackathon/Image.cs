using System;
using System.Collections.Generic;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Hackathon
{
    [SerializePropertyNamesAsCamelCase]
    public partial class Image
    {
        public Image(string id, string des)
        {
            ImageID = id;
            Description = des;
            //DBtags = array;
        }
        [JsonProperty(PropertyName = "image")]
        [IsFilterable]
        public string ImageID { get; set; }

        [IsSearchable]
        public string Description { get; set; }

        //[IsSearchable, IsFilterable, IsSortable]
        //public IList<String> DBtags { get; set; }
    }
}


