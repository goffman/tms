<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenPass.aspx.cs" Inherits="admin_system_GenPass" MasterPageFile="../Admin.master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script src="../../Scripts/ZeroClipboard.js"></script>
      <div class="form-horizontal">
                            <fieldset>
                              
                                <div class="control-group">
                                    <label class="control-label" for="GenPass">Пароль</label>
                                    <div class="controls">
                                        <asp:TextBox ID="GenPass" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                       
                                    </div>
                                </div>
                                 <div class="control-group">
                                    <label class="control-label" for="MD5">MD5</label>
                                    <div class="controls">
                                        <asp:TextBox ID="MD5" runat="server" CssClass="input-xlarge focused" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                       
                                    </div>
                                </div>
                                </fieldset>
               <div class="form-actions">
                                    <asp:Button ID="Go" runat="server" Text="Генерировать" CssClass="btn btn-primary" OnClick="Go_Click"/>
                        
                                 
                                </div>
          </div>
 
</asp:Content>

