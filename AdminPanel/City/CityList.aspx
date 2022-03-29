<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h4 style="text-align:center">City List</h4>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="text-danger" />
    <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="btn btn-info btn-sm" OnClick="btnAdd_Click" />
    <asp:GridView AutoGenerateColumns="false" ID="gvCity" runat="server" CssClass="table table-bordered" OnRowCommand="gvCity_RowCommand">
               <Columns>
                   <asp:BoundField DataField="CityID" HeaderText="ID" />
                   <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="Pincode" HeaderText="Pin Code" />
                    <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                   <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                           <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>'/>
                           </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit"> 
                       <ItemTemplate>
                           <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-light btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID="+ Eval("CityID").ToString() %>'/>
                       </ItemTemplate>
                   </asp:TemplateField>
                  
               </Columns>

           </asp:GridView>
</asp:Content>

