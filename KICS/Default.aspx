<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KICS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">

            <div class="jumbotron bg-light p-5">
                <h2 class="display-7"><asp:Label ID="nameLabel" runat="server" /></h2>
                <p class="lead">
                    Welcome to our digital haven! At [Your Institute/Organization Name], we are more than just a tech hub—we are a community of innovators, educators, and visionaries committed to shaping the future of technology. With a foundation rooted in knowledge, creativity, and a passion for excellence, we empower newcomers in computer studies, inspire hope in disheartened youth, and aspire to nurture the next generation of computer scientists. Our journey is fueled by a commitment to enhancing community efficiency and enabling students to thrive in the dynamic realm of e-commerce. Join us on this transformative tech odyssey, where every line of code is a step toward a brighter, more connected future.
                </p>
                <hr class="my-4">
                <p>
                    We teach skills for the future survival.
                </p>
                <p class="lead">
                    <asp:Button ID="AddApplicationForm" Text="Add New Application" runat="server" class="btn btn-primary btn-md" OnClick="AddApplicationForm_Click"/>
                </p>
            </div>

            </section>
           
    </main>

</asp:Content>
