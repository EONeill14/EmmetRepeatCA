namespace EmmetRepeatCA.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string City { get; set; }

        public string? State { get; set; }

        public string Eircode { get; set; }

        public string Country { get; set; }

        public bool GiftWrap { get; set; }

        public bool Shipped { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
    }
}
