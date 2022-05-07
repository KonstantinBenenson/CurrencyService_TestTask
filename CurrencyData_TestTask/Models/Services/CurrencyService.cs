using CurrencyData.Models.DataObjects;
using Newtonsoft.Json;


namespace CurrencyData.Models.Services
{
    public class CurrencyService  
    {
        string url = "https://www.cbr-xml-daily.ru/daily_json.js";

        public async Task<CurrencyInfo> GetDataFromJsonAsync()
        {
            if (url == null)
                throw new ArgumentNullException("url");

            using var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<CurrencyInfo>(result);

            return data;
        }

        public async Task<CurrencyInfo> GetAllCurrencyDataAsync()
        {
            try
            {
                var data = await GetDataFromJsonAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, "Can`t get information from the source. Try again later.");
            }
        }

        public async Task<Valute> GetCurrencyByKeyAsync(string key)
        {
            try
            {
                var data = await GetDataFromJsonAsync();
                Valute currencyInfo = null;

                if(data.Valute.TryGetValue(key.ToUpper(), out var valute))
                    currencyInfo = valute;

                return currencyInfo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, "Can`t get information from the source. Try again later.");
            }
        }
    }
}
