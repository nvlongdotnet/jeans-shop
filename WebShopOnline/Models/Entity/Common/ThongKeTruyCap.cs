﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebShopOnline.Models.Entity.Common
{
    public class ThongKeTruyCap
    {
        private static string strConnect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public static ThongKeViewModel ThongKe()
        {
            using(var connect = new SqlConnection(strConnect))
            {
                var item = connect.QueryFirstOrDefault<ThongKeViewModel>("sp_ThongKe", commandType: System.Data.CommandType.StoredProcedure);
                return item;
            }
        }
    }
}