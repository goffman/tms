<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" MasterPageFile="~/admin/Admin.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="row-fluid">
        <div class="span6">
            <!-- block -->
            <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">Users</div>
                    <div class="pull-right">
                        <span class="badge badge-info">1,234</span>

                    </div>
                </div>
                <div class="block-content collapse in">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"></asp:GridView>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Username</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Mark</td>
                                <td>Otto</td>
                                <td>@mdo</td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>Jacob</td>
                                <td>Thornton</td>
                                <td>@fat</td>
                            </tr>
                            <tr>
                                <td>3</td>
                                <td>Vincent</td>
                                <td>Gabriel</td>
                                <td>@gabrielva</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

       
            <!-- /block -->
        </div>
        <div class="span6">
            <!-- block -->
            <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">Orders</div>
                    <div class="pull-right">
                        <span class="badge badge-info">752</span>

                    </div>
                </div>
                <div class="block-content collapse in">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Product</th>
                                <th>Date</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Coat</td>
                                <td>02/02/2013</td>
                                <td>$25.12</td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>Jacket</td>
                                <td>01/02/2013</td>
                                <td>$335.00</td>
                            </tr>
                            <tr>
                                <td>3</td>
                                <td>Shoes</td>
                                <td>01/02/2013</td>
                                <td>$29.99</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <!-- /block -->
        </div>
    </div>
</asp:Content>

