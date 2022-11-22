using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Challege_5
{
    public partial class gridview : System.Web.UI.Page
    {
        DatabaseSample db = new DatabaseSample();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = db.exedataset("select * from tbl_Employee");
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HtmlInputCheckBox chk;
            foreach (GridView dr in GridView1.Rows)
            {
                chk = (HtmlInputCheckBox)dr.FindControl("ch");

                if (chk.Checked)
                {
                    db.exenonquery("delete from employee where Employee_id=" + chk.Value + "");
                }
            }
            db.fillgrid("select * from tbl_Employee", GridView1);
        }



        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; //set edit index
            GridView1.DataSource = db.exedataset("select * from tbl_Employee"); //value taking from table
            GridView1.DataBind(); //binding data extracted from the table to the grid view 
        }

        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //take datakey value from grid view
            string empid = GridView1.DataKeys[e.RowIndex].Value.ToString(); //tacking emp value of the selected row
            //create a text box and initialize
            TextBox txtname = new TextBox();
            //access first column and assign to textbox
            txtname = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            Response.Write("<script>alert(txtname);</script>");
            //create a text box and initialize
            TextBox txtdesg = new TextBox();
            //access 2nd column and assign to textbox
            txtdesg = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            Response.Write("<script>alert(txtsalary);</script>");
            //create a text box for salary and initialize
            TextBox txtsalary = new TextBox();
            //access 3rd column and assign to textbox
            txtsalary = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            db.exenonquery("update tbl_Employee set Name='" + txtname.Text + "',Designation='" + txtdesg.Text + "',salary='" + txtsalary.Text + "'where Employee_id='" + empid + "'");
            GridView1.EditIndex = -1;  //previous view stage -1 indicate previous view only 
            GridView1.DataSource = db.exedataset("select * from tbl_Employee");
            GridView1.DataBind();

        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;  //previous view stage -1 indicate previous view only 
            GridView1.DataSource = db.exedataset("select * from tbl_Employee");
            GridView1.DataBind();

        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string empid = GridView1.DataKeys[e.RowIndex].Value.ToString(); //tacking emp value of the selected row
            db.exenonquery("Delete from tbl_Employee where Employee_id='" + empid + "'");
            GridView1.DataSource = db.exedataset("select * from tbl_Employee");
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
