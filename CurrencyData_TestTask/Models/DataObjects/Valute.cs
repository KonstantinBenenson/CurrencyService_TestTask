using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CurrencyData.Models.DataObjects
{
    public class Valute
    {
        public string ID { get; set; }        
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
    }
}
