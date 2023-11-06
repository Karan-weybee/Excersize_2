<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="AddAssign_Party.aspx.cs" Inherits="Exercise_2.AddAssign_Party" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style15 {
            width: 677px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentDetails">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
        <br />
        &nbsp;
            
     <div id="add" style="clip: rect(auto, auto, auto, inherit); margin-left: 750px; margin-right: auto; margin-bottom: auto; font-family: Arial, Helvetica, sans-serif;" class="auto-style15">
         <div class="form-group">
             <label for="exampleInputEmail1" class="auto-style15" style="font-family: Arial, Helvetica, sans-serif; font-weight: normal;">
                 ADD ASSIGN<br />
                 <br />
                 Party Name :-&nbsp;&nbsp;
             <asp:DropDownList ID="partyDropdown" runat="server" Height="23px" Width="112px">
             </asp:DropDownList>
                 <br />
                 <br />
                 product Name :-&nbsp;
             <asp:DropDownList ID="productDropdown" runat="server" Height="23px" Width="112px">
             </asp:DropDownList>
                 <br />
                 <br />
             </label>

         </div>




         <asp:Button ID="save" class="btn btn-success" runat="server" Text="Save" OnClick="save_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="cancle" class="btn btn-warning" runat="server" Text="Cancle" OnClick="cancle_Click" />
         &nbsp;&nbsp;
         
     </div>
        <br />
        <br />

    </div>
</asp:Content>


