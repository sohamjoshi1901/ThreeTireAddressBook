<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="BloodGroupAddEdit.aspx.cs" Inherits="AdminPanel_BloodGroup_BloodGroupAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1><asp:Label runat="server" ID="lblPageHeaderText" /></h1>
            <asp:Label runat="server" ID="lblMessage" CssClass="text-danger" EnableViewState="false" />
            <div class="row">
                <div class="col-md-2">
                    Blood Group Name:
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtBloodGroupName" />
                </div>
            </div>

            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btncancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btncancel_Click"  />
</asp:Content>

