<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlineBooking.aspx.cs" Inherits="OnlineBooking" MasterPageFile="~/Customer.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="plugins/datepicker/datepicker3.css" rel="stylesheet" />
    <link href="plugins/timepicker/bootstrap-timepicker.css" rel="stylesheet" />
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <style>
        .floorplan
        {
            width:100%;
            height:950px;
            overflow:auto;
            background-color:#fff;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Online Booking</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="panel-title">
                        Booking Information
                    </h1>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                        <h4>Customer Info</h4>
                        <ul class="list-unstyled">
                            <li>
                                <label>Name:</label>
                                <input id="c_name" runat="server" class="form-control"/>
                            </li>
                            <li>
                                <label>CNIC:</label>
                                <input id="c_cnic" runat="server" class="form-control"/>
                            </li>
                            <li>
                                <label>Contact:</label>
                                <input id="c_contact" runat="server" class="form-control"/>
                            </li>
                        </ul>
                        </div>
                    </div>
                    <div class="dividr"></div>
                    <div class="row">
                        <div class="col-md-12">
                        <h4>Bus Info</h4>
                        <ul class="list-unstyled">
                            <li>
                                <label>Departure:</label>
                                <asp:DropDownList runat="server" ID="b_dept" AutoPostBack="true" OnSelectedIndexChanged="b_dept_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Arrival:</label>
                                <asp:DropDownList runat="server" ID="b_arrv" AutoPostBack="true" OnSelectedIndexChanged="b_arrv_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Bus Name:</label>
                                <asp:DropDownList runat="server" ID="b_bus" AutoPostBack="true" OnSelectedIndexChanged="b_bus_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Departure Time:</label>
                                <asp:DropDownList runat="server" ID="b_time" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Departure Date:</label>
                                <input id="b_date" runat="server" class="form-control date"/>
                            </li>
                        </ul>
                        </div>
                    </div>
                    <div class="dividr"></div>
                    <div class="row">
                        <div class="col-md-12">
                        <h4>Seats Reserved</h4>
                            <input id="seatList" runat="server" name="seatList" class="form-control" />
                        </div>
                        <br />
                        <div class="col-lg-12">
                            <br />
                            <asp:Button Text="Submit" ID="submit" OnClick="submit_Click" CssClass="btn btn-lg btn-primary pull-right" runat="server" />    
                        </div>
                    </div>
                </div>
            </div> 
        </div> 
        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
            <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">Select Seats</h4>
                        
                        <button class="btn btn-sm btn-warning pull-right" type="button" onclick="create_floorPlan();">Get Seat Info</button>
                        <br />
                        <br />
                    </div>
                    <div class="panel-body">
                        <div id="canvas_container" class=" floorplan container-fluid col-lg-12">
                            
                        </div>
                    </div>
                </div>
        </div> 
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="scripts" runat="server">
    <script src="plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="plugins/timepicker/bootstrap-timepicker.js"></script>
    <script src="plugins/datatables/jquery.dataTables.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="plugins/Rapheal/Rapheal.js"></script>
    <script>
        window.onload = function () {

            $('.time').timepicker({
                showInputs: false
            });
            
            $('.date').datepicker({
                startDate: 'today',
                endDate:'+2w'
            });
            $('.grid').dataTable();
        };
        var table = [];
        var counter = 0;
        function create_floorPlan() {

            

            counter = 0;
            var e = document.getElementById("<%=b_bus.ClientID%>");
            var bus_name = e.options[e.selectedIndex].value;
            var e = document.getElementById("<%=b_dept.ClientID%>");
            var dept = e.options[e.selectedIndex].value;
            var e = document.getElementById("<%=b_arrv.ClientID%>");
            var arr = e.options[e.selectedIndex].value;
            var e = document.getElementById("<%=b_time.ClientID%>");
            var time = e.options[e.selectedIndex].value;
            var date = document.getElementById("<%=b_date.ClientID%>").value;
            if (date == '' || date == null) {
                alert('Please enter a date first.');
            }
            else {
                get_data(bus_name, dept, arr, time, date);
            }
            return false;
        }
        function get_data(name, dept, arrv, time, date) {
            PageMethods.getPlan(name, dept, arrv, time, date, onsuccess, onfailure);
        }
        function onsuccess(result, userContext, methodName) {
            var canvas = document.getElementById('canvas_container');
            img = new Image();
            img.src = 'img/bus.jpg';
            var paper = new Raphael(canvas, 400, 900);
            var bacImg = paper.image('img/bus.jpg', 0, 0, 400, 900);

            var x = 0;
            for (var i = 0; i <= 9 ; i++) {
                var seat = paper.rect(55, 215 + (i * 65), 50, 60);
                var tl = x
                var status = result[x].split(';')[1];
                if (status == 'a') {
                    seat.attr({ stroke: '#4cae4c', fill: '#4cae4c', 'fill-opacity': 0.5, 'stroke-width': 4, 'title': tl });
                    seat.node.onclick = function () {
                        this.style.cursor = 'pointer';
                        showData(this);
                    };
                }
                else
                    seat.attr({ stroke: '#ff0000', fill: '#ff0000', 'stroke-width': 4, 'title': tl, 'fill-opacity': 0.7 });
                table[x] = result[x];
                x++;
            }
            for (var i = 0; i <= 10 ; i++) {
                var seat = paper.rect(115, 150 + (i * 65), 50, 60);
                var tl = x
                var status = result[x].split(';')[1];
                if (status == 'a') {
                    seat.attr({ stroke: '#4cae4c', fill: '#4cae4c', 'fill-opacity': 0.5, 'stroke-width': 4, 'title': tl });
                    seat.node.onclick = function () {
                        this.style.cursor = 'pointer';
                        showData(this);
                    };
                }
                else
                    seat.attr({ stroke: '#ff0000', fill: '#ff0000', 'stroke-width': 4, 'title': tl, 'fill-opacity': 0.7 });
                table[x] = result[x];
                x++;
            }
            for (var i = 0; i <= 10 ; i++) {

                var seat = paper.rect(232, 150 + (i * 65), 50, 60);
                var tl = x
                var status = result[x].split(';')[1];
                if (status == 'a') {
                    seat.attr({ stroke: '#4cae4c', fill: '#4cae4c', 'fill-opacity': 0.5, 'stroke-width': 4, 'title': tl });
                    seat.node.onclick = function () {
                        this.style.cursor = 'pointer';
                        showData(this);
                    };
                }
                else
                    seat.attr({ stroke: '#ff0000', fill: '#ff0000', 'stroke-width': 4, 'title': tl, 'fill-opacity': 0.7 });
                table[x] = result[x];
                x++;
            }
            for (var i = 0; i <= 10 ; i++) {

                var seat = paper.rect(292, 150 + (i * 65), 50, 60);
                var tl = x
                var status = result[x].split(';')[1];
                if (status == 'a') {
                    seat.attr({ stroke: '#4cae4c', fill: '#4cae4c', 'fill-opacity': 0.5, 'stroke-width': 4, 'title': tl });
                    seat.node.onclick = function () {
                        this.style.cursor = 'pointer';
                        showData(this);
                    };
                }
                else {
                    seat.attr({ stroke: '#ff0000', fill: '#ff0000', 'stroke-width': 4, 'title': tl, 'fill-opacity': 0.7 });
                }
                
                table[x] = result[x];
                x++;
            }

        }
        function test(paper) {

        }
        function onfailure(response) {
            alert('There is some error:' + response.get_message());
        }
        
        function showData(data) {
            var index = data.children[0].innerHTML;
            var name = table[index].split(';')[0];
            counter++;
            if (counter <= 6) {
                document.getElementById('body_seatList').value += name + ';';
            }
            else
            {
                alert('You can only select maximum of 6 seats in a single booking.');
            }
        }
    </script>
</asp:Content>
