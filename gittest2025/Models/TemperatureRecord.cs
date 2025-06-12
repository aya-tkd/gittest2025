namespace gittest2025.Models
{
    public class TemperatureRecord
    {
        public DateTime RecordTime { get; set; }
        public decimal Temperature { get; set; }

        public TemperatureRecord(DateTime recordTime, decimal temperature)
        {
            RecordTime = recordTime;
            Temperature = temperature;
        }
    }
}