<%@ Page Title="" Language="C#" MasterPageFile="~/Invoice_Module.Master" AutoEventWireup="true" CodeBehind="AddProduct_Rate.aspx.cs" Inherits="Exercise_2.AddProduct_Rate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentDetails">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;
            
     <div id="add" style="clip: rect(auto, auto, auto, inherit); margin-left: 750px; margin-right: auto; margin-bottom: auto; font-family: Arial, Helvetica, sans-serif;" class="auto-style15">
         <div class="form-group">
             <label for="exampleInputEmail1">
                 ADD PRODUCT RATE<br />
             <br />
                 Product Name :-
             <br />
                 <br />
                 <asp:DropDownList ID="ProductName" runat="server" DataSourceID="SqlDataSource1" DataTextField="ProductName" DataValueField="ProductName">
                 </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Exercise2ConnectionString14 %>" SelectCommand="SELECT [ProductName] FROM [Products]"></asp:SqlDataSource>
                 <br />
                 <br />
                 Product rate<br />
                 <asp:Label ID="error" runat="server" ForeColor="#FF5050"></asp:Label>
                 <br />
                 <asp:TextBox ID="ProductRate" runat="server" class="auto-style14" Width="191px"></asp:TextBox>
                 <br />
                 <br />
                 <br />
                 Date Of Rate :-<br />
                 <br />
                 <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                     <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                     <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                     <OtherMonthDayStyle ForeColor="#999999" />
                     <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                     <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                     <TodayDayStyle BackColor="#CCCCCC" />
                 </asp:Calendar>
             </label>

             <br />

         </div>


         <br />

         <asp:Button ID="save" class="btn btn-success" runat="server" Text="Save" OnClick="save_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="cancle" class="btn btn-warning" runat="server" Text="Cancle" OnClick="cancle_Click" />
         &nbsp;&nbsp;
         
     </div>
        <br />
        <br />

    </div>
</asp:Content>
