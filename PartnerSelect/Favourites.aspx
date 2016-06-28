<%@ Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favourites.aspx.cs" Inherits="PartnerSelect.Favourites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideNavigation" runat="server">
    <!--sidebar start-->
    <aside>
        <div id="sidebar"  class="nav-collapse ">
            <div class="sidebar-menu "> 
                 <div class="form-group ">
                    <div class="col-sm-12">
                        <button type="button" class="btn btn-warning btn-block">Back to Search</button>
                    </div>
                </div>
            </div> 
        </div>
    </aside>
    <!--sidebar end-->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BreadCrumb" runat="server">
    <!-- Breadcrumb -->
    <div class="row">
	    <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-user-md"></i> Favorites</h3>				
		    <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="#">Home</a></li>
                <li><i class="fa fa-star"></i>Favourites</li>
            </ol>
	    </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <span id="noneSelected" runat="server">
    <div class="row">
        <!-- profile-widget -->
        <div class="col-lg-12">
            <div class="profile-widget profile-widget-info">
                    <div class="panel-body">
                    <div class="col-lg-12 col-sm-12 follow-info weather-category">
                                <ul>
                                    <li class="active">                                              
                                        <br>											  
										None Selected
                                    </li>
										   
                                </ul>
                    </div>
                    </div>
            </div>
        </div>
    </div>
    </span>

    <asp:Repeater ID="rptFavourites" runat="server" OnItemDataBound="rptFavourites_ItemDataBound">
        <ItemTemplate>
            <div class="row">
                <!-- profile-widget -->
                <div class="col-lg-12">
                    <div class="profile-widget profile-widget-info">
                          <div class="panel-body">
                            <div class="col-lg-2 col-sm-2">
                              <h4><%# Eval("FirstName") %> <%# Eval("LastName") %></h4>               
                              <div class="follow-ava">
                                  <img src="images/avatar-mini2.jpg" alt="">
                              </div>
                              <h6>Partner</h6>
                            </div>
                            <div class="col-lg-4 col-sm-4 follow-info">
                                <p id="modalOffice">Office: <%# Eval("Office.Name") %></p>
                                <p id="modalDepartment">Deptartment: <%# Eval("Department.Name") %></p>
                                <p id="modalGender">Gender: Male</p>
                                <p id="modalVoting">Voting: <%# Eval("Voting") %></p>
                            </div>
                            <div class="col-lg-6 col-sm-6 follow-info weather-category">
                                      <ul>
                                          <li class="active">                                              
                                              <i class="fa fa-comments fa-2x"> </i><br>											  
											  Good potential candidate, really like this one.
                                          </li>
										   
                                      </ul>
                            </div>
                          </div>
                    </div>
                </div>
    </div>
        </ItemTemplate>
        <SeparatorTemplate><hr /></SeparatorTemplate>        
      
    </asp:Repeater>

</asp:Content>
