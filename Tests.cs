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
            var result = await ServiceHelper.get_Country_by_code("GB");
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(result);
            Root object_Country = JsonConvert.DeserializeObject<Root>(result);
            object_Country.data.country.code.ShouldContain("GB");
            object_Country.data.country.name.ShouldContain("United Kingdom");
            object_Country.data.country.capital.ShouldContain("London");
        }
        [Test]
        public async Task Test_Language_by_code_ru()
        {
            var result = await ServiceHelper.get_Language_by_code("ru");
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(result);
            Root object_Language = JsonConvert.DeserializeObject<Root>(result);
            object_Language.data.language.code.ShouldContain("ru");
            object_Language.data.language.name.ShouldContain("Russian");
            object_Language.data.language.native.ShouldContain("Русский");
            object_Language.data.language.rtl.ShouldContain("false");
        }
        [Test]
        public async Task Test_Language_by_code_en()
        {
            var result = await ServiceHelper.get_Language_by_code("en");
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(result);
            Root object_Language = JsonConvert.DeserializeObject<Root>(result);
            object_Language.data.language.code.ShouldContain("en");
            object_Language.data.language.name.ShouldContain("English");
            object_Language.data.language.native.ShouldContain("English");
            object_Language.data.language.rtl.ShouldContain("false");
        }
    }
}
