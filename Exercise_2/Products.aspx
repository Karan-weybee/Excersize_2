<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Exercise_2.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentDetails">
    <span style="font-family: Arial, Helvetica, sans-serif; font-size: x-large; margin-left: 25em; margin-right: 7em;">Product List</span>
    <asp:Button ID="AddProduct" runat="server" BackColor="#FF9933" BorderColor="#FFCC00" ForeColor="White" OnClick="AddProduct_Click" Text="Add New Product" />

    <div>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Height="201px" HorizontalAlign="Center" Width="618px">

            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                    <HeaderStyle HorizontalAlign="Center" CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName">
                    <HeaderStyle HorizontalAlign="Center" CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" HeaderText="Action">
                    <HeaderStyle HorizontalAlign="Center" CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" CssClass="button" />
                </asp:CommandField>
            </Columns>


            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>


        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT * FROM [Products]"
            UpdateCommand="update Products set ProductName=@ProductName where id=@id"
            DeleteCommand="delete from Products where id=@id"></asp:SqlDataSource>
    </div>
</asp:Content>

