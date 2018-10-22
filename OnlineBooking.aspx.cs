using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlineBooking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["login_data"] != null)
        {
            if (!IsPostBack)
            {
                bus_dbEntities db = new bus_dbEntities();

                String user_id = Request.Cookies["login_data"]["userId"].ToString();
                int uid= int.Parse(user_id);
                var userData = (from x in db.tbl_user where x.user_id == uid select x).ToList()[0];
                c_cnic.Value = userData.user_cnic;
                c_name.Value = userData.user_name;
                c_contact.Value = userData.user_contact;


                var stations = (from x in db.tbl_station select x).ToList();

                b_dept.DataSource = stations;
                b_dept.DataTextField = "station_name";
                b_dept.DataValueField = "station_id";
                b_dept.DataBind();
                b_dept.SelectedIndex = 0;

                int source = int.Parse(b_dept.SelectedValue.ToString());
                var dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
                b_arrv.DataSource = dest;
                b_arrv.DataTextField = "station_name";
                b_arrv.DataValueField = "station_id";
                b_arrv.DataBind();
                int destination = int.Parse(b_arrv.SelectedValue.ToString());

                var buses = (from x in db.tbl_schedule
                             join y in db.tbl_bus on x.fk_bus equals y.bus_id
                             join z in db.tbl_route on x.fk_route equals z.route_id
                             where z.route_source == source && z.route_destination == destination
                             select y).Distinct().ToList();
                b_bus.DataSource = buses;
                b_bus.DataTextField = "bus_name";
                b_bus.DataValueField = "bus_id";
                b_bus.DataBind();

                int bus = int.Parse(b_bus.SelectedValue.ToString());
                var timming = (from x in db.tbl_schedule
                               join y in db.tbl_bus on x.fk_bus equals y.bus_id
                               join z in db.tbl_route on x.fk_route equals z.route_id
                               join a in db.tbl_station on z.route_source equals a.station_id
                               join b in db.tbl_station on z.route_destination equals b.station_id
                               where a.station_id == source && b.station_id == destination && y.bus_id == bus
                               select x.schedule_time).ToList();
                b_time.DataSource = timming;
                b_time.DataBind();

                if(Request.Cookies["bookingData"]!=null)
                {
                    int id = int.Parse(Request.Cookies["bookingData"]["scheduleid"].ToString());
                    var d_source = (from x in db.tbl_schedule
                                  join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                  join z in db.tbl_route on x.fk_route equals z.route_id
                                  join a in db.tbl_station on z.route_source equals a.station_id
                                  join b in db.tbl_station on z.route_destination equals b.station_id
                                  where x.schedule_id==id
                                  select a.station_id).ToList()[0];
                    source = int.Parse(d_source.ToString());
                    b_dept.ClearSelection();
                    b_dept.Items.FindByValue(d_source.ToString()).Selected = true;
                    dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
                    b_arrv.DataSource = dest;
                    b_arrv.DataTextField = "station_name";
                    b_arrv.DataValueField = "station_id";
                    b_arrv.DataBind();
                
                    var d_dest = (from x in db.tbl_schedule
                                    join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                    join z in db.tbl_route on x.fk_route equals z.route_id
                                    join a in db.tbl_station on z.route_source equals a.station_id
                                    join b in db.tbl_station on z.route_destination equals b.station_id
                                    where x.schedule_id == id
                                    select b.station_id).ToList()[0];
                    b_arrv.ClearSelection();
                    b_arrv.Items.FindByValue(d_dest.ToString()).Selected = true;
                    destination = int.Parse(d_dest.ToString());

                    buses = (from x in db.tbl_schedule
                                 join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                 join z in db.tbl_route on x.fk_route equals z.route_id
                                 where z.route_source == source && z.route_destination == destination
                                 select y).ToList();
                    b_bus.DataSource = buses;
                    b_bus.DataTextField = "bus_name";
                    b_bus.DataValueField = "bus_id";
                    b_bus.DataBind();
                    
                    var d_bus = (from x in db.tbl_schedule
                                    join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                    join z in db.tbl_route on x.fk_route equals z.route_id
                                    join a in db.tbl_station on z.route_source equals a.station_id
                                    join b in db.tbl_station on z.route_destination equals b.station_id
                                    where x.schedule_id == id
                                    select y.bus_id).ToList()[0];
                    b_bus.ClearSelection();
                    b_bus.Items.FindByValue(d_bus.ToString()).Selected = true;
                    bus = int.Parse(b_bus.SelectedValue.ToString());
                    timming = (from x in db.tbl_schedule
                                   join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                   join z in db.tbl_route on x.fk_route equals z.route_id
                                   join a in db.tbl_station on z.route_source equals a.station_id
                                   join b in db.tbl_station on z.route_destination equals b.station_id
                                   where a.station_id == source && b.station_id == destination && y.bus_id == bus
                                   select x.schedule_time).ToList();
                    b_time.DataSource = timming;
                    b_time.DataBind();
                    var d_time = (from x in db.tbl_schedule
                                    join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                    join z in db.tbl_route on x.fk_route equals z.route_id
                                    join a in db.tbl_station on z.route_source equals a.station_id
                                    join b in db.tbl_station on z.route_destination equals b.station_id
                                    where x.schedule_id == id
                                    select x.schedule_time).ToList()[0];
                    b_time.ClearSelection();
                    b_time.Items.FindByText(d_time.ToString()).Selected = true;
                }

            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    
    protected void b_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        bus_dbEntities db =new bus_dbEntities();
        int source = int.Parse(b_dept.SelectedValue.ToString());
        var dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
        b_arrv.DataSource = dest;
        b_arrv.DataTextField = "station_name";
        b_arrv.DataValueField = "station_id";
        b_arrv.DataBind();
        int destination = int.Parse(b_arrv.SelectedValue.ToString());

        var buses = (from x in db.tbl_schedule
                     join y in db.tbl_bus on x.fk_bus equals y.bus_id
                     join z in db.tbl_route on x.fk_route equals z.route_id
                     where z.route_source == source && z.route_destination == destination
                     select y).ToList();
        b_bus.DataSource = buses;
        b_bus.DataTextField = "bus_name";
        b_bus.DataValueField = "bus_id";
        b_bus.DataBind();

        int bus = int.Parse(b_bus.SelectedValue.ToString());
        var timming = (from x in db.tbl_schedule
                       join y in db.tbl_bus on x.fk_bus equals y.bus_id
                       join z in db.tbl_route on x.fk_route equals z.route_id
                       join a in db.tbl_station on z.route_source equals a.station_id
                       join b in db.tbl_station on z.route_destination equals b.station_id
                       where a.station_id == source && b.station_id == destination && y.bus_id == bus
                       select x.schedule_time).ToList();
        b_time.DataSource = timming;
        b_time.DataBind();
    }
    protected void b_bus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        int bus = int.Parse(b_bus.SelectedValue.ToString());
        int source = int.Parse(b_dept.SelectedValue.ToString());
        int destination = int.Parse(b_arrv.SelectedValue.ToString());

        var timming = (from x in db.tbl_schedule
                       join y in db.tbl_bus on x.fk_bus equals y.bus_id
                       join z in db.tbl_route on x.fk_route equals z.route_id
                       join a in db.tbl_station on z.route_source equals a.station_id
                       join b in db.tbl_station on z.route_destination equals b.station_id
                       where a.station_id == source && b.station_id == destination && y.bus_id == bus
                       select x.schedule_time).ToList();
        b_time.DataSource = timming;
        b_time.DataBind();
    }
    protected void b_arrv_SelectedIndexChanged(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        int source = int.Parse(b_dept.SelectedValue.ToString());
        int destination = int.Parse(b_arrv.SelectedValue.ToString());

        var buses = (from x in db.tbl_schedule
                     join y in db.tbl_bus on x.fk_bus equals y.bus_id
                     join z in db.tbl_route on x.fk_route equals z.route_id
                     where z.route_source == source && z.route_destination == destination
                     select y).ToList();
        b_bus.DataSource = buses;
        b_bus.DataTextField = "bus_name";
        b_bus.DataValueField = "bus_id";
        b_bus.DataBind();

        int bus = int.Parse(b_bus.SelectedValue.ToString());
        var timming = (from x in db.tbl_schedule
                       join y in db.tbl_bus on x.fk_bus equals y.bus_id
                       join z in db.tbl_route on x.fk_route equals z.route_id
                       join a in db.tbl_station on z.route_source equals a.station_id
                       join b in db.tbl_station on z.route_destination equals b.station_id
                       where a.station_id == source && b.station_id == destination && y.bus_id == bus
                       select x.schedule_time).ToList();
        b_time.DataSource = timming;
        b_time.DataBind();
    }
    [WebMethod]
    public static string[] getPlan(String name, String deptarture, String arrival , String time, String date)
    {
        bus_dbEntities db = new bus_dbEntities();
        int bus = int.Parse(name);
        int dept = int.Parse(deptarture);
        int arr = int.Parse(arrival);
        string datetime = date + " " + time;
        DateTime interval =  DateTime.Parse(datetime);
        int schedule_id = (from x in db.tbl_schedule
                           join y in db.tbl_route on x.fk_route equals y.route_id
                           join a in db.tbl_bus on x.fk_bus equals a.bus_id
                           where y.route_source==dept && y.route_destination==arr && a.bus_id==bus
                           select x).ToList()[0].schedule_id;
        List<pr_get_seats_Result> seatList = db.pr_get_seats(schedule_id, interval).ToList();
        int i = 0;
        String[] toreturn = new String[seatList.Count()];
        foreach(pr_get_seats_Result seat in seatList)
        {
            String s = seat.seat_name + ";" + seat.seat_status;
            toreturn[i] = s;
            i++;
        }

        return toreturn;
    }
    [WebMethod]
    public static void reserve(String name, String deptarture, String arrival, String time, String date,String seat,String cnic)
    {
        
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        String seatData = seatList.Value;
        foreach(String s in seatData.Split(';'))
        {
            if(!String.IsNullOrEmpty(s))
            {
                tbl_booking d = new tbl_booking();
                int bus = int.Parse(b_bus.SelectedValue.ToString());
                int dst = int.Parse(b_arrv.SelectedValue.ToString());
                int src = int.Parse(b_dept.SelectedValue.ToString());
                int route = (from x in db.tbl_route where x.route_source == src && x.route_destination == dst select x).ToList()[0].route_id;
                d.booking_datetime = DateTime.Parse(b_date.Value.ToString() +" "+ b_time.SelectedItem.Text.ToString());
                int seat = int.Parse(s);
                d.booking_seatno = seat;
                string cnic = c_cnic.Value.ToString();
                d.fk_user = (from x in db.tbl_user where x.user_cnic == cnic select x).ToList()[0].user_id;
                d.fk_schedule = (from x in db.tbl_schedule
                                 join y in db.tbl_bus on x.fk_bus equals y.bus_id
                                 join z in db.tbl_route on x.fk_route equals z.route_id
                                 join a in db.tbl_station on z.route_source equals a.station_id
                                 join b in db.tbl_station on z.route_destination equals b.station_id
                                 where a.station_id == src && b.station_id == dst && y.bus_id == bus
                                 select x.schedule_id).ToList()[0];
                db.tbl_booking.Add(d);
                db.SaveChanges();
                ScriptManager.RegisterStartupScript(this,GetType(),"ok","alert('Seats Reserved Successfully. You can print the receipt from booking history.');",true);
                seatList.Value = "";
                b_date.Value = "";
            }
        }
    }
}