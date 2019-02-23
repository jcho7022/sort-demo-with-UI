using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapstedTest.Models
{
    public enum SortType
    {
        Quick = 0,
        Bubble = 1,
        Bucket = 2
    }

    public class SortTask<T> : ISortTask<T>
    {
        [JsonProperty("SortType")]
        public SortType SortType;

        [JsonProperty("Input")]
        public List<T> ListToSort;
    }
}
