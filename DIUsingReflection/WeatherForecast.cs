namespace DIUsingReflection
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public Guid SingletonGuid { get; set; }
        public Guid TransientGuid { get; set; }
            
        public Guid ScopedGuid { get; set; }
        public Guid SingletonGuid2 { get; set; }
        public Guid TransientGuid2 { get; set; }

        public Guid ScopedGuid2 { get; set; }
    }
}
