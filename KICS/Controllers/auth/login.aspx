<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="KICS.Controllers.auth.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <style>
        .form-group {
            margin: 1rem 0rem;
        }
    </style>

    <div class="container body-content" style="width: 100%; display: flex; flex-direction: column; justify-content: center; align-items: center; padding: 2rem 0rem;">
        <div>
            <div class="form-group">
            <h1 class="display-7">Login</h1>
            </div>

                <asp:Label ID="msgLabel" runat="server" />


            <div class="form-group">
                <label for="exampleFormControlInput1">CNIC / Email</label>
                <asp:TextBox ID="cnic" runat="server" placeholder="CNIC or Email" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleFormControlInput1">Password</label>
                <asp:TextBox ID="password" runat="server" placeholder="*********" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
          
            <div class="form-group d-block justify-content-between">
                 <asp:Button ID="reset" runat="server" Text="Reset" class="btn btn-secondary w-100 mt-1 mb-1" OnClick="reset_Click" />
                <asp:Button ID="signIn" runat="server" Text="Sign In" class="btn btn-primary w-100 mt-1 mb-1" OnClick="signIn_Click" />
            </div>

        </div>
    </div>



</asp:Content>
