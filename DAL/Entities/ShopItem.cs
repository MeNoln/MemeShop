namespace DAL.Entities
{
    //Shop item model
    public class ShopItem
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
