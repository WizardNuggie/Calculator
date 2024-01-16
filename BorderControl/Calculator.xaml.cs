using System.Data;

namespace BorderControl;

public partial class Calculator : ContentPage
{
    string saveAns = "";
	public Calculator()
	{
		InitializeComponent();
        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            screenBorder.HeightRequest = 120;
            screenBorder.WidthRequest = 300;
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            screenBorder.HeightRequest = 200;
            screenBorder.WidthRequest = 1000;
            del.FontSize = 45;
            ans.FontSize = 45;
        }
	}
	private void AddTextScreen(Object sender, EventArgs e)
	{
        if (resScreen.Text.Length > 0)
        {
            resScreen.Text = "";
            totalScreen.Text = "";
        }
        if (currScreen.Text.Length > 0 && (currScreen.Text[currScreen.Text.Length - 1] < 48 || currScreen.Text[currScreen.Text.Length - 1] > 57) && (currScreen.Text.Length != 1 && currScreen.Text[currScreen.Text.Length-1] != '-') && currScreen.Text[currScreen.Text.Length - 1] != '.')
        {
            currScreen.Text = "";
        }
        currScreen.Text += ((Button)sender).Text;
        if (currScreen.Text.Contains("-"))
            totalScreen.Text += currScreen.Text.Substring(1);
        else
            totalScreen.Text += currScreen.Text;
    }

    private void ResetScreen(object sender, EventArgs e)
    {
        totalScreen.Text = "";
		currScreen.Text = "";
        resScreen.Text = "";
        saveAns = "";
    }

    private void DeleteScreen(object sender, EventArgs e)
    {
		if (currScreen.Text.Length > 0) currScreen.Text = currScreen.Text.Substring(0, currScreen.Text.Length - 1);
        else if (currScreen.Text == "Error")
            currScreen.Text = "";
    }

    private void Calculate(object sender, EventArgs e)
    {
        currScreen.Text = "";
        if (totalScreen.Text == "")
            return;
        if (totalScreen.Text[totalScreen.Text.Length - 1] < 48 || totalScreen.Text[totalScreen.Text.Length - 1] > 57)
        {
            DeleteScreen(sender, e);
        }
            try
            {
                string compute = new DataTable().Compute(totalScreen.Text, null).ToString();
                if (compute == "∞" || compute == "NaN")
                resScreen.Text = "Error";
                else
                {
                    resScreen.Text = compute;
                    saveAns = resScreen.Text;
                }
            }
            catch
            {
                resScreen.Text = "Error";
            }
    }

    private void MethodAddTextScreen(object sender, EventArgs e)
    {
        if (currScreen.Text.Contains('.') && ((Button)sender).Text == ".")
        {

        }
        else if (currScreen.Text.Length > 0 && currScreen.Text[currScreen.Text.Length - 1] != '.' && currScreen.Text[currScreen.Text.Length - 1] != '-' && currScreen.Text[currScreen.Text.Length - 1] != '+' && currScreen.Text[currScreen.Text.Length - 1] != '*' && currScreen.Text[currScreen.Text.Length - 1] != '/')
        {
                currScreen.Text = "";
                totalScreen.Text += ((Button)sender).Text;
        }
        else if (totalScreen.Text.Length == 0 && ((Button)sender).Text == "-")
        {
            currScreen.Text += ((Button)sender).Text;
            totalScreen.Text += ((Button)sender).Text;
        }
        else if (resScreen.Text.Length > 0)
        {
            Ans(sender, e);
            MethodAddTextScreen(sender, e);
        }
    }
    private void Ans(object sender, EventArgs e)
    {
        if (saveAns.Length > 0)
        {
            string ans = saveAns;
            Button ansBut = new Button();
            ansBut.Text = ans;
            AddTextScreen(ansBut, e);
        }
    }
}