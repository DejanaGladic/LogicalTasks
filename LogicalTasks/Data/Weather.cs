using LogicalTasks.Interfaces;

namespace LogicalTasks.Data
{
    public class Weather: ICompare
    {

        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public decimal Temperature { get; set; }
        public decimal WindSpeed { get; set; }

        public Weather()
        {
        }
        public Weather(string country, int zipCode, string city, decimal temperature, decimal windSpeed)
        {
            Country = country;
            City = city;
            Temperature = temperature;
            WindSpeed = windSpeed;
            ZipCode = zipCode;
        }

        public object GetValueByPropertieName(string propertyName)
        {
            return GetType().GetProperty(propertyName).GetValue(this);
        }

        public override string ToString()
        {
            return $"Country: {Country}, ZipCode: {ZipCode}, City: {City}, " +
                $"Temperature: {Temperature}, WindSpeed: {WindSpeed}";
        }

        public decimal CompareWithValue(object valueToCompare, string compareProperty)
        {
            Object firstValue = GetValueByPropertieName(compareProperty);
            Object secondValue = valueToCompare;
            if (valueToCompare is Weather) {               
                secondValue = ((Weather)valueToCompare).GetValueByPropertieName(compareProperty);
            }
            if (firstValue is string && secondValue is string) {
                return string.Compare(firstValue.ToString(), secondValue.ToString());
            }
            return decimal.Parse(firstValue.ToString()) - decimal.Parse(secondValue.ToString());
        }
    }
}
