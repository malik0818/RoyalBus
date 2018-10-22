<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bookinghistory.aspx.cs" Inherits="Bookinghistory" MasterPageFile="Customer.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">
              Booking History
            </h1>
        </div>
    </div>

    <!-- Main content -->
    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h1 class="panel-title">Booking History</h1>
                    </div>  
                    <div class="box-body">
                        <asp:GridView runat="server" ID="grid1" OnRowCommand="grid1_RowCommand" OnRowDataBound="grid1_RowDataBound" CssClass="table table-bordered grid" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Cancel" runat="server" CommandName="canceled" CommandArgument="<%#Container.DataItemIndex%>" ID="btn_cancel" CssClass="btn btn-sm btn-danger" />
                                        <asp:HiddenField ID="booking_id" runat="server" Value='<%#Eval("booking_id")%>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Print" runat="server" CommandName="print" CommandArgument="<%#Container.DataItemIndex%>" ID="btn_print" CssClass="btn btn-sm btn-primary" />
                                        <asp:HiddenField ID="print_id" runat="server" Value='<%#Eval("booking_id")%>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Datetime" DataField="booking_datetime"/>
                                <asp:BoundField HeaderText="Seat No." DataField="booking_seatno" />
                                <asp:BoundField HeaderText="Bus" DataField="bus_name" />
                                <asp:BoundField HeaderText="Source" DataField="source" />
                                <asp:BoundField HeaderText="Destination" DataField="destination" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="scripts">
    <script src="plugins/datatables/jquery.dataTables.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/inputmask.js"></script>
    <script>
        function pageLoad() {
            $('.grid').dataTable();
        }
    </script>
</asp:Content>
