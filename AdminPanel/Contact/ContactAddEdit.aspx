<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
                <h1><asp:Label runat="server" ID="lblPageHeaderText" /></h1>
            </div>

            <asp:Label runat="server" ID="lblMessage" CssClass="text-danger" EnableViewState="false" />
    <h1><asp:Label ID="lblHeaderText" runat="server" /></h1>
            <div class="row">
                <div class="col-md-2">
                    Person  Name:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPeresonName" />
                </div>
            </div>
                <div class="row">
                <div class="col-md-2">
                    Address:
                </div>

                <div class="col-md-8">
                    <asp:TextBox Rows="3" runat="server" CssClass="form-control" ID="txtAddress" />
                </div>
            </div>
                       
                    <div class="row">
                <div class="col-md-2">
                    Country:
                </div>

                <div class="col-md-3">
                   <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCountry" CssClass="btn btn-secondary dropdown-toggle"   OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" />
                </div>
            </div>
     <div class="row">
                            <div class="col-md-2">
                                State:
                            </div>

                            <div class="col-md-3">
                               <asp:DropDownList runat="server" ID="ddlState" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle"  OnSelectedIndexChanged="ddlState_SelectedIndexChanged"   />
                            </div>
                        </div>
            <div class="row">
                        <div class="col-md-2">
                            City:
                        </div>

                        <div class="col-md-3">
                           <asp:DropDownList runat="server" ID="ddlCity" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle" />
                        </div>
                    </div>

                
                    
            <div class="row">
                <div class="col-md-2">
                    PinCode:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPincode" />
                </div>
            </div>
        <div class="row">
                <div class="col-md-2">
                    Mobile Number:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtMobileNo" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Phone Number
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPhoneNo" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                   Email:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Gender:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtGender" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Birth Date:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtBirthDate" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Profession:
                </div>

                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtProfession" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    Blood Group:
                </div>

                <div class="col-md-3">
                   <asp:DropDownList runat="server" ID="ddlBloodGroup" CssClass="btn btn-secondary dropdown-toggle" />
                </div>
            </div>
                     <div class="row">
                <div class="col-md-2">
                    Contact Category:
                </div>
              
                <div class="col-md-3">
                   <asp:DropDownList runat="server" ID="ddlContactCategory" CssClass="btn btn-secondary dropdown-toggle" />
                    
                </div>
                    
            </div>



            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btncancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btncancel_Click" />
</asp:Content>

