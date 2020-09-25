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
            object_Languages.data.languages.Count().ShouldBe(114);
        }
        [Test]
        public async Task Test_Countries_by_filter_empty()
        {
            var result = await ServiceHelper.get_Countries_by_filter_empty();
            Root object_Countries = JsonConvert.DeserializeObject<Root>(result);
            object_Countries.data.countries.Count().ShouldBe(250);
        }
        [Test]
        public async Task Test_Countries_by_filter_codeEqual_GB()
        {
            var result = await ServiceHelper.get_Countries_by_filter_codeEqual("GB");
            Root object_Countries = JsonConvert.DeserializeObject<Root>(result);
            var countCountries = object_Countries.data.countries.Count();
            if (countCountries != 1)
            {
                throw new Exception("Количество стран в ответе не равно 1");
            }
            else
            {
                object_Countries.data.countries[0].code.ShouldContain("GB");
                object_Countries.data.countries[0].name.ShouldContain("United Kingdom");
                object_Countries.data.countries[0].capital.ShouldContain("London");
            }
        }
        [Test]
        public async Task Test_Countries_by_filter_codeEqual_RU()
        {
            var result = await ServiceHelper.get_Countries_by_filter_codeEqual("RU");
            Root object_Countries = JsonConvert.DeserializeObject<Root>(result);
            var countCountries = object_Countries.data.countries.Count();
            if (countCountries != 1)
            {
                throw new Exception("Количество стран в ответе не равно 1");
            }
            else
            {
                object_Countries.data.countries[0].code.ShouldContain("RU");
                object_Countries.data.countries[0].name.ShouldContain("Russia");
                object_Countries.data.countries[0].capital.ShouldContain("Moscow");
            }
        }
        [Test]
        public async Task Test_Countries_by_filter_empty_find_in_array_RU()
        {
            var result = await ServiceHelper.get_Countries_by_filter_empty();
            Root object_Countries = JsonConvert.DeserializeObject<Root>(result);
            object_Countries.data.countries.Count().ShouldBe(250);
            var countCountries = object_Countries.data.countries.Count(lst => lst.code == "RU");
            if (countCountries != 1)
            {
                throw new Exception("Количество найденных элементов в списке не равно 1");
            }
            else
            {
                object_Countries.data.countries.First(lst => lst.code == "RU").code.ShouldContain("RU");
                object_Countries.data.countries.First(lst => lst.code == "RU").name.ShouldContain("Russia");
                object_Countries.data.countries.First(lst => lst.code == "RU").capital.ShouldContain("Moscow");
            }
        }
    }
}
