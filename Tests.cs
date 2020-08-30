using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Threading.Tasks;

namespace Test_API
{
    public class Tests
    {

        [Test]
        public async Task PostRequest()
        {
            var result = await ServiceHelper.PostRequestAsync_post();
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(result);
            StringAssert.Contains("{\"data\":{\"country\":{\"code\":\"RU\",\"name\":\"Russia\"}}}", result);
        }
        [Test]
        public async Task PostRequest_2()
        {
            var result = await ServiceHelper.PostRequestAsync_post_return_object();
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
            //Console.WriteLine("Code:" + myDeserializedClass.data.country.code);
            //Console.WriteLine("Name:" + myDeserializedClass.data.country.name);
            //StringAssert.Contains("RU", myDeserializedClass.data.country.code);
            //StringAssert.Contains("Russia", myDeserializedClass.data.country.name);
        }
    }
}
