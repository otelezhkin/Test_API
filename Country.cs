using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
    }
    public class Data
    {
        public Country country { get; set; }
    }
    public class Root
    {
        public Data data { get; set; }
    }
}