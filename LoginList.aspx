<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginList.aspx.cs" Inherits="LoginList" MasterPageFile="Master.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">
              Timming List
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
                        <h1 class="panel-title">Login List</h1>
                    </div>  
                    <div class="box-body">
                        <asp:GridView runat="server" ID="grid1" OnRowCommand="grid1_RowCommand" OnRowDataBound="grid1_RowDataBound" CssClass="table table-bordered grid" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Cancel" runat="server" CommandName="canceled" CommandArgument="<%#Container.DataItemIndex%>" ID="btn_cancel" CssClass="btn btn-sm btn-danger" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Verify" runat="server" CommandName="verify" CommandArgument="<%#Container.DataItemIndex%>" ID="btn_verify" CssClass="btn btn-sm btn-success" />
                                        <asp:HiddenField ID="user_id" runat="server" Value='<%#Eval("user_id")%>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Name" DataField="user_name" />
                                <asp:BoundField HeaderText="CNIC" DataField="user_cnic" />
                                <asp:BoundField HeaderText="Contact" DataField="user_contact" />
                                <asp:BoundField HeaderText="Email" DataField="user_email" />
                                <asp:BoundField HeaderText="Address" DataField="user_address" />
                                <asp:BoundField HeaderText="Status" DataField="user_status" />
                                <asp:BoundField HeaderText="User Name" DataField="user_duser" />
                                <asp:BoundField HeaderText="Password" DataField="user_dpassword" /> 
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
<asp:Content runat="server" ContentPlaceHolderID="script">
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
