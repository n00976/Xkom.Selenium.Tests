using BaseTemplate.Models;

namespace BasicSeleniumTest.Models
{
    public class AppSettings
    {
        public string? HomePage { get; set; } 
        public ProductDefinition ExpectedAmountOfProduct { get; set; } = new ProductDefinition();
        public Credentials? Credentials { get; set; }
        public string? AvailableProduct { get; set; }
    }
}
