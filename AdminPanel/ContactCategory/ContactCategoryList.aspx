<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h4 style="text-align:center">Contact Category List</h4>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="text-danger" />
    <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="btn btn-info btn-sm" OnClick="btnAdd_Click" />
    <asp:GridView AutoGenerateColumns="false" ID="gvContactCategory" runat="server" CssClass="table table-bordered" OnRowCommand="gvContactCategory_RowCommand">
               <Columns>
                   <asp:BoundField DataField="ContactCategoryID" HeaderText="No." />
                   <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Type" />
                   <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                           <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%#Eval("ContactCategoryID") %>'/>
                           </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                       <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-light btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID="+ Eval("ContactCategoryID").ToString() %>'/>
                       </ItemTemplate>
                   </asp:TemplateField>

                  
               </Columns>

           </asp:GridView>
</asp:Content>

