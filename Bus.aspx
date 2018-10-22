<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bus.aspx.cs" Inherits="Bus" MasterPageFile="Master.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">Bus List
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
                        <h1 class="panel-title">Add New Bus</h1>
                    </div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                            <li>
                                <label>Name :</label>
                                <input id="Bus_name" runat="server" placeholder="Enter Name" class="form-control" />
                            </li>
                            <li>
                                <label>Driver Name :</label>
                                <input id="Bus_driver" runat="server" placeholder="Enter Driver Name" class="form-control" />
                            </li>
                            <li>
                                <label>Driver Contact :</label>
                                <input id="Bus_contact" runat="server" placeholder="Enter Contact" class="contact form-control" />
                            </li>
                            <li>
                                <label>Capacity :</label>
                                <input id="Bus_capacity" runat="server" placeholder="Enter Capacity" class="cap form-control" />
                            </li>
                            <li>
                                <br />
                                <asp:Button Text="Submit" ID="btn_add_Station" CssClass="btn btn-sm btn-flat btn-primary pull-right" OnClick="btn_add_Station_Click" runat="server" />
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
                        <h1 class="panel-title">Bus List</h1>
                    </div>
                    <div class="box-body">
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
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/inputmask.js"></script>
    
    <script>
        function pageLoad() {
            $('.grid').dataTable();
            $('.contact').inputmask('0999-9999999', { 'placeholder': '0___-_______' });
            $('.cap').inputmask('99', { 'placeholder': '__' });
        }
    </script>
</asp:Content>
