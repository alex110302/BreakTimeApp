namespace BreakTime;

public partial class MainPage : ContentPage
{
    int minutes;
    
    bool isCountingDown;
    bool isBreakTime;
    
    public MainPage()
    {
        InitializeComponent();
        lblDisplay.Text = "No Time Set";
        ftmMain.BackgroundColor = Colors.White;
    }

    private void btnFiveMin_OnClicked(object sender, EventArgs e)
    {
        minutes = 5;
        SetDefaultValues();
        isCountingDown = true;
        StartCountDown();
    }
    
    private void btnTenMin_OnClicked(object sender, EventArgs e)
    {
        minutes = 10;
        SetDefaultValues();
        isCountingDown = true;
        StartCountDown();
    }
    
    private void btnFifteenMin_OnClicked(object sender, EventArgs e)
    {
        minutes = 15;
        SetDefaultValues();
        isCountingDown = true;
        StartCountDown();
    }

    private void ShowBreakTime()
    {
        int checkSeconds = 0;
        lblDisplay.Text = "Break Over!!!!";
        Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            checkSeconds++;
            
            if (checkSeconds % 2 == 0) ftmMain.BackgroundColor = Colors.Red;
            else ftmMain.BackgroundColor = Colors.White;
            
            return isBreakTime;
        });
    }
    
    private void StartCountDown()
    {
        minutes--;
        
        Application.Current.Dispatcher.StartTimer(TimeSpan.FromMinutes(1), () =>
        {
            lblDisplay.Text = $"{minutes} : Till break is over";
            
            if (minutes == 0) isCountingDown = false;
            if (!isCountingDown)
            {
                isBreakTime = true;
                ShowBreakTime();
            }
            
            minutes--;
            
            return isCountingDown;
        });
    }

    private void SetDefaultValues()
    {
        lblDisplay.Text = $"{minutes} : Till break is over"; 
        isBreakTime = false;
        ftmMain.BackgroundColor = Colors.White;
    }
}