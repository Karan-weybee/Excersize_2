<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Exercise_2.Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style14 {
            width: 316px;
            margin-right: 0px;
        }

        .auto-style15 {
            height: 645px;
        }

        .auto-style16 {
            /*margin-left: 0px;*/
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentDetails">
    <span style="font-family: Arial, Helvetica, sans-serif; font-size: x-large; margin-left: 25em; margin-right: 7em;">Add invoice</span><div class="auto-style15">
        <br />
        <div id="add" style="clip: rect(auto, auto, auto, inherit); margin-left: 680px; margin-bottom: auto; font-weight: 200;" class="auto-style14">
            <div class="form-group">
                <label for="exampleInputEmail1" style="font-weight: 100">
                    Party name :-   
             <asp:DropDownList ID="PartyDropDown" runat="server" AutoPostBack="True" Height="40px" OnSelectedIndexChanged="PartyDropDown_SelectedIndexChanged1" Width="148px">
             </asp:DropDownList>
                    <br />
                </label>
                <br />
            </div>
            <br />
            Product name :- 
         <asp:DropDownList ID="ProductDropDown" runat="server" Height="24px" Width="139px" AutoPostBack="True" OnSelectedIndexChanged="ProductDropDown_SelectedIndexChanged" Style="margin-bottom: 20px;">
         </asp:DropDownList>

            Current Rate :-  
         <asp:TextBox ID="Rate" runat="server" Style="margin-bottom: 20px;"></asp:TextBox>

            Quantity :-  
         <asp:TextBox ID="Quantity" runat="server" Style="margin-bottom: 20px;"></asp:TextBox>


            <asp:Button ID="save" class="btn btn-success" runat="server" Text="Add To Invoice" OnClick="save_Click" />

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT * FROM [Invoice]"></asp:SqlDataSource>

        </div>



        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT * FROM [Invoice]"></asp:SqlDataSource>


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" HorizontalAlign="Center" Width="552px" CssClass="auto-style16" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Style="margin-top: 350px;">

            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                    <HeaderStyle CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Party" HeaderText="Party" SortExpression="Party">
                    <HeaderStyle CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product">
                    <HeaderStyle CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Rate_of_product" HeaderText="Rate_of_product" SortExpression="Rate_of_product">
                    <HeaderStyle CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity">
                    <HeaderStyle CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total">
                    <HeaderStyle CssClass="center_th" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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

        <br />
        Grand Total :-
        <asp:Label ID="GrandTotal1" runat="server" Text="Label" Style="margin-bottom: 20px;"></asp:Label><br />

        <asp:Button ID="clearInvoice" runat="server" BackColor="#FF5050" ForeColor="White" OnClick="clearInvoice_Click" Text="Clear Invoice" Width="117px" />

    </div>
</asp:Content>
