<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Exercise_2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

    <style>
        .login-form {
            width: 60vw;
            margin: auto;
            margin-top: 10vh;
            background: aliceblue;
            padding: 20px;
            border-radius: 14px
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="login-form">
            <!-- Email input -->
            <div class="form-outline mb-4">
                <label class="form-label" for="form2Example1">User Name :-</label>
                <asp:TextBox ID="username" runat="server" class="form-control" placeholder="Enter your Name..."></asp:TextBox>

            </div>

            <!-- Password input -->
            <div class="form-outline mb-4">
                <label class="form-label" for="form2Example2">Password :-</label>
                <asp:TextBox type="password" ID="password" runat="server" class="form-control"></asp:TextBox>

            </div>

            <!-- 2 column grid layout for inline styling -->
            <div class="row mb-4">
                <div class="col d-flex justify-content-left">
                    <!-- Checkbox -->
                    <asp:Button ID="signin" runat="server" Text="Sign in" class="btn btn-success btn-block mb-4" OnClick="signin_Click" />
                    &nbsp;&nbsp;&nbsp;
                </div>


            </div>

            <!-- Submit button -->


            <!-- Register buttons -->
            <div class="text-left">
                <a href="#!" style="vertical-align: bottom">Forgot password?</a><br />
                <br />
                <p>Not a member? <a href="Register.aspx">Register</a></p>
                <p>or sign up with:</p>
                <button type="button" class="btn btn-link btn-floating mx-1">
                    <i class="fab fa-facebook-f"></i>
                </button>

                <button type="button" class="btn btn-link btn-floating mx-1">
                    <i class="fab fa-google"></i>
                </button>

                <button type="button" class="btn btn-link btn-floating mx-1">
                    <i class="fab fa-twitter"></i>
                </button>

                <button type="button" class="btn btn-link btn-floating mx-1">
                    <i class="fab fa-github"></i>
                </button>
            </div>
        </div>
    </form>
</body>
</html>
