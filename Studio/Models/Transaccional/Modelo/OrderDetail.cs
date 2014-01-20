namespace Studio.Models.Transaccional.Modelo
{
    public class OrderDetail : DbAble
    {
        public int OrderId { get; set; }

        public int AlbumId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Album Album { get; set; }

        public Order Order { get; set; }
    }
}