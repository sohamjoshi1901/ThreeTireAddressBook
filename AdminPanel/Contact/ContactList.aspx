<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h4 style="text-align:center">Contact List</h4>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false" CssClass="text-danger" />
    <asp:Button runat="server" ID="btnAdd" Text="Add new" OnClick="btnAdd_Click" CssClass="btn btn-info btn-sm " />
    <asp:GridView AutoGenerateColumns="false" ID="gvContact" runat="server" CssClass="table table-bordered" OnRowCommand="gvContact_RowCommand" >
               <Columns>
                   <asp:BoundField DataField="ContactID" HeaderText="No." />
                   <asp:BoundField DataField="PersonName" HeaderText="Name" />

                   <asp:BoundField DataField="Address" HeaderText="Address" />
                   <asp:BoundField DataField="CityName" HeaderText="City " />
                   <asp:BoundField DataField="StateName" HeaderText="State" />
                   <asp:BoundField DataField="CountryName" HeaderText="Country" />
                   <asp:BoundField DataField="PinCode" HeaderText="PIN code" />
                   <asp:BoundField DataField="MobileNo" HeaderText="Mobile Number" />
                   <asp:BoundField DataField="PhoneNo" HeaderText="Phone Number" />
                   <asp:BoundField DataField="Email" HeaderText="Email Address" />
                   <asp:BoundField DataField="Gender" HeaderText="Gender" />
                   <asp:BoundField DataField="BirthDate" HeaderText="Date of Birth" />
                   <asp:BoundField DataField="Profession" HeaderText="Profession" />
                   <asp:BoundField DataField="BloodgroupName" HeaderText="Blood Group ID" />
                   <asp:BoundField DataField="ContactCategoryName" HeaderText="Type Of Contact" />
                   <asp:TemplateField HeaderText="Delete">                
                       <ItemTemplate>
                           <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID") %>'/>
                            </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Edit">                
                       <ItemTemplate>
                           <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-light btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID="+ Eval("ContactID").ToString() %>'/>
                       </ItemTemplate>
                   </asp:TemplateField>

               </Columns>

           </asp:GridView>
</asp:Content>

