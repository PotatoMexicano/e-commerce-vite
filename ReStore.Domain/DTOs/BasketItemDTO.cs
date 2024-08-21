namespace ReStore.Domain.DTOs;

public class BasketItemDTO
{
    public Int32 ProductId { get; set; }
    public String Name { get; set; }
    public Int64 Price { get; set; }
    public String PictureUrl { get; set; }
    public String Brand { get; set; }
    public String Type { get; set; }
    public Int32 Quantity { get; set; }
}