using BusinessObject;

namespace DataAccess;

public class CategoryDAO
{
    public static Category GetCategoryByID(int Id)
    {
        Category category = null;
        try
        {
            using var context = new EStoreDbContext();
            category = context.Categories.Find(Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return category;
    }
}