using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Test_API
{
    public class Tests
    {

        [Test]
        public async Task Test_Country_by_code_RU()
        {
            var result = await ServiceHelper.get_Country_by_code("RU");
            Root object_Country = JsonConvert.DeserializeObject<Root>(result);
            object_Country.data.country.code.ShouldContain("RU");
            object_Country.data.country.name.ShouldContain("Russia");
            object_Country.data.country.capital.ShouldContain("Moscow");
        }
        [Test]
        public async Task Test_Country_by_code_GB()
        {
            var result = await ServiceHelper.get_Country_by_code("GB");
            Root object_Country = JsonConvert.DeserializeObject<Root>(result);
            object_Country.data.country.code.ShouldContain("GB");
            object_Country.data.country.name.ShouldContain("United Kingdom");
            object_Country.data.country.capital.ShouldContain("London");
        }
        [Test]
        public async Task Test_Language_by_code_ru()
        {
            var result = await ServiceHelper.get_Language_by_code("ru");
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
            Root object_Language = JsonConvert.DeserializeObject<Root>(result);
            object_Language.data.language.code.ShouldContain("en");
            object_Language.data.language.name.ShouldContain("English");
            object_Language.data.language.native.ShouldContain("English");
            object_Language.data.language.rtl.ShouldContain("false");
        }
        [Test]
        public async Task Test_Languages_by_filter_codeEqual_ru()
        {
            var result = await ServiceHelper.get_Languages_by_filter_codeEqual("ru");
            Root object_Languages = JsonConvert.DeserializeObject<Root>(result);
            object_Languages.data.languages[0].code.ShouldContain("ru");
            object_Languages.data.languages[0].name.ShouldContain("Russian");
            object_Languages.data.languages[0].native.ShouldContain("Русский");
            object_Languages.data.languages[0].rtl.ShouldContain("false");
        }
        [Test]
        public async Task Test_Languages_by_filter_codeEqual_en()
        {
            var result = await ServiceHelper.get_Languages_by_filter_codeEqual("en");
            Root object_Languages = JsonConvert.DeserializeObject<Root>(result);
            object_Languages.data.languages[0].code.ShouldContain("en");
            object_Languages.data.languages[0].name.ShouldContain("English");
            object_Languages.data.languages[0].native.ShouldContain("English");
            object_Languages.data.languages[0].rtl.ShouldContain("false");
        }
        [Test]
        public async Task Test_Languages_by_filter_empty()
        {
            var result = await ServiceHelper.get_Languages_by_filter_empty();
            Root object_Languages = JsonConvert.DeserializeObject<Root>(result);
            var languages = object_Languages.data.languages;
            var search = languages.Where(languages => languages.code == "af");
            //Console.WriteLine(languages);
        }
    }
}
