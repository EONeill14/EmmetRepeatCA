using System.Text.Json.Serialization;
using EmmetRepeatCA.Infrastructure;

namespace EmmetRepeatCA.Models
{
    public class SessionCart : Cart
    {
        public static SessionCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();

            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession? Session { get; set; }

        public override void AddItem(Vinyl vinyl, int quantity)
        {
            base.AddItem(vinyl, quantity);
            Session?.SetJson("Cart", this); // Serialize only the necessary data
        }

        public override void RemoveLine(Vinyl vinyl)
        {
            base.RemoveLine(vinyl);
            Session?.SetJson("Cart", this); // Serialize only the necessary data
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart"); // Clear the session data
        }
    }
}
