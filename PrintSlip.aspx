<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSlip.aspx.cs" Inherits="PrintSlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Slip</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="plugins/metisMenu/src/metisMenu.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/sb-admin-2.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="row container-fluid">
            <div class="col-lg-12">
               <p></p>
            </div> 
        </div>
    <div class="row container-fluid">
        <div class="col-md-4"> 
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h1 class="panel-title">Booking Slip</h1>
                </div>
                <div class="panel-body">
                    <ul class="list-unstyled">
                        <li>
                            <label>Sr#</label>
                            <label id="bookin_id" runat="server" class="form-control"></label>
                        </li>
                        
                        <li>
                            <label>Booking By:</label>
                            <label id="bookin_name" runat="server" class="form-control"></label>
                        </li>
                        <li>
                            <label>CNIC :</label>
                            <label id="bookin_cnic" runat="server" class="form-control"></label>
                        </li>
                        <li>
                            <label>From :</label>
                            <label id="bookin_from" runat="server" class="form-control"></label>
                        </li>
                        <li>
                            <label>To :</label>
                            <label id="bookin_to" runat="server" class="form-control"></label>
                        </li>
                        
                        <li>
                            <label>Bus No :</label>
                            <label id="bookin_bus" runat="server" class="form-control"></label>
                        </li>
                        <li>
                            <label>Date Time</label>
                            <label id="bookin_date" runat="server" class="form-control"></label>
                        </li>
                        
                    </ul>
                </div>
                <div class="panel-footer">
                    <span>
                        Please reach the counter 30 min before the departure. Bring this slip along for confirmation of booking.
                    </span>
                </div>
            </div>
        </div> 
    </div>
    </form>
    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="plugins/metisMenu/src/metisMenu.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="plugins/Rapheal/Rapheal.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.js"></script>
</body>
</html>
