namespace ExpenseTracker.Models.Services;

public interface IStorageService<T>
{
    void Save(List<T> data);
    List<T> Load();
}