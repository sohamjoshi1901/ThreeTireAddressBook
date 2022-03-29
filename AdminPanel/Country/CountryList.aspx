<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h4 style="text-align:center">Contact List</h4>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="text-danger" />
    <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CssClass="btn btn-info btn-sm"/>
     <asp:GridView AutoGenerateColumns="false" ID="gvCountry" runat="server" CssClass="table table-bordered" OnRowCommand="gvCountry_RowCommand">
               <Columns>
                   <asp:BoundField DataField="CountryID" HeaderText="ID" />
                   <asp:BoundField DataField="CountryName" HeaderText="Country" />
                   <asp:BoundField DataField="CountryCode" HeaderText="Code" />
                   <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                           <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID") %>'/>
                           </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                       <ItemTemplate>
                           <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-light btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID="+ Eval("CountryID").ToString() %>'/>
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>

           </asp:GridView>
</asp:Content>

