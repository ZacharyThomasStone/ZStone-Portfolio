using FlooringMastery.Data;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMaster.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
         
           string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "OrderTest":
                    return new OrderManager(new OrderTestRepository());
                case "Prod":
                    return new OrderManager(new OrderAccountRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
            
        }
    }
}
