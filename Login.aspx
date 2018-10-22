<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>LOGIN - RoyalBus</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/grayscale.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />



    <!-- Data Table -->
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image: url('img/intro-bg.jpg'); background-position: top; background-repeat: no-repeat; background-size: auto;">
    <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-main-collapse">
                    <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand page-scroll" href="Index.aspx">
                    <i class="fa fa-bus fa-2x"></i><span class="light">Royal</span>Bus
                </a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-right navbar-main-collapse">
                <ul class="nav navbar-nav">
                    <!-- Hidden li included to remove active class from about link when scrolled up past about section -->
                    <li class="hidden">
                        <a href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Index.aspx#about">About</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Index.aspx#contact">Schedules</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Login.aspx">Login</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
        <div>
            <div id="login-overlay" style="margin-top:100px;" class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Login to RoyalBus Online Booking</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-6">
                                <p class="lead"><span class="text-success">Registered Users</span></p>
                                <div class="well">

                                    <div class="form-group">
                                        <label for="username" class="control-label">Username</label>
                                        <input type="text" class="form-control" id="username" runat="server" placeholder="Enter Username" />
                                        <span id="userBlock" runat="server" class="help-block text-danger">Please provide a username</span>
                                    </div>
                                    <div class="form-group">
                                        <label for="password" class="control-label">Password</label>
                                        <input type="password" class="form-control" runat="server" id="password" placeholder="Enter Password" />
                                        <span id="passwordBlock" runat="server" class="help-block text-danger">Please provide a password</span>
                                    </div>
                                    <div id="loginErrorMsg" runat="server" class="alert alert-danger">Wrong username or password</div>
                                    <asp:Button Text="Login" CssClass="btn btn-lg btn-block btn-success" ID="btn_login" OnClick="btn_login_Click" runat="server" />

                                </div>
                            </div>
                            <div class="col-xs-6">
                                <p class="lead">Register now for <span class="text-success">FREE</span></p>
                                <div class="well">
                                    <div class="form-group">
                                        <label for="username" class="control-label">Name *</label>
                                        <input type="text" class="form-control" id="s_name" runat="server" placeholder="Enter Name" />
                                        <span id="nameErr" runat="server" class="help-block">Please provide a name</span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" class="control-label">Contact *</label>
                                        <input type="text" class="form-control contact" id="s_contact" runat="server" placeholder="Enter Mobile No." />
                                        <span id="contactErr" runat="server" class="help-block">Please provide a contact no.</span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" class="control-label">CNIC *</label>
                                        <input type="text" class="form-control cnic" id="s_cnic" runat="server" placeholder="Enter CNIC No." />
                                        <span id="cnicErr" runat="server" class="help-block">Please provide a CNIC</span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" class="control-label">Email</label>
                                        <input type="text" class="form-control email" id="s_email" runat="server" placeholder="Enter Email" />
                                        <span class="help-block"></span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" class="control-label">Address</label>
                                        <input type="text" class="form-control" id="s_address" runat="server" placeholder="Enter Address" />
                                        <span class="help-block"></span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" class="control-label">Desired Username *</label>
                                        <input type="text" class="form-control" id="s_user" runat="server" placeholder="Enter Username" />
                                        <span id="usernameErr" runat="server" class="help-block">Please provide a username</span>
                                    </div>
                                    <div class="form-group">
                                        <label for="username" class="control-label">Desired Password *</label>
                                        <input type="text" class="form-control" id="s_password" runat="server" placeholder="Enter Password" />
                                        <span id="passwordErr" runat="server" class="help-block">Please provide a password</span>
                                    </div>
                                    <div id="signupErrorMsg" runat="server" class="alert alert-danger">Please Provide All Fields</div>
                                    <div id="signupErrorMsg2" runat="server" class="alert alert-danger">Username already reserved</div>
                                    <div id="signupErrorMsg3" runat="server" class="alert alert-danger">CNIC already registered</div>
                                    <asp:Button Text="Sign Up" ID="btn_signup" OnClick="btn_signup_Click" CssClass="btn btn-lg btn-block btn-primary" runat="server" />
                                    <br />
                                    <p class="alert alert-info">Fields marked with <strong>*</strong> are compulsory.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/inputmask.js"></script>

    <script>
        function pageLoad() {
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
        }
    </script>
</body>
</html>
