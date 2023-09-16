using System;
using System.Collections.Generic;

namespace FoodOrderEntitie.Models;

public partial class ListOrder
{
    public int IdOrder { get; set; }

    public DateTime DateOrder { get; set; }

    public int IdFood { get; set; }

    public int Quantity { get; set; }

    public decimal FoodPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Food IdFoodNavigation { get; set; } = null!;
}
