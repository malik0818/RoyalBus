<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Schedule.aspx.cs" Inherits="Schedule" MasterPageFile="Master.master" %>



<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
     <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">
              Schedule List 
            </h1>
        </div>
    </div>
    <!-- Main content -->
    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h1 class="panel-title">Add New Schedule</h1>
                    </div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                            <li>
                                <label>Schedule Source :</label>
                                <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="Schedule_Source_SelectedIndexChanged" ID="Schedule_Source" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Schedule Destination :</label>
                                <asp:DropDownList runat="server" ID="Schedule_Destination" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Bus :</label>
                                <asp:DropDownList runat="server" ID="Schedule_bus" CssClass="form-control">
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>Timming :</label>
                                <asp:DropDownList runat="server" ID="Schedule_timming" CssClass="form-control">
                                </asp:DropDownList>
                            </li>

                            <li>
                                <br />
                                <asp:Button Text="Submit" ID="btn_add_Schedule" CssClass="btn btn-sm btn-flat btn-primary pull-right" OnClick="btn_add_Schedule_Click" runat="server" />
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h1 class="panel-title">Schedule List</h1>
                    </div>
                    <div class="panel-body">
                        <asp:GridView runat="server" ID="grid1" CssClass="table table-bordered grid">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="script">
    <script src="plugins/datatables/jquery.dataTables.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.js"></script>
    <script>
        function pageLoad() {
            $('.grid').dataTable();
        }
    </script>
    <script>
        $(".sidebar-menu>li.active").removeClass("active");
        $(".sidebar-menu>ul>li.active").removeClass("active");
        $('.manage').addClass("active");
        $(".nav_schedule").addClass("active");
    </script>
</asp:Content>
