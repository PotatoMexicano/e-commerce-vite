using System.ComponentModel.DataAnnotations.Schema;

namespace ReStore.Domain.Entities;

[Table("BasketItems")]
public class BasketItem
{
    public Int32 Id { get; set; }
    public Int32 Quantity { get; set; }
    
    public Int32 ProductId { get; set; }
    public Product Product { get; set; }

    public Int32 BasketId { get; set; }
    public Basket Basket { get; set; }
}