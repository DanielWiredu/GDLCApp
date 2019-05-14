using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace GDLCApp
{
    public partial class testGridDoubleClick : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            dynamic data = new[] {
              new { ID = 1, Name ="aaa"},
              new { ID = 2, Name = "bbb"},
              new { ID = 3, Name = "ccc"},
              new { ID = 4, Name = "ddd"},
              new { ID = 5, Name ="eee"},
              new { ID = 6, Name ="aaa"},
              new { ID = 7, Name = "bbb"},
              new { ID = 8, Name = "ccc"},
              new { ID = 9, Name = "ddd"},
              new { ID = 10, Name ="eee"}
            };
            RadGrid1.DataSource = data;
        }


        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "RowSingleClick")
            {
                var item = RadGrid1.Items[e.CommandArgument.ToString()];
                string id = item.GetDataKeyValue("ID").ToString();
                string name = item["Name"].Text;
                Label1.Text = "Single click of row which has datakey (ID) :" + e.CommandArgument + " my id is " + id + " and my name is " + name;
            }
            else if (e.CommandName == "RowDoubleClick")
            {
                var item = RadGrid1.Items[e.CommandArgument.ToString()];
                string id = item.GetDataKeyValue("ID").ToString();
                string name = item["Name"].Text;
                Label1.Text = "Double click of row which has datakey (ID) :" + e.CommandArgument + " my id is " + id + " and my name is " + name;
            }
        }
    }
}