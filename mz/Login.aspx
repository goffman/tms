<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="mz_Default" MasterPageFile="mz.master" Title="Авторизация" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="span12" id="content">
        <!-- morris stacked chart -->
        <div class="row-fluid">
            <!-- block -->
            <div class="block">
                <div class="navbar navbar-inner block-header">
                    <div class="muted pull-left">Авторизация</div>
                </div>
                <div class="block-content collapse in">
                    <div class="span12">
                        <div class="form-horizontal">
                            <fieldset>
                              
                                <div class="control-group">
                                    <label class="control-label" for="txtloginusername">Имя пользователя</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtloginusername" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                       
                                    </div>
                                </div>
                                
                                 <div class="control-group">
                                    <label class="control-label" for="txtloginpass">Пароль</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtloginpass" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                       
                                    </div>
                                </div>
                                


                                <div class="form-actions">
                                    <asp:Button ID="Go" runat="server" Text="Авторизация" CssClass="btn btn-primary" OnClick="Go_Click"/>
                        
                                    <asp:Label ID="Notif" runat="server" Text=""></asp:Label>
                                </div>
                            </fieldset>
                        </div>

                    </div>
                </div>
            </div>
            <!-- /block -->
        </div>

    </div>

</asp:Content>

