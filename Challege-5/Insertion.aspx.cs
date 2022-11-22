using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challege_5
{
    public partial class Insertion : System.Web.UI.Page
    {
        DatabaseSample ds = new DatabaseSample(); //Creating Class object
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into tbl_Employee values('" + textname.Text + "','" + textdesg.Text + "','" + textsalry.Text + "')";
            int i = ds.exenonquery(sql);
            if (i == 1)
            {
                Response.Write("<script>alert('inserted Successfully ');</script>");
            }
            else
            {
                Response.Write("Insertion Fail");
            }
        }
    }
}