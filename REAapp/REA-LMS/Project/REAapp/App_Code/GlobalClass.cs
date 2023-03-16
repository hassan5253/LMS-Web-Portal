using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GlobalClass
/// </summary>
public class GlobalClass
{
	public GlobalClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string User_ID = "";
    public static DataTable CreateDataTable(string ColumnNames)
    {
        System.Data.DataTable Dt = new System.Data.DataTable();
        string[] spliCol = ColumnNames.Split(',');
        foreach (string singleCol in spliCol)
        {
            Dt.Columns.Add(singleCol);
        }
        return Dt;
    }
    public struct AlertTypes
    {
        //public static string Success = "alert alert-success alert-dismissable";
        public static string Success = "alert alert-success";
        public static string Warning = "alert";
        public static string Info = "alert";
        public static string Error = "alert alert-error";


        //public static string Warning = "alert alert-warning alert-dismissable";
        //public static string Info = "alert alert-info alert-dismissable";
        //public static string Error = "alert alert-danger alert-dismissable";

        public static string SuccessType = "Success!";
        public static string WarningType = "Alert!";
        public static string InfoType = "Info!";
        public static string ErrorType = "Error!";
    }

    public static string UserID () 
    {
        if (HttpContext.Current.Session["User_ID"] != null) 
        {
            User_ID = HttpContext.Current.Session["User_ID"].ToString();
        }
        return User_ID;
    }




}