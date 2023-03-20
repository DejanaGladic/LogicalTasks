namespace LogicalTasks.Task2
{
    public class Weather
    {

        public string Country { get; set; }
        public string City { get; set; }
        public decimal Temperature { get; set; }
        public decimal WindSpeed { get; set; }

        public Weather()
        {
        }
        public Weather(string Country, string City, decimal Temperature, decimal WindSpeed)
        {
            this.Country = Country;
            this.City = City;
            this.Temperature = Temperature;
            this.WindSpeed = WindSpeed; 
        }



    }
}
