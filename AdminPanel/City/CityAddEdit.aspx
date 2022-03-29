<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
                <h1><asp:Label runat="server" ID="lblHeaderText" /></h1>
            </div>
            <asp:Label runat="server" ID="lblMessage" CssClass="text-danger" EnableViewState="false" />
                         <div class="row">
                <div class="col-md-2">
                   <asp:Label ID="lblCountry" runat="server">Select Country:</asp:Label>  
                </div>
                <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="ddlCountry" CssClass="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"  ></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Select State:
                </div>
                <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="ddlState" CssClass="btn btn-secondary dropdown-toggle" ></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Enter City:
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" />
                </div>

            </div>
                         <div class="row">
                <div class="col-md-2">
                    Enter Pin Code:
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" />
                </div>

            </div>
                         <div class="row">
                <div class="col-md-2">
                    Enter STD code:
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control" />
                </div>

            </div>



            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click"  />
            <asp:Button runat="server" ID="btncancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btncancel_Click" />
</asp:Content>

