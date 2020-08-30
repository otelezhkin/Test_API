﻿namespace Test_API
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Country
    {
        public string code { get; set; }
        public string name { get; set; }
        public string capital { get; set; }
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
