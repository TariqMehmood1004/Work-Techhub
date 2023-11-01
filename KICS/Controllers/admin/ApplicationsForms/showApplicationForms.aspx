<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="showApplicationForms.aspx.cs" Inherits="KICS.Controllers.admin.ApplicationsForms.showApplicationForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        main {
            padding: 2rem;
            background: #f3f4f9;
            border-radius: 0.125rem;
            overflow-y: scroll;
        }

            /* Hide the default scrollbar */
            main::-webkit-scrollbar {
                width: 12px; /* Set the width of the invisible scrollbar */
            }

            /* Track */
            main::-webkit-scrollbar-track {
                background: transparent; /* Set the track background color to transparent */
            }

            /* Handle */
            main::-webkit-scrollbar-thumb {
                background: transparent; /* Set the thumb color to transparent */
            }

                /* Handle on hover */
                main::-webkit-scrollbar-thumb:hover {
                    background: #888; /* Set the thumb color on hover */
                }


        .container {
            width: 100%;
            max-width: 1650px;
            /*background: red;*/
        }
        /* Header style */
        #GridViewQuestionManage th {
            background-color: #000 !important; /* Change this to black */
            color: #fff;
            font-weight: 600;
            font-size: 14px;
            padding: 15px;
            text-align: left;
        }

        .table {
            width: 100%;
            overflow-y: scroll;
        }
        /* Overall table style */
        #GridViewQuestionManage {
            border-collapse: collapse;
            width: 100%;
            margin-bottom: 12px;
            font-size: 14px;
            font-family: 'Tajawal', sans-serif;
            border-radius: 8px;
            overflow: hidden;
        }

            /* Header style */
            #GridViewQuestionManage th {
                background-color: #5553FF;
                color: #fff;
                font-weight: 600;
                font-size: 14px;
                padding: 15px;
                text-align: left;
            }

            /* Cell style */
            #GridViewQuestionManage td {
                padding: 10px;
                text-align: left;
                font-weight: 300;
                font-family: Arial, sans-serif;
                font-size: 14px;
                border: none;
            }


                /* Image style within a cell */
                #GridViewQuestionManage td img {
                    width: 55px;
                    height: 55px;
                    border-radius: 10px;
                    object-fit: cover;
                    background-position: center;
                }

        /* Styles for a row with smaller images */
        .row-sm img {
            width: 45px;
            height: 45px;
            object-fit: cover;
            background-position: center;
            border-radius: 100px;
            margin: 0em 1em;
        }

        /* CommandField button style */
        .primary-btn-1xl-blue {
            /* Add your button styles here */
            background-color: #5553FF;
            color: #fff;
            padding: 4px 6px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }
    </style>

    <main>
        <section class="row" aria-labelledby="aspnetTitle">


            <div class="jumbotron">
                <h2 class="display-7">My Applications - </h2>
                <hr class="my-4">


                <asp:GridView ID="GridViewQuestionManage" CssClass="table" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="FORMS_ID" OnRowDataBound="GridViewQuestionManage_RowDataBound" ClientIDMode="Static" OnRowCommand="GridViewQuestionManage_RowCommand">
                    <HeaderStyle BackColor="Black" ForeColor="White" />

                    <Columns>
                        <asp:BoundField DataField="FORMS_ID" HeaderText="#" InsertVisible="False" ReadOnly="True" />

                        <asp:BoundField DataField="FORMS_USERNAME" HeaderText="Student Name" SortExpression="FORMS_USERNAME" />
                        <asp:BoundField DataField="FORMS_EMAIL" HeaderText="Emails" SortExpression="FORMS_EMAIL" ItemStyle-CssClass="text-urdu" />
                        <asp:BoundField DataField="FORMS_DOB" HeaderText="Dob" SortExpression="FORMS_DOB" />

                        <asp:BoundField DataField="FORMS_QUALIFICATIONS" HeaderText="Qualifications" SortExpression="FORMS_QUALIFICATIONS" />

                        <asp:BoundField DataField="FORMS_STUDENT_FATHER_NAMES" HeaderText="Father's Name" SortExpression="FORMS_STUDENT_FATHER_NAMES" />

                        <asp:BoundField DataField="FORMS_STUDENT_ADDRESS" HeaderText="Address" SortExpression="FORMS_STUDENT_ADDRESS" />

                        <asp:BoundField DataField="FORMS_STUDENT_COURSE_ID" HeaderText="Courses" SortExpression="FORMS_STUDENT_COURSE_ID" />

                        <asp:BoundField DataField="FORMS_STUDENT_PHONES" HeaderText="Phone" SortExpression="FORMS_STUDENT_PHONES" />

                        <asp:BoundField DataField="FORMS_STUDENT_FATHER_PHONES" HeaderText="Father's phone" SortExpression="FORMS_STUDENT_FATHER_PHONES" />

                        <asp:BoundField DataField="FORMS_TIMINGS" HeaderText="Course Time" SortExpression="FORMS_TIMINGS" />

                        <asp:BoundField DataField="FORMS_OFFICE_FEES" HeaderText="Fees" SortExpression="FORMS_OFFICE_FEES" />

                        <asp:BoundField DataField="FORMS_DISCOUNT" HeaderText="Discount" SortExpression="FORMS_DISCOUNT" />

                        <asp:CommandField ShowDeleteButton="true" HeaderText="Delete" ButtonType="Button" ControlStyle-CssClass="primary-btn-1xl-blue" />
                        <asp:CommandField ShowEditButton="true" HeaderText="Edit" ButtonType="Button" ControlStyle-CssClass="primary-btn-1xl-blue" />

                    </Columns>
                </asp:GridView>


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conn %>" SelectCommand="SELECT *
                    FROM APPLICATION_FORMS AS AF
                    INNER JOIN USERS AS U ON AF.FORMS_USERS_ID = U.USERS_ID
                    INNER JOIN COURSES AS C ON AF.FORMS_STUDENT_COURSE_ID = C.COURSES_ID
                    ORDER BY AF.FORMS_ID DESC;
                    "
                    DeleteCommand="DELETE FROM APPLICATION_FORMS WHERE FORMS_ID = @FORMS_ID"
                    UpdateCommand=""></asp:SqlDataSource>


            </div>

        </section>

    </main>

    <script type="text/javascript">
        function printRecord(formsId) {
            var printContent = document.getElementById('row_' + formsId).innerHTML;
            var originalContent = document.body.innerHTML;

            document.body.innerHTML = printContent;

            window.print();

            document.body.innerHTML = originalContent;

            return false;
        }
    </script>


</asp:Content>
