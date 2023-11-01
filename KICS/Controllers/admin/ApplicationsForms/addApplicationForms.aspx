<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addApplicationForms.aspx.cs" Inherits="KICS.Controllers.admin.ApplicationsForms.addApplicationForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-group {
            margin: 1rem 0rem;
        }

        label {
            margin: .35rem 0rem;
        }
    </style>

    <section class="row" aria-labelledby="aspnetTitle">

        <div class="jumbotron">
            <h2 class="display-7 text-uppercase mt-2 mb-2">Application Form</h2>
            <br />
            <%--<% if (ViewState["msgLabel"] != null) { %> 
                     <asp:Label ID="msgLabel" runat="server" Text='<%# ViewState["msgLabel"] %>' CssClass="alert alert-info p-2 mt-2" />
                <% } %>--%>

            <asp:Label ID="msgLabel" runat="server" CssClass="alert alert-info p-2 mt-2" />


            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Student Name</label>
                        <asp:TextBox ID="FORMS_USERNAME" runat="server" placeholder="Enter student name" class="form-control" />
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Student Email</label>
                        <asp:TextBox ID="FORMS_EMAIL" runat="server" placeholder="Enter Email" class="form-control" TextMode="Email" />
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Student DOB</label>
                        <asp:TextBox ID="FORMS_DOB" runat="server" placeholder="Enter Date of birth" class="form-control" TextMode="Date" />
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Student Profile Image (optional)</label>
                        <asp:FileUpload ID="FORMS_STUDENT_IMAGES" runat="server" class="form-control form-control-file" />
                    </div>
                </div>
            </div>

            <div class="row">
                
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Qualification</label>
                        <asp:TextBox ID="FORMS_QUALIFICATIONS" runat="server" placeholder="Enter Qualification" class="form-control" />
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Father's Name</label>
                        <asp:TextBox ID="FORMS_STUDENT_FATHER_NAMES" runat="server" placeholder="Enter Father's Name" class="form-control" />
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlSelect1">Course Interested in</label>
                        <asp:DropDownList ID="FORMS_STUDENT_COURSE_ID" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="FORMS_STUDENT_COURSE_ID_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Phone</label>
                        <asp:TextBox ID="FORMS_STUDENT_PHONES" runat="server" placeholder="Enter Phone" class="form-control" />
                    </div>
                </div>

            </div>


            <div class="row">
                
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Father's Phone</label>
                        <asp:TextBox ID="FORMS_STUDENT_FATHER_PHONES" runat="server" placeholder="Enter Father's Phone" class="form-control" />
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Institute Timing</label>
                        <asp:TextBox ID="FORMS_TIMINGS" runat="server" placeholder="Enter institute timings" class="form-control" />
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Application fees (optional)</label>
                        <asp:TextBox ID="FORMS_OFFICE_FEES" runat="server" placeholder="Enter application fees" class="form-control" />
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Discount (optional)</label>
                        <asp:TextBox ID="FORMS_DISCOUNT" runat="server" placeholder="Enter discount" class="form-control" />
                    </div>
                </div>

            </div>


            <div class="row">
                <div class="col-md-2 d-none">
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Form submitted by</label>
                        <asp:TextBox ID="FORMS_USERS_ID" runat="server" placeholder="Submitted by" class="form-control disabled" Enabled="false" />
                    </div>
                </div>

            <div class="col-md-2">
                <div class="form-group">
                    <label for="exampleFormControlInput1">Address</label>
                    <asp:TextBox ID="FORMS_STUDENT_ADDRESS" runat="server" placeholder="Enter address of student" class="form-control" />
                </div>
            </div>
        </div>

        <p class="lead d-flex gap-3 justify-content-start align-content-center" 
                style="width: 72%;">
                <asp:Button ID="reset" Text="Reset Application" runat="server" class="btn btn-secondary btn-md" OnClick="reset_Click"/>
                <asp:Button ID="submitApplicationForm" Text="Submit Application" runat="server" class="btn btn-primary btn-md" OnClick="submitApplicationForm_Click" />
            </p>
        </div>
    </section>


</asp:Content>