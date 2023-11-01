<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="KICS.Controllers.auth.registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-group {
            margin: 1rem 0rem;
        }
    </style>

    <div class="container body-content" style="width: 100%; display: flex; flex-direction: column; justify-content: center; align-items: center; padding: 2rem 0rem;">
        <div>
            <div class="form-group">
            <h1 class="display-7">Registration</h1>
            </div>

            <% if (ViewState["msgLabel"] != null)
                { %>
            <div class="form-group pt-3 pb-3">
                <asp:Label ID="msgLabel" CssClass="alert alert-danger" runat="server" Text='<%# ViewState["msgLabel"] %>' />
            </div>
            <% } %>

            <div class="form-group">
                <label for="exampleFormControlInput1">Username</label>
                <asp:TextBox ID="username" runat="server" class="form-control" placeholder="User Name"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleFormControlInput1">Cnic</label>
                <asp:TextBox ID="cnic" runat="server" placeholder="12345-1235678-9" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleFormControlInput1">Password</label>
                <asp:TextBox ID="password" runat="server" placeholder="*********" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleFormControlFile1">Profile Image</label>
                <asp:FileUpload ID="profileImage" runat="server" class="form-control form-control-file" />
            </div>
            <div class="form-group">
                <label for="exampleFormControlInput1">Phone</label>
                <asp:TextBox ID="phone" runat="server" placeholder="1234-1234567" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleFormControlSelect1">User Role</label>
                <asp:DropDownList ID="userRoles" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="userRoles_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="form-group d-block justify-content-between">
                 <asp:Button ID="reset" runat="server" Text="Reset" class="btn btn-secondary w-100 mt-1 mb-1" OnClick="reset_Click" />
                <asp:Button ID="submit" runat="server" Text="Sign Up" class="btn btn-primary w-100 mt-1 mb-1" OnClick="submit_Click" />
            </div>

        </div>
    </div>

</asp:Content>
