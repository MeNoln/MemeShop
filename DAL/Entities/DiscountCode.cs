namespace DAL.Entities
{
    //Discount Codes model
    public class DiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPerCent { get; set; }
    }
}
