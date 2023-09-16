using System;
using System.Collections.Generic;

namespace FoodOrderEntitie.Models;

public partial class TransactionOrder
{
    public int IdTrx { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal? GrandTotal { get; set; }

    public decimal? Pembayaran { get; set; }

    public virtual ICollection<TransactionOrderDetail> TransactionOrderDetails { get; set; } = new List<TransactionOrderDetail>();
}
