namespace ReStore.Domain.Entities;
public class Basket
{
    public Int32 Id { get; set; }
    public String BuyerId { get; set; }
    public List<BasketItem> Items { get; set; } = new();

    public void AddItem(Product product, Int32 quantity)
    {
        if (Items.All(item => item.ProductId != product.Id))
        {
            Items.Add(new BasketItem
            {
                Product = product,
                Quantity = quantity,
            });
        }

        BasketItem existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);

        if (existingItem != null) existingItem.Quantity += quantity;
    }

    public void RemoveItem(Int32 productId, Int32 quantity)
    {
        BasketItem item = Items.FirstOrDefault(item => item.ProductId == productId);
        if (item == null) return;

        Int32 currentQuantity = item.Quantity;

        if (( currentQuantity - quantity ) <= 0)
        {
            item.Quantity = 0;
        }
        else
        {
            item.Quantity -= quantity;
        }

        if (item.Quantity <= 0) Items.Remove(item);
    }
}
