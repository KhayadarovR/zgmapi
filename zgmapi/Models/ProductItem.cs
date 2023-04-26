using System.ComponentModel.DataAnnotations;

namespace zgmapi.Models;

public class ProductItem
{
    [Key] public long Id { get; set; }
    [Required] public int ProductId { get; set; }
    public Product Product { get; set; }

    public short Discount { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Expiration { get; set; }

    public int StatusId { get; set; } = 1;
    public virtual Status Status { get; set; }

    public int Count { get; set; }
    
    public int? StockId { get; set; }
    public virtual Stock Stock { get; set; }
}