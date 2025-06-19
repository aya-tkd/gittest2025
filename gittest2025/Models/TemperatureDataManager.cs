using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;

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

        public void LoadRecordsFromCsv(string filePath)
        {
            _records.Clear();

            try
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length <= 1) return; // �w�b�_�[�݂̂܂��͋�t�@�C��

                // �w�b�_�[�s���X�L�b�v
                foreach (var line in lines.Skip(1))
                {
                    try
                    {
                        var parts = line.Split(',');
                        if (parts.Length >= 2)
                        {
                            if (DateTime.TryParseExact(parts[0].Trim(), "yyyy/MM/dd HH:mm:ss",
                                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime recordTime)
                                && decimal.TryParse(parts[1].Trim(), out decimal temperature))
                            {
                                var record = new TemperatureRecord(recordTime, temperature);
                                _records.Add(record);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // �ʂ̍s�̏����G���[�͖������đ��s
                        continue;
                    }
                }
            }
            catch (Exception)
            {
                throw; // ��ʑw�Ńn���h�����O
            }
        }

        public void SaveRecordsToCsv(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, false))
                {
                    // �w�b�_�[�s����������
                    writer.WriteLine("����,�̉�,����");

                    // �f�[�^�s����������
                    foreach (var record in _records.OrderBy(r => r.RecordTime))
                    {
                        var line = $"{record.RecordTime:yyyy/MM/dd HH:mm:ss},{record.Temperature:F1}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception)
            {
                throw; // ��ʑw�Ńn���h�����O
            }
        }
    }
}