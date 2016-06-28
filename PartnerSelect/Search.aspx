<%@ Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="PartnerSelect.Search" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script type="text/javascript" language="javascript">

            // Confirm with user and then delete from database and remove row
            function UpdateFavourites(id) {
                alert($('#hidFavsCount').val());
                $.post('UpdateFavourite.aspx?Id=' + id)
                .done(function () {
                    //var row = $('table#tblSearch tr#row' + id);
                    //row.css("background-color", "yellow");

                    $('[id$=lblFavouritesCount]').text($('#hidFavsCount').val());
                    
                })
                .fail(function (xhr) {
                    DisplayError(location, xhr.responseText);
                });
                
            }


            function FurtherInfo2(id) {
                $.ajax({
                    type: 'POST',
                    url: 'Lookup.aspx/GetPersonById',
                    data: JSON.stringify({ id: id }),
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (response) {
                        var person = jQuery.parseJSON(response.d);
                        $("#myModal").modal({ backdrop: "static" });
                        $("#modelTitle").text(person[0].FirstName + " " + person[0].LastName);
                        $("#modalOffice").text("Office: " + person[0].Office.Name);
                        $("#modalDepartment").text("Department: " + person[0].Department.Name);
                        $("#modelTelNo").text("Tel: " + person[0].TelNo);
                        $("#modalEmailAddress").text("Email: " + person[0].Email);
                        $("#modalGender").text("Gender: " + person[0].Gender);
                        $("#modalVoting").text("Voting: " + FormatTrueFalseToYesNo(person[0].Voting));
                    },
                    error: function (xhr) {
                        DisplayError(location, xhr.responseText);
                    }
                });
            }

        </script>
    </asp:Content>
         
    <asp:Content ID="Content4" ContentPlaceHolderID="SideNavigation" runat="server">

      <!--sidebar start-->
      <aside>
          <div id="sidebar"  class="nav-collapse ">
            <form class="form-horizontal " role="form" action="Search.aspx" method="post" runat="server">
                <div class="sidebar-menu ">                                                
                    <div class="form-group ">
                        <label class="col-sm-4 control-label">First Name</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="txtFirstName" placeholder="First name" runat="server" />
                        </div>
                    </div>
                    <div class="form-group ">
                        <label class="col-sm-4 control-label">Last Name</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="txtSurname" placeholder="Surname" runat="server"/>
                        </div>
                    </div>
                    <div class="form-group ">
                        <label class="col-sm-4 control-label">Offices</label>
                        <div class="col-sm-8">
                            <select id="lstOffices" class="form-control " runat="server" />
                        </div>
                    </div>
                    <div class="form-group ">
                        <label class="col-sm-4 control-label">Departments</label>
                        <div class="col-sm-8">
                            <select id="lstDepartments" class="form-control " runat="server" />
                        </div>
                    </div>
                    <div class="form-group ">
                        <label class="col-sm-4 control-label">Gender</label>
                        <div class="col-sm-8">
                            <select id="lstGender" class="form-control " runat="server">
                                <option>All</option>
                                <option>Female</option>
                                <option>Male</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group ">
                        <label class="col-sm-4 control-label">Voting</label>
                        <div class="col-sm-8">
                            <select id="lstVoting" class="form-control " runat="server">
                                <option>All</option>
                                <option>Yes</option>
                                <option>No</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group ">
                        <div class="col-sm-12">
                            <button type="submit" class="btn btn-warning btn-block">Search</button>
                        </div>
                    </div>  
                    <div class="form-group ">
                        <div class="col-sm-12">
                            <asp:Button ID="btnReset" class="btn btn-default btn-block" runat="server" Text="Reset" onclick="btnReset_Click"></asp:Button>
                        </div>
                    </div>      
                </div>
            </form>
          </div>
      </aside>
      <!--sidebar end-->
    </asp:Content>

    <asp:Content ID="Content3" ContentPlaceHolderID="BreadCrumb" runat="server">
    <!-- Breadcrumb -->
    <div class="row">
	    <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-table"></i> Search</h3>				
		    <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="#">Home</a></li>
                <li><i class="fa fa-table"></i>Search</li>
                <!--<li><i class="fa fa-th-list"></i>Results</li>-->
            </ol>
	    </div>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <input type="hidden" id="hidFavsCount" value="2"></input>
            <!-- Results-->
            <div class="table-responsive">
                    <asp:Repeater ID="rptSearch" runat="server" OnItemDataBound="rptSearch_ItemDataBound">
                        <HeaderTemplate>
                            <table class="table table-hover" id="tblSearch">
                                <thead>
                                    <tr>
                                        <th><i class="fa fa-star"></i></th>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                        <th>Office</th>
                                        <th>Department</th>
                                        <th>Gender</th>
                                        <th>Voting</th>
                                        <th>View Profile</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr id="row<%# Eval("EmployeeNumber") %>">
                                <td><asp:HyperLink ID="lnkFavouritesIndicator" runat="server" class="fa fa-star-o"></asp:HyperLink></td>
                                <td><%# Eval("FirstName") %></td>
                                <td><%# Eval("LastName") %></td>
                                <td><%# Eval("Office.Name") %></td>
                                <td><%# Eval("Department.Name") %></td>
                                <td><asp:Label ID="lblGender" runat="server"></asp:Label></td>
                                <td><%# Eval("Voting") %></td>                                
                                <td><asp:HyperLink ID="lnkFurtherInfo" runat="server">View profile</asp:HyperLink></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>


    <!-- Modal -->
    <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button aria-hidden="true" data-dismiss="modal" class="close" type="button">×</button>
                    <h4 class="modal-title" id="modelTitle"></h4>
                </div>
                <div class="modal-body">
                    <!-- profile-widget -->
                    <div class="profile-widget profile-widget-info">
                            <div class="panel-body">
                            <div class="col-lg-3 col-sm-3">
                                <div class="follow-ava">
                                    <img src="images/profile-widget-avatar.jpg" alt="" />
                                </div>
                                <h6>Partner</h6>
                            </div>
                            <div class="col-lg-9 col-sm-9 follow-info">
                                <p id="modalOffice" />
                                <p id="modalDepartment" />
                                <p id="modelTelNo" />
                                <p id="modalEmailAddress" />
                                <p id="modalGender" />
                                <p id="modalVoting" />
                            </div>
                            </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default" type="button">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- modal -->
  
</asp:Content>