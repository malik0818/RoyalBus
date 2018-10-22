using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            List<tbl_user> lgs = (from x in db.tbl_user select x).ToList();
            var userType = (from x in db.tbl_usertype select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
            user_type.DataSource = userType;
            user_type.DataTextField = "type_name";
            user_type.DataValueField = "type_id";
            user_type.DataBind();
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        MakeAccessible(grid1);
    }
    public static void MakeAccessible(GridView grid)
    {
        if (grid.Rows.Count <= 0) return;
        grid.UseAccessibleHeader = true;
        grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (grid.ShowFooter)
            grid.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    protected void btn_add_User_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(User_name.Value.ToString()) && !String.IsNullOrEmpty(User_contact.Value.ToString()))
        {
            bus_dbEntities db = new bus_dbEntities();
            //Create new instance and assign values to columns
            tbl_user user = new tbl_user();

            user.user_name = User_name.Value.ToString();
            user.user_contact = User_contact.Value.ToString();
            user.user_email = User_email.Value.ToString();
            user.user_address = User_address.Value.ToString();
            user.fk_type = Int32.Parse(user_type.SelectedValue.ToString());
            //Add instance in db
            db.tbl_user.Add(user);
            db.SaveChanges();

            List<tbl_user> lgs = (from x in db.tbl_user select x).ToList();
            var userType = (from x in db.tbl_usertype select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
            user_type.DataSource = userType;
            user_type.DataTextField = "type_name";
            user_type.DataValueField = "type_id";
            user_type.DataBind();
        }
        else
        {
            //Show alert
            ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "alert('Please Enter usermane or password');", true);
        }
    }
}