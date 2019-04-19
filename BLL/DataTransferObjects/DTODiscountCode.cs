namespace BLL.DataTransferObjects
{
    //Discount Code Data Transfer Object
    public class DTODiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPerCent { get; set; }
    }
}
