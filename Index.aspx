<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Royal Bus - Online Reservation</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/grayscale.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />

    <!-- Data Table -->
    <link href="plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
</head>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">

    <!-- Navigation -->
    <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-main-collapse">
                    <i class="fa fa-bars"></i>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">
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
                        <a class="page-scroll" href="#about">About</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#contact">Schedules</a>
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

    <!-- Intro Header -->
    <header class="intro">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <h1 class="brand-heading">Royal Bus</h1>
                        <p class="intro-text">
                            A free, online bus reservation system<br>
                            Created by Team Effort
                        </p>
                        <a href="#about" class="btn btn-circle page-scroll">
                            <i class="fa fa-angle-double-down animated"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </header>

    <!-- About Section -->
    <section id="about" class="container content-section text-center">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">
                <h2>About Royal Bus</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis massa nulla, consequat eget urna sed, ornare mollis nunc. Vestibulum scelerisque, eros sit amet commodo vehicula, est dui dapibus ex, sit amet rutrum erat lectus sed ex. Mauris venenatis sodales pretium. Vestibulum condimentum massa et imperdiet convallis. Praesent ultrices facilisis sodales. Curabitur vitae lectus ac orci luctus feugiat. Donec laoreet enim sed malesuada luctus. Proin vitae facilisis ex. Nullam ac pharetra lacus, pellentesque tristique eros. Fusce eu eros at tortor tempor sagittis ac nec mauris. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;</p>
            </div>
        </div>
    </section>


    <!-- Download Section -->
    <section id="download" class="content-section text-center">
        <div class="download-section">
            <div class="container">
                <div class="col-lg-8 col-lg-offset-2">
                    
                </div>
            </div>
        </div>
    </section>

    <!-- Schedule Section -->
    <section id="contact" class="container content-section text-center">
        <form id="Form1" runat="server">
            <asp:ScriptManager runat="server" />
            <div class="row">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="col-lg-8 col-lg-offset-2">
                            <h2>Bus Schedules</h2>
                            <p>Feel free to search bus routes and timmings and book now!</p>
                            <div class="panel panel-primary">

                                <div class="panel-heading">
                                    <h2 class="panel-title">Search Schedules</h2>
                                    <br />
                                    <ul class="list-inline banner-social-buttons">
                                        <li>
                                            <label>Departure</label>
                                            <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="bus_dept_SelectedIndexChanged" ID="bus_dept" CssClass="form-control">
                                                <asp:ListItem Text="Lahore" />
                                                <asp:ListItem Text="Islamabad" />
                                            </asp:DropDownList>
                                        </li>
                                        <li>
                                            <label>Arrival</label>
                                            <asp:DropDownList runat="server" ID="bus_arvl" CssClass="form-control">
                                                <asp:ListItem Text="Lahore" />
                                                <asp:ListItem Text="Islamabad" />
                                            </asp:DropDownList>
                                        </li>
                                        <li>
                                            <asp:Button Text="Search" CssClass="btn btn-sm btn-success" OnClick="Unnamed_Click" runat="server" />
                                        </li>
                                    </ul>
                                </div>
                                <div class="panel-body bg-info" style="color:#2a2a2a;">
                                    <asp:GridView runat="server" CssClass="table table-bordered table-condensed grid" AutoGenerateColumns="false" ID="gridview1" OnRowCommand="gridview1_RowCommand">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button Text="Book Now" CssClass="btn btn-warning btn-sm " ID="btn_book" CommandArgument="<%#Container.DataItemIndex%>" CommandName="book" runat="server" />
                                                    <asp:HiddenField ID="schedule_id" runat="server" Value='<%#Eval("ID")%>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Departure" DataField="Source" />
                                            <asp:BoundField HeaderText="Arrival" DataField="Destination" />
                                            <asp:BoundField HeaderText="Bus" DataField="Bus" />
                                            <asp:BoundField HeaderText="Seats" DataField="Seats" />
                                            <asp:BoundField HeaderText="Time"  DataField="Time"/>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </form>
    </section>
    <!-- Download Section -->
    <section id="download1" class="content-section text-center">
        <div class="download-section">
            <div class="container">
                <div class="col-lg-8 col-lg-offset-2">
                    
                </div>
            </div>
        </div>
    </section>
    <!-- Footer -->
    <footer>
        <div class="container text-center">
            <p>Copyright &copy; Royal Bus 2016</p>
        </div>
    </footer>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="js/jquery.easing.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="js/grayscale.js"></script>

    <!-- Data Table JavaScript -->
    <script src="plugins/datatables/jquery.dataTables.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.js"></script>

    <script>
        function pageLoad() {
            $('.grid').dataTable();
        }
    </script>

</body>
</html>
