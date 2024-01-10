namespace BorderControl
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Calculator();
        }
    }
}