namespace APIhub.Model
{
    public class CompanyHeader
    {
        public string Name { get; set; }  
        public byte[] Image { get; set; } 
        public string Addrs { get; set; } 
   
        public List<ItemDetails> Items { get; set; } = new List<ItemDetails>();
    }

    public class ItemDetails
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public double Quantity { get; set; }
    }
}
