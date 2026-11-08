using System;
using System.Drawing;
using System.Windows.Forms;

public class MushroomForm : Form
{
    Label lblQuestion;
    TextBox txtResult;

    Button btnYes;
    Button btnNo;
    Button btnStartAgain;

    int questionNumber = 1;

    bool forest = false;
    bool convex = false;


    public MushroomForm()
    {
        Text = "Mushroom Identification";
        Size = new Size(600, 450);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;


        Label lblTitle = new Label();
        lblTitle.Text = "MUSHROOM IDENTIFICATION";
        lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(130, 30);
        Controls.Add(lblTitle);


        lblQuestion = new Label();
        lblQuestion.Text = "Does your mushroom grow in a forest?";
        lblQuestion.Font = new Font("Arial", 11);
        lblQuestion.AutoSize = false;
        lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
        lblQuestion.Location = new Point(50, 100);
        lblQuestion.Size = new Size(480, 60);
        Controls.Add(lblQuestion);


        btnYes = new Button();
        btnYes.Text = "Yes";
        btnYes.Location = new Point(150, 180);
        btnYes.Size = new Size(120, 45);
        btnYes.Click += btnYes_Click;
        Controls.Add(btnYes);


        btnNo = new Button();
        btnNo.Text = "No";
        btnNo.Location = new Point(320, 180);
        btnNo.Size = new Size(120, 45);
        btnNo.Click += btnNo_Click;
        Controls.Add(btnNo);


        Label lblResult = new Label();
        lblResult.Text = "Result:";
        lblResult.Location = new Point(90, 260);
        lblResult.AutoSize = true;
        Controls.Add(lblResult);


        txtResult = new TextBox();
        txtResult.Location = new Point(160, 255);
        txtResult.Width = 330;
        txtResult.ReadOnly = true;
        Controls.Add(txtResult);


        btnStartAgain = new Button();
        btnStartAgain.Text = "Start Again";
        btnStartAgain.Location = new Point(220, 300);
        btnStartAgain.Size = new Size(140, 40);
        btnStartAgain.Click += btnStartAgain_Click;
        Controls.Add(btnStartAgain);


        Button btnBack = new Button();
        btnBack.Text = "Back";
        btnBack.Location = new Point(80, 360);
        btnBack.Size = new Size(120, 40);
        btnBack.Click += btnBack_Click;
        Controls.Add(btnBack);


        Button btnLogout = new Button();
        btnLogout.Text = "Logout";
        btnLogout.Location = new Point(390, 360);
        btnLogout.Size = new Size(120, 40);
        btnLogout.Click += btnLogout_Click;
        Controls.Add(btnLogout);
    }


    private void btnYes_Click(object sender, EventArgs e)
    {
        ProcessAnswer(true);
    }


    private void btnNo_Click(object sender, EventArgs e)
    {
        ProcessAnswer(false);
    }


    private void ProcessAnswer(bool answer)
    {
        // Question 1: Forest?
        if (questionNumber == 1)
        {
            forest = answer;

            questionNumber = 2;

            lblQuestion.Text =
                "Does your mushroom have a convex cap?";
        }


        // Question 2
        else if (questionNumber == 2)
        {
            convex = answer;

            // Meadow mushrooms
            if (forest == false)
            {
                if (convex == true)
                {
                    ShowResult("Agaric Jaunissant");
                }
                else
                {
                    ShowResult("Coprin Chevelu");
                }
            }

            // Forest mushrooms
            else
            {
                questionNumber = 3;

                if (convex == true)
                {
                    lblQuestion.Text =
                        "Does your mushroom have a ring?";
                }
                else
                {
                    lblQuestion.Text =
                        "Does your mushroom have gills?";
                }
            }
        }


        // Question 3
        else if (questionNumber == 3)
        {
            if (convex == true)
            {
                if (answer == true)
                {
                    ShowResult("Amanite Tue-Mouche");
                }
                else
                {
                    ShowResult("Pied Bleu");
                }
            }
            else
            {
                if (answer == true)
                {
                    ShowResult("Girolle");
                }
                else
                {
                    ShowResult("Cepe de Bordeau");
                }
            }
        }
    }


    private void ShowResult(string mushroom)
    {
        txtResult.Text = mushroom;

        btnYes.Enabled = false;
        btnNo.Enabled = false;

        lblQuestion.Text = "Mushroom identified.";

        MessageBox.Show(
            "Your mushroom is " + mushroom + ".",
            "Result",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }


    private void btnStartAgain_Click(object sender, EventArgs e)
    {
        questionNumber = 1;

        forest = false;
        convex = false;

        txtResult.Clear();

        btnYes.Enabled = true;
        btnNo.Enabled = true;

        lblQuestion.Text =
            "Does your mushroom grow in a forest?";
    }


    private void btnBack_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }


    private void btnLogout_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Abort;
        Close();
    }
}