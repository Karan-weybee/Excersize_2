<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="AddParty.aspx.cs" Inherits="Exercise_2.AddParty" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentDetails">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;
            
     <div id="add" style="clip: rect(auto, auto, auto, inherit); margin-left: 750px; margin-right: auto; margin-bottom: auto; font-family: Arial, Helvetica, sans-serif;" class="auto-style15">
         <div class="form-group">
             <label for="exampleInputEmail1">
                 ADD PARTY<br />
                 <br />
                 <asp:TextBox ID="PartyName" runat="server" class="auto-style14" Width="191px" ViewStateMode="Enabled"></asp:TextBox>
                 <br />
             <br />
             </label>

             <br />

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

