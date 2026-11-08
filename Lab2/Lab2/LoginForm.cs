using System;
using System.Drawing;
using System.Windows.Forms;

public class LoginForm : Form
{
    TextBox txtUsername;
    TextBox txtPassword;
    Button btnLogin;

    public LoginForm()
    {
        Text = "Login";
        Size = new Size(420, 320);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        Label lblTitle = new Label();
        lblTitle.Text = "LAB 2 - LOGIN";
        lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(115, 30);
        Controls.Add(lblTitle);


        Label lblUsername = new Label();
        lblUsername.Text = "Username:";
        lblUsername.Location = new Point(50, 100);
        lblUsername.AutoSize = true;
        Controls.Add(lblUsername);


        txtUsername = new TextBox();
        txtUsername.Location = new Point(150, 95);
        txtUsername.Width = 180;
        Controls.Add(txtUsername);


        Label lblPassword = new Label();
        lblPassword.Text = "Password:";
        lblPassword.Location = new Point(50, 145);
        lblPassword.AutoSize = true;
        Controls.Add(lblPassword);


        txtPassword = new TextBox();
        txtPassword.Location = new Point(150, 140);
        txtPassword.Width = 180;
        txtPassword.PasswordChar = '*';
        Controls.Add(txtPassword);


        btnLogin = new Button();
        btnLogin.Text = "Login";
        btnLogin.Location = new Point(150, 200);
        btnLogin.Width = 120;
        btnLogin.Click += btnLogin_Click;
        Controls.Add(btnLogin);
    }


    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (username == "" || password == "")
        {
            MessageBox.Show(
                "Username and Password cannot be empty.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
        else
        {
            MessageBox.Show(
                "Login successful.",
                "Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Hide();

            ChooseForm chooseForm = new ChooseForm();

            chooseForm.ShowDialog();

            Show();

            txtPassword.Clear();
        }
    }
}