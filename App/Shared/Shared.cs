namespace UKHSA.Shared;

public class Paginated<T>
{
    List<T> _allItems;
    public List<T> Items
    {
        get
        {
            return _allItems
            .Skip((CurrentPage - 1) * PerPage)
            .Take(PerPage)
            .ToList();
        }
        set { _allItems = value; }
    }

    public int CurrentPage { get; set; } = 1;
    public int PerPage { get; set; } = 20;
    public int TotalItems => _allItems.Count;
    public int TotalPages => (int)Math.Ceiling(_allItems.Count / (double)PerPage);
}
