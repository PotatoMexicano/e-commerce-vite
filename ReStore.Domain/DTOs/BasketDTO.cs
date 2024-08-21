namespace ReStore.Domain.DTOs;
public class BasketDTO
{
    public Int32 Id { get; set; }
    public String BuyerId { get; set; }
    public List<BasketItemDTO> Items { get; set; }
}
