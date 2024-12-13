using ReStore.Domain.Entities;

namespace ReStore.Domain.Extensions;
public static class ProductExtensions
{
    public static IQueryable<Product> Sort(this IQueryable<Product> query, String orderBy)
    {
        if (String.IsNullOrEmpty(orderBy))
            return query.OrderBy(p => p.Name);

        query = orderBy switch
        {
            "price" => query.OrderBy(p => p.Price),
            "priceDesc" => query.OrderByDescending(p => p.Price),
            _ => query.OrderBy(p => p.Name),
        };

        return query;
    }

    public static IQueryable<Product> Search(this IQueryable<Product> query, String searchTerm)
    {
        if (String.IsNullOrEmpty(searchTerm))
        {
            return query;
        }

        String lowerCaseSearchTerm = searchTerm.Trim().ToLower();

        return query.Where(p => p.Name.ToLower().Contains(searchTerm));

    }
}
