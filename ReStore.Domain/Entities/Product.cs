namespace ReStore.Domain.Entities;
public class Product
{
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public Int64 Price { get; set; }
    public String PictureUrl { get; set; }
    public String Type { get; set; }
    public String Brand { get; set; }
    public Int32 QuantityInStock { get; set; }
}
