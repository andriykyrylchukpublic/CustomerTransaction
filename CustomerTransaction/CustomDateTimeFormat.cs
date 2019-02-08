using Newtonsoft.Json.Converters;

namespace CustomerTransaction
{
    public class CustomDateTimeFormater: IsoDateTimeConverter
    {
        public CustomDateTimeFormater()
        {
            base.DateTimeFormat = "dd/MM/yyyy HH:MM";
        }
    }
}
