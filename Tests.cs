using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace Test_API
{
    public class Tests
    {

        [Test]
        public async Task Test_Country_by_code_RU()
        {
            var result = await ServiceHelper.get_Country_by_code("RU");
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(result);
            Root object_Country = JsonConvert.DeserializeObject<Root>(result);
            object_Country.data.country.code.ShouldContain("RU");
            object_Country.data.country.name.ShouldContain("Russia");
            object_Country.data.country.capital.ShouldContain("Moscow");
        }
        [Test]
        public async Task Test_Country_by_code_UA()
        {
            var result = await ServiceHelper.get_Country_by_code("UA");
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(result);
            Root object_Country = JsonConvert.DeserializeObject<Root>(result);
            object_Country.data.country.code.ShouldContain("UA");
            object_Country.data.country.name.ShouldContain("Ukraine");
            object_Country.data.country.capital.ShouldContain("Kyiv");
        }
    }
}
