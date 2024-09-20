using SingletonPattern;

//var countryProvider = new CountryProvider();

//await CountryProvider.Instance.GetCountries();

Console.WriteLine(DateTime.Now.ToLongTimeString());
var countries = await CountryProvider.Instance.GetCountries();

foreach (var country in countries)
{
    Console.WriteLine(country.Name);
}

// another service

//var countryProvider1 = new CountryProvider(); not allowed bc it has private constructor

var countries1 = await CountryProvider.Instance.GetCountries();

Console.WriteLine(CountryProvider.Instance.CountryCount);
Console.WriteLine(DateTime.Now.ToLongTimeString());
