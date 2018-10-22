<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" MasterPageFile="Master.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
        <link href="css/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
     <div class="row">
        <div class="col-md-12">
            <h1 class="page-header">
             Add User
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
                        <h1 class="panel-title">Add New User</h1>
                    </div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                    <li>
                        <label>Name :</label>
                        <input id="User_name" runat="server" placeholder="Enter Name" class="form-control"/>
                    </li>
                    <li>
                        <label>Contact :</label>
                        <input id="User_contact" runat="server" placeholder="Enter Contact" class="form-control"/>
                    </li>
                    <li>
                        <label>Email :</label>
                        <input id="User_email" runat="server" placeholder="Enter Email" class="form-control"/>
                    </li>
                    <li>
                        <label>Address :</label>
                        <input id="User_address" runat="server" placeholder="Enter Address" class="form-control"/>
                    </li>
                    <li>
                        <label>User Type :</label>
                        <asp:DropDownList runat="server" ID="user_type" CssClass="form-control">
                        </asp:DropDownList>
                    </li>
                    <li>
                        <br />      
                        <asp:Button Text="Submit" ID="btn_add_User" CssClass="btn btn-sm btn-flat btn-primary pull-right" OnClick="btn_add_User_Click" runat="server" />
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
                        <h1 class="panel-title">User List</h1>
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
    <script src="plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/inputmask.js"></script> 
     <script>
         $('.cnic').inputmask("99999-9999999-9", { "placeholder": "____-_______-_" });
         $('.contact').inputmask('0999-9999999', { 'placeholder': '0___-_______' });
         $('.email').inputmask({

             mask: "*{1,20}[.*{1,20}][.*{1,20}][.*{1,20}]@*{1,20}[.*{2,6}][.*{1,2}]",

             greedy: false,

             onBeforePaste: function (pastedValue, opts) {

                 pastedValue = pastedValue.toLowerCase();

                 return pastedValue.replace("mailto:", "");

             },

             definitions: {

                 '*': {

                     validator: "[0-9A-Za-z!#$%&'*+/=?^_`{|}~\-]",

                     cardinality: 1,

                     casing: "lower"

                 }

             }

         });
    </script>
       <script>
        function pageLoad() {
            $('.grid').dataTable();
        }
    </script>
    <script>
        $(".sidebar-menu>li.active").removeClass("active");
        $(".sidebar-menu>ul>li.active").removeClass("active");
        $('.manage').addClass("active");
        $(".nav_user").addClass("active");
    </script>
</asp:Content>
