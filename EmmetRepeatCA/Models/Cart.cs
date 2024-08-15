namespace EmmetRepeatCA.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Vinyl vinyl, int quantity)
        {
            var line = Lines.FirstOrDefault(v => v.Vinyl.VinylId == vinyl.VinylId);

            if (line == null)
            {
                Lines.Add(new CartLine { Vinyl = vinyl, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Vinyl vinyl) =>
            Lines.RemoveAll(l => l.Vinyl.VinylId == vinyl.VinylId);

        public virtual decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Vinyl.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Vinyl Vinyl { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
