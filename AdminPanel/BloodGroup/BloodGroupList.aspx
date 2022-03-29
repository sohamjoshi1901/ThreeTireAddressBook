<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="BloodGroupList.aspx.cs" Inherits="AdminPanel_BloodGroup_BloodGroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4 style="text-align:center">Blood Group List</h4>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="alert-danger" />
           <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="btn btn-info btn-sm" OnClick="btnAdd_Click"/>
     <asp:GridView AutoGenerateColumns="false" ID="gvBloodGroup" runat="server" CssClass="table table-bordered" OnRowCommand="gvBloodGroup_RowCommand">
               <Columns>
                   <asp:BoundField DataField="BloodGroupID" HeaderText="No." />
                   <asp:BoundField DataField="BloodGroupName" HeaderText="Blood Group Type" />
                   <asp:TemplateField HeaderText="Delete ">
                       <ItemTemplate>
                           <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("BloodGroupID") %>'/>
                           </ItemTemplate>
                       </asp:TemplateField>
                   <asp:TemplateField HeaderText="Edit ">
                       <ItemTemplate>
                           <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-light btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/BloodGroup/BloodGroupAddEdit.aspx?BloodGroupID="+ Eval("BloodGroupID").ToString() %>'/>
                       </ItemTemplate>
                   </asp:TemplateField>
                  
               </Columns>

           </asp:GridView>
</asp:Content>

