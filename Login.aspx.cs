using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["login_data"] != null)
        {
            HttpCookie myCookie = new HttpCookie("login_data");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
        if (!IsPostBack)
        {
            loginErrorMsg.Visible = false;
            signupErrorMsg.Visible = false;
            signupErrorMsg2.Visible = false;
            signupErrorMsg3.Visible = false;
            userBlock.Visible = false;
            passwordBlock.Visible = false;
            nameErr.Visible = false;
            contactErr.Visible = false;
            cnicErr.Visible = false;
            usernameErr.Visible = false;
            passwordErr.Visible = false;
        }
    }
    protected void btn_signup_Click(object sender, EventArgs e)
    {
        nameErr.Visible = false;
        contactErr.Visible = false;
        cnicErr.Visible = false;
        usernameErr.Visible = false;
        passwordErr.Visible = false;
        signupErrorMsg.Visible = false;
        signupErrorMsg2.Visible = false;
        signupErrorMsg3.Visible = false;
        String name = s_name.Value.ToString();
        if (String.IsNullOrEmpty(name))
        {
            nameErr.Visible = true;
        }
        String contact = s_contact.Value.ToString();
        if (String.IsNullOrEmpty(contact))
        {
            contactErr.Visible = true;
        }
        String cnic = s_cnic.Value.ToString();
        if (String.IsNullOrEmpty(cnic))
        {
            cnicErr.Visible = true;
        }
        String email = s_email.Value.ToString();
        String address = s_address.Value.ToString();
        String user = s_user.Value.ToString();
        if (String.IsNullOrEmpty(user))
        {
            usernameErr.Visible = true;
        }
        String pass = s_password.Value.ToString();
        if (String.IsNullOrEmpty(pass))
        {
            passwordErr.Visible = true;
        }
        if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(contact) && !String.IsNullOrEmpty(cnic) && !String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass))
        {
            bus_dbEntities db = new bus_dbEntities();
            List<tbl_user> usrList = (from x in db.tbl_user where x.user_cnic == cnic select x).ToList();
            if(usrList.Count > 0)
            {
                signupErrorMsg3.Visible = true;
            }
            else
            {
                usrList = (from x in db.tbl_user where x.user_duser == user select x).ToList();

                if(usrList.Count>0)
                {
                    signupErrorMsg2.Visible = true;
                }
                else
                {
                    tbl_user usr = new tbl_user();
                    usr.user_name = name;
                    usr.user_contact = contact;
                    usr.user_cnic = cnic;
                    usr.user_email = email;
                    usr.user_status = "not verified";
                    usr.user_address = address;
                    usr.user_duser = user;
                    usr.user_dpassword = pass;
                    db.tbl_user.Add(usr);
                    db.SaveChanges();
                    ScriptManager.RegisterStartupScript(this,GetType(),"ok","alert('Data Sent for Verification From Admin');",true);
                    s_name.Value = "";
                    s_contact.Value = "";
                    s_cnic.Value = "";
                    s_email.Value = "";
                    s_address.Value = "";
                    s_user.Value = "";
                    s_password.Value = "";

                }
            }
        }
        else
        {
            signupErrorMsg.Visible = true;
        }
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        userBlock.Visible = false;
        passwordBlock.Visible = false;
        if (!String.IsNullOrEmpty(username.Value.ToString()))
        {
            if (!String.IsNullOrEmpty(password.Value.ToString()))
            {
                bus_dbEntities db = new bus_dbEntities();
                String user = username.Value.ToString();
                String pass = password.Value.ToString();
                List<tbl_login> dt = (from x in db.tbl_login where x.login_user == user && x.login_password == pass select x).ToList();
                if (dt.Count > 0)
                {
                    
                    HttpCookie login = new HttpCookie("login_data");
                    login.Values.Add("id", dt[0].login_id.ToString());
                    login.Values.Add("user", dt[0].login_user.ToString());
                    login.Values.Add("userId", dt[0].fk_user.ToString());
                    int user_id = (int)dt[0].fk_user;
                    List<tbl_user> dtu = (from x in db.tbl_user where x.user_id == user_id select x).ToList();
                    login.Values.Add("name", dtu[0].user_name.ToString());
                    login.Values.Add("role", dtu[0].fk_type.ToString());
                    login.Values.Add("pwd", password.Value.ToString());
                    login.Expires = DateTime.Now.AddDays(4);
                    Response.Cookies.Add(login);
                    if (dtu[0].fk_type.ToString().Equals("1"))
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Response.Redirect("OnlineBooking.aspx");
                    }
                }
                else
                {
                    loginErrorMsg.Visible = true;
                }
            }
            else
            {
                Page.SetFocus(password);
                passwordBlock.Visible = true;
            }
        }
        else
        {
            Page.SetFocus(username);
            userBlock.Visible = true;
        }
    }
}