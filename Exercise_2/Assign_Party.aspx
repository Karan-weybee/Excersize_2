<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="Assign_Party.aspx.cs" Inherits="Exercise_2.Assign_Party" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentDetails">
    <span style="font-family: Arial, Helvetica, sans-serif; font-size: x-large; margin-left: 25em; margin-right: 7em;">Assign List</span>
    <asp:Button ID="AddAssign" runat="server" BackColor="#FF9933" BorderColor="#FFCC00" ForeColor="White" OnClick="AddAssign_Click" Text="Add New Assign" />
    <div>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Horizontal" Height="293px" HorizontalAlign="Center" Width="618px" OnRowUpdating="GridView2_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">

            <Columns>
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PartyName" SortExpression="PartyName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="PartyName" DataValueField="PartyName">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Exercise2ConnectionString8 %>" SelectCommand="SELECT [PartyName] FROM [Party]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PartyName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="ProductName" DataValueField="ProductName">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Exercise2ConnectionString10 %>" SelectCommand="SELECT [ProductName] FROM [Products]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="Action">
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

    </div>


    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="select a.id,p.PartyName,pr.ProductName from party p inner join AssignParty a on p.id=a.party_id inner join products pr on pr.id=a.product_id;"
        UpdateCommand="update AssignParty set Party_id = (select top 1 id from party where PartyName = @PartyName), Product_id = (select top 1 id from Products where ProductName = @ProductName) where id = @id"
        DeleteCommand="delete from AssignParty where id = @id">
        <UpdateParameters>
            <asp:Parameter Name="PartyName" Type="String" />
            <asp:Parameter Name="ProductName" Type="String" />
        </UpdateParameters>

    </asp:SqlDataSource>
    </div>
</asp:Content>


