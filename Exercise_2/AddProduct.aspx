<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Exercise_2.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentDetails">
    <div>
        <br />
        <div id="add" style="clip: rect(auto, auto, auto, inherit); margin-left: 750px; margin-right: auto; margin-bottom: auto; font-family: Arial, Helvetica, sans-serif;" class="auto-style15">
            <div class="form-group">
                <label for="exampleInputEmail1">
                    ADD PRODUCT<br />
                    <br />
                    <asp:TextBox ID="ProductName" runat="server" class="auto-style14" Width="191px"></asp:TextBox>
                    <br />
                </label>
                <br />
            </div>
            <br />
            <asp:Button ID="save" class="btn btn-success" runat="server" Text="Save" OnClick="save_Click" />
            <asp:Button ID="cancle" class="btn btn-warning" runat="server" Text="Cancle" OnClick="cancle_Click" />
        </div>
    </div>
</asp:Content>
