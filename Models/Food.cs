using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace FoodOrderEntitie.Models;

public partial class Food
{
    #region Properties
    public int IdFood { get; set; }

    public string FoodName { get; set; } = null!;

    public decimal? FoodPrice { get; set; }

    public virtual ICollection<ListOrder> ListOrders { get; set; } = new List<ListOrder>();

    public virtual ICollection<TransactionOrderDetail> TransactionOrderDetails { get; set; } = new List<TransactionOrderDetail>();
    #endregion


    #region Methods
    public static List<Food> GetAllFoods()
    {
        try
        {
            using (OrderfooddbContext context = new OrderfooddbContext())
            {
                return context.Foods.ToList();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static bool InsertFood(Food _food)
    {
        bool result =false;
        try
        {
            using (OrderfooddbContext context = new OrderfooddbContext())
            {
                context.Foods.Add(_food);   
                int save = context.SaveChanges();
                if(save > 0)
                    result= true;   

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }
    #endregion
}
