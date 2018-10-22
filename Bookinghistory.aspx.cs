using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bookinghistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String user_id = Request.Cookies["login_data"]["userId"].ToString();
                int uid= int.Parse(user_id);
                
            bus_dbEntities db = new bus_dbEntities();
            var lgs = (from x in db.tbl_booking
                       join y in db.tbl_schedule on x.fk_schedule equals y.schedule_id
                       join b in db.tbl_bus on y.fk_bus equals b.bus_id
                       join r in db.tbl_route on y.fk_route equals r.route_id
                       join s in db.tbl_station on r.route_source equals s.station_id
                       join d in db.tbl_station on r.route_destination equals d.station_id
                       where x.fk_user == uid
                       select new { x.booking_id,x.booking_datetime,x.booking_seatno,b.bus_name,source=s.station_name,destination=d.station_name}).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
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
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("canceled"))
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            int user_id = int.Parse(((HiddenField)gr.FindControl("booking_id")).Value.ToString());
            bus_dbEntities db = new bus_dbEntities();
            tbl_booking login = (from x in db.tbl_booking where x.booking_id == user_id select x).ToList()[0];
            db.tbl_booking.Remove(login);
            //Save to database
            db.SaveChanges();
            var lgs = (from x in db.tbl_booking
                       join y in db.tbl_schedule on x.fk_schedule equals y.schedule_id
                       join b in db.tbl_bus on y.fk_bus equals b.bus_id
                       join r in db.tbl_route on y.fk_route equals r.route_id
                       join s in db.tbl_station on r.route_source equals s.station_id
                       join d in db.tbl_station on r.route_destination equals d.station_id
                       where x.booking_id == user_id
                       select new { x.booking_id, x.booking_datetime, x.booking_seatno, b.bus_name, source = s.station_name, destination = d.station_name }).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
        else if(e.CommandName.Equals("print"))
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            int user_id = int.Parse(((HiddenField)gr.FindControl("booking_id")).Value.ToString());
            HttpCookie cook = new HttpCookie("printData");
            cook.Value = user_id.ToString();
            Response.Cookies.Add(cook);
            Response.Redirect("PrintSlip.aspx");
        }
    }
    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!String.IsNullOrEmpty(e.Row.Cells[1].Text.ToString()))
            {
                String datetime = e.Row.Cells[1].Text.ToString();

                DateTime dt = DateTime.Parse(datetime);
                Button cancel = (Button)e.Row.FindControl("btn_cancel");
                Button print = (Button)e.Row.FindControl("btn_print");
                if (dt >= DateTime.UtcNow.AddHours(5))
                {
                    cancel.Visible = true;
                    print.Visible = true;
                }
                else
                {
                    cancel.Visible = false;
                    print.Visible = false;
                }
            }
        }
    }
}