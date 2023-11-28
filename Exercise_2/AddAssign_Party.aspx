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

        <div id="add" style="clip: rect(auto, auto, auto, inherit); margin-left: 750px; margin-right: auto; margin-bottom: auto; font-family: Arial, Helvetica, sans-serif;" class="auto-style15">
            <div class="form-group">
                <label for="exampleInputEmail1" class="auto-style15" style="font-family: Arial, Helvetica, sans-serif; font-weight: normal; margin-bottom: 20px">
                    ADD ASSIGN<br />
                    <br />
                    Party Name :-
             <asp:DropDownList ID="partyDropdown" runat="server" Height="23px" Width="112px" Style="margin-left: 20px" DataSourceID="addPartyInDropDown" DataTextField="PartyName" DataValueField="PartyName">
             </asp:DropDownList>
                    <asp:SqlDataSource ID="addPartyInDropDown" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="select PartyName from Party"></asp:SqlDataSource>
                    <div style="margin-bottom: 20px"></div>
                    product Name :-
             <asp:DropDownList ID="productDropdown" runat="server" Height="23px" Width="112px" Style="margin-left: 20px" DataSourceID="addProductInDropDown" DataTextField="productName" DataValueField="productName">
             </asp:DropDownList>
                    <asp:SqlDataSource ID="addProductInDropDown" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="select productName from products"></asp:SqlDataSource>
                    <br />
                </label>
            </div>
            <asp:Button ID="save" class="btn btn-success" runat="server" Text="Save" OnClick="save_Click" Style="margin-right: 20px" />
            <asp:Button ID="cancle" class="btn btn-warning" runat="server" Text="Cancle" OnClick="cancle_Click" />

        </div>

    </div>
</asp:Content>


