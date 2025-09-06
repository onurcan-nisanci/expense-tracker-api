namespace ExpenseTracker.Services;

public interface IStorageService<T>
{
    void Save(List<T> data);
    List<T> Load();
}