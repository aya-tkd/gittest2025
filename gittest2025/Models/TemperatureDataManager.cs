using System.Collections.ObjectModel;

namespace gittest2025.Models
{
    public class TemperatureDataManager
    {
        private ObservableCollection<TemperatureRecord> _records;

        public ObservableCollection<TemperatureRecord> Records => _records;

        public TemperatureDataManager()
        {
            _records = new ObservableCollection<TemperatureRecord>();
        }

        public void AddRecord(TemperatureRecord record)
        {
            _records.Add(record);
        }

        public bool RemoveRecord(TemperatureRecord record)
        {
            return _records.Remove(record);
        }
    }
}