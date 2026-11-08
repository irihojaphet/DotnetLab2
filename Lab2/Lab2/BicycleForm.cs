using System;
using System.Drawing;
using System.Windows.Forms;

public class BicycleForm : Form
{
    TextBox txtStartTime;
    TextBox txtEndTime;
    TextBox txtTotal;


    public BicycleForm()
    {
        Text = "Bicycle Rental";
        Size = new Size(500, 430);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;


        Label lblTitle = new Label();
        lblTitle.Text = "BICYCLE RENTAL";
        lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(140, 30);
        Controls.Add(lblTitle);


        Label lblStart = new Label();
        lblStart.Text = "Starting Time (0-23):";
        lblStart.Location = new Point(60, 100);
        lblStart.AutoSize = true;
        Controls.Add(lblStart);


        txtStartTime = new TextBox();
        txtStartTime.Location = new Point(240, 95);
        txtStartTime.Width = 150;
        Controls.Add(txtStartTime);


        Label lblEnd = new Label();
        lblEnd.Text = "Ending Time (1-24):";
        lblEnd.Location = new Point(60, 150);
        lblEnd.AutoSize = true;
        Controls.Add(lblEnd);


        txtEndTime = new TextBox();
        txtEndTime.Location = new Point(240, 145);
        txtEndTime.Width = 150;
        Controls.Add(txtEndTime);


        Button btnCalculate = new Button();
        btnCalculate.Text = "Calculate";
        btnCalculate.Location = new Point(180, 200);
        btnCalculate.Size = new Size(130, 40);
        btnCalculate.Click += btnCalculate_Click;
        Controls.Add(btnCalculate);


        Label lblTotal = new Label();
        lblTotal.Text = "Total:";
        lblTotal.Location = new Point(100, 270);
        lblTotal.AutoSize = true;
        Controls.Add(lblTotal);


        txtTotal = new TextBox();
        txtTotal.Location = new Point(180, 265);
        txtTotal.Width = 200;
        txtTotal.ReadOnly = true;
        Controls.Add(txtTotal);


        Button btnBack = new Button();
        btnBack.Text = "Back";
        btnBack.Location = new Point(80, 330);
        btnBack.Size = new Size(120, 40);
        btnBack.Click += btnBack_Click;
        Controls.Add(btnBack);


        Button btnLogout = new Button();
        btnLogout.Text = "Logout";
        btnLogout.Location = new Point(290, 330);
        btnLogout.Size = new Size(120, 40);
        btnLogout.Click += btnLogout_Click;
        Controls.Add(btnLogout);
    }


    private void btnCalculate_Click(object sender, EventArgs e)
    {
        int startTime;
        int endTime;
        int rate = 0;
        int total = 0;


        // Validate starting time
        if (!int.TryParse(txtStartTime.Text, out startTime))
        {
            MessageBox.Show(
                "Starting time must be a whole number.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtStartTime.Focus();
            return;
        }


        if (startTime < 0 || startTime > 23)
        {
            MessageBox.Show(
                "Starting time must be between 0 and 23.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtStartTime.Focus();
            return;
        }


        // Validate ending time
        if (!int.TryParse(txtEndTime.Text, out endTime))
        {
            MessageBox.Show(
                "Ending time must be a whole number.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtEndTime.Focus();
            return;
        }


        if (endTime < 1 || endTime > 24)
        {
            MessageBox.Show(
                "Ending time must be between 1 and 24.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtEndTime.Focus();
            return;
        }


        if (endTime <= startTime)
        {
            MessageBox.Show(
                "Ending time must be greater than starting time.",
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtEndTime.Focus();
            return;
        }


        // Calculate rental cost
        for (int hour = startTime; hour < endTime; hour++)
        {
            if ((hour >= 0 && hour < 7) ||
                (hour >= 21 && hour < 24))
            {
                rate = 500;
            }
            else if ((hour >= 7 && hour < 14) ||
                     (hour >= 19 && hour < 21))
            {
                rate = 1000;
            }
            else
            {
                rate = 1500;
            }

            total = total + rate;
        }


        txtTotal.Text = total + " RWF";

        MessageBox.Show(
            "Rental cost calculated successfully.",
            "Bicycle Rental",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
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