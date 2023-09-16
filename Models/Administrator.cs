using FoodOrderEntitie.AdminViewModels;
using FoodOrderEntitie.Utilities;
using System;
using System.Collections.Generic;
using System.Xml.XPath;

namespace FoodOrderEntitie.Models;

public partial class Administrator
{
    #region Properties
    public long Id { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminPhone { get; set; } = null!;

    public string AdminEmail { get; set; } = null!;

    public string AdminUserName { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;

    public bool AdminStatus { get; set; }

    public DateTime AdminCreatedAt { get; set; }
    #endregion

    #region Methods
    public static ResponseAction Insert(Administrator admin)
    {
        ResponseAction result = new ResponseAction();
        try
        {
            using (OrderfooddbContext context = new OrderfooddbContext())
            {
                context.Administrators.Add(admin);
                context.SaveChanges();

                result.Result = 1;
                result.ResultMessage = Constanta.INSERT_SUCCESS;
            }
        }
        catch (Exception ex)
        {
            throw ex;
            result.Result = 0;
            result.ResultMessage = Constanta.INSERT_FAILED;
        }
        return result;
    }
    public static bool CheckUsernameIsValid(string username)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(username))
        {
            using (OrderfooddbContext context = new OrderfooddbContext())
            {
                var obj = context.Administrators.Where(x => x.AdminName.ToLower().Equals(username.ToLower()));
                if (obj != null)
                    result = true;
            }
        }
        return result;
    }
    public static LoginResponse AdminLogin(LoginViewDetail loginDetail)
    {
        LoginResponse result = new LoginResponse();
        if (!string.IsNullOrEmpty(loginDetail.Username) && !string.IsNullOrEmpty(loginDetail.Password))
        {
            try
            {
                if (CheckUsernameIsValid(loginDetail.Username))
                {
                    string pwdEncode = EncodeDecodeBase64.EncodeBase64(loginDetail.Password);
                    using (OrderfooddbContext context = new OrderfooddbContext())
                    {
                        var obj = context.Administrators.Where(x => x.AdminPassword.Equals(pwdEncode));
                        if (obj != null && obj.Count() > 0)
                        {
                            result.Result = 1;
                            result.ResultMessage = Constanta.MSG_SUCCES_LOGIN;
                        }
                        else
                        {
                            result.Result = 0;
                            result.ResultMessage = Constanta.PASSWORD_FAILED;
                        }
                    }
                }
                else
                {
                    result.Result = 0;
                    result.ResultMessage = string.Format(Constanta.USERNAME_NOT_VALID, loginDetail.Username);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return result;
    }
    public static List<Administrator> GetAllAdministrator()
    {
        List<Administrator> result = new List<Administrator>();
        try
        {
            using(OrderfooddbContext context = new OrderfooddbContext())
            {
                var obj = context.Administrators.ToList();
                if(obj != null)
                {
                    result = obj.OrderByDescending(x=>x.AdminCreatedAt).ToList();
                }
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
