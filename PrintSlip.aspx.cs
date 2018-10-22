using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintSlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Cookies["printData"]!=null)
        {
            if (!IsPostBack)
            {
                String id = Request.Cookies["printData"].Value;
                int schedule_id = int.Parse(id);
                bookin_id.InnerText = id;
                String name = "Nil";
                String cnic = "Nil";
                String source = "Nil";
                String destination = "Nil";
                String datetime = "Nil";
                String bus = "Nil";
                bus_dbEntities db = new bus_dbEntities();

                int userid = (int)(from x in db.tbl_booking where x.booking_id == schedule_id select x.fk_user).ToList()[0];
                DateTime dtime = (DateTime) (from x in db.tbl_booking where x.booking_id == schedule_id select x.booking_datetime).ToList()[0];
                bus = (from x in db.tbl_booking
                       join y in db.tbl_schedule on x.fk_schedule equals y.schedule_id
                       join b in db.tbl_bus on y.fk_bus equals b.bus_id
                       where x.booking_id == schedule_id select b.bus_name).ToList()[0].ToString();
                source = (from x in db.tbl_booking
                       join y in db.tbl_schedule on x.fk_schedule equals y.schedule_id
                       join b in db.tbl_route on y.fk_route equals b.route_id
                       join a in db.tbl_station on b.route_source equals a.station_id
                       where x.booking_id == schedule_id
                       select a.station_name).ToList()[0].ToString();
                destination = (from x in db.tbl_booking
                          join y in db.tbl_schedule on x.fk_schedule equals y.schedule_id
                          join b in db.tbl_route on y.fk_route equals b.route_id
                          join a in db.tbl_station on b.route_destination equals a.station_id
                          where x.booking_id == schedule_id
                          select a.station_name).ToList()[0].ToString();
                List<tbl_user> userList = (from x in db.tbl_user where x.user_id == userid select x).ToList();
                name = userList[0].user_name;
                cnic = userList[0].user_cnic;

                bookin_name.InnerText = name;
                bookin_cnic.InnerText = cnic;
                bookin_date.InnerText = dtime.ToString("yyyy-MM-dd HH:mm:ss");
                bookin_bus.InnerText = bus;
                bookin_from.InnerText = source;
                bookin_to.InnerText = destination;
             }
        }
    }
}