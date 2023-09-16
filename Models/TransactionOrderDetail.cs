using System;
using System.Collections.Generic;

namespace FoodOrderEntitie.Models;

public partial class TransactionOrderDetail
{
    public int IdOrderDetail { get; set; }

    public DateTime DateOrder { get; set; }

    public int IdTrx { get; set; }

    public int Quantity { get; set; }

    public decimal FoodPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public int IdFood { get; set; }

    public virtual Food IdFoodNavigation { get; set; } = null!;

    public virtual TransactionOrder IdTrxNavigation { get; set; } = null!;
}
