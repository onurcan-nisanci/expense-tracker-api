using ExpenseTracker.Models.Services;
using System.Text.Json;

namespace ExpenseTracker.Services;

public class JsonStorageService<T> : IStorageService<T>
{
    private readonly string _filePath;

    public JsonStorageService(string filePath)
    {
       _filePath = filePath;
    }

    public void Save(List<T> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public List<T> Load()
    {
        if (!File.Exists(_filePath))
            return new List<T>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}