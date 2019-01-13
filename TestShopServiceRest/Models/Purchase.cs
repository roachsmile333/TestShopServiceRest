namespace TestShopServiceRest.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public int shopID { get; set; }
        public int userID { get; set; }
        public decimal purchaseSum { get; set; }
    }
}
