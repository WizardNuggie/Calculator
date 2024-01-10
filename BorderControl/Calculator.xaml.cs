using System.Data;

namespace BorderControl;

public partial class Calculator : ContentPage
{
	public Calculator()
	{
		InitializeComponent();
	}
	private void AddTextScreen(Object sender, EventArgs e)
	{
        if (screen.Text == "Error")
            screen.Text = " ";
        screen.Text += ((Button)sender).Text;
	}

    private void ResetScreen(object sender, EventArgs e)
    {
		screen.Text = " ";
    }

    private void DeleteScreen(object sender, EventArgs e)
    {
		if (screen.Text.Length > 0) screen.Text = screen.Text.Substring(0, screen.Text.Length - 1);
        else if (screen.Text == "Error")
            screen.Text = " ";
    }

    private void Calculate(object sender, EventArgs e)
    {
        if (screen.Text.Length == 0)
        {
            screen.Text = " ";
        }
        else if (screen.Text == "Error")
            screen.Text = " ";
        else if (screen.Text[screen.Text.Length - 1] < 48 || screen.Text[screen.Text.Length - 1] > 57)
        {
            DeleteScreen(sender, e);
        }
            try
            {
            string str = new DataTable().Compute(screen.Text, null).ToString();
                if (new DataTable().Compute(screen.Text, null).ToString() == "∞")
                    screen.Text = "Error";
                else
                    screen.Text = new DataTable().Compute(screen.Text, null).ToString();
            }
            catch
            {
                screen.Text = "Error";
            }
    }

    private void MethodAddTextScreen(object sender, EventArgs e)
    {
        if (screen.Text.Length > 0 && screen.Text[screen.Text.Length - 1] != '.' && screen.Text[screen.Text.Length - 1] != '-' && screen.Text[screen.Text.Length - 1] != '+' && screen.Text[screen.Text.Length - 1] != '*' && screen.Text[screen.Text.Length - 1] != '/')
        {
            if (((Button)sender).Text == ".")
                screen.Text += ((Button)sender).Text;
            else
            screen.Text += $" {((Button)sender).Text}";
        }
        else if (screen.Text.Length == 0 && ((Button)sender).Text == "-")
        {
            screen.Text += ((Button)sender).Text;
        }
    }
}