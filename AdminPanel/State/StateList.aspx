<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h4 style="text-align:center">Contact List</h4>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="text-danger" />
    <asp:Button runat="server" ID="btnAdd" Text="Add new" OnClick="btnAdd_Click" CssClass="btn btn-info btn-sm " />
     <asp:GridView AutoGenerateColumns="false" ID="gvState" runat="server" CssClass="table table-bordered" OnRowCommand="gvState_RowCommand">
               <Columns>
                   <asp:BoundField DataField="StateID" HeaderText="ID" />
                   <asp:BoundField DataField="StateName" HeaderText="State" />
                   <asp:BoundField DataField="CountryName" HeaderText="Country" />
                   <asp:TemplateField HeaderText="Delete">
                       <ItemTemplate>
                           <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>'/>
                           </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                       <ItemTemplate>
                           <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-light btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID="+ Eval("StateID").ToString() %>'/>
                       </ItemTemplate>
                   </asp:TemplateField>
                  
               </Columns>

           </asp:GridView>
</asp:Content>

