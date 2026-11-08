using System;
using System.Drawing;
using System.Windows.Forms;

public class ChooseForm : Form
{
    public ChooseForm()
    {
        Text = "Choose";
        Size = new Size(450, 300);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;


        Label lblTitle = new Label();
        lblTitle.Text = "CHOOSE AN OPTION";
        lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(105, 50);
        Controls.Add(lblTitle);


        Button btnBicycle = new Button();
        btnBicycle.Text = "Bicycle";
        btnBicycle.Size = new Size(130, 60);
        btnBicycle.Location = new Point(70, 130);
        btnBicycle.Click += btnBicycle_Click;
        Controls.Add(btnBicycle);


        Button btnMushroom = new Button();
        btnMushroom.Text = "Mushroom";
        btnMushroom.Size = new Size(130, 60);
        btnMushroom.Location = new Point(240, 130);
        btnMushroom.Click += btnMushroom_Click;
        Controls.Add(btnMushroom);
    }


    private void btnBicycle_Click(object sender, EventArgs e)
    {
        Hide();

        BicycleForm bicycleForm = new BicycleForm();

        DialogResult result = bicycleForm.ShowDialog();

        if (result == DialogResult.Abort)
        {
            Close();
        }
        else
        {
            Show();
        }
    }


    private void btnMushroom_Click(object sender, EventArgs e)
    {
        Hide();

        MushroomForm mushroomForm = new MushroomForm();

        DialogResult result = mushroomForm.ShowDialog();

        if (result == DialogResult.Abort)
        {
            Close();
        }
        else
        {
            Show();
        }
    }
}