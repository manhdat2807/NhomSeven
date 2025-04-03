namespace NhomSeven.Models
{
    public class SanPham
    {
        public Guid ID { get; set; }
        public string? tensp { get; set; }
        public decimal? giatien { get; set; }
        public string? mota {  get; set; }
        public byte[]? ImageUrl { get; set; }
        public bool trangthai { get; set; }
    }
}
