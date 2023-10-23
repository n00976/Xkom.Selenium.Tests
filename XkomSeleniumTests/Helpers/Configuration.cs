using BasicSeleniumTest.Models;
using Newtonsoft.Json;

namespace BasicSeleniumTest.Helpers
{
    public static class Configuration
    {
        public static AppSettings GetAppSettings()
        {
            AppSettings? myObject;
            using (StreamReader r = new StreamReader("appSettings.json"))
            {
                string json = r.ReadToEnd();

                myObject = JsonConvert.DeserializeObject<AppSettings>(json);
            }
            if (myObject == null)
            {
                myObject = new AppSettings();
            }
            return myObject;
        }
    }
}
