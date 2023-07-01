using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DS1RParamReloader.GameHook;

namespace DS1RParamReloader;

public partial class MainWindow
{
    readonly DSRHook hook;
    readonly CancellationTokenSource tokenSource = new();
    
    public MainWindow()
    {
        InitializeComponent();
        hook = new DSRHook(1000, 5000);
        hook.Start();
        Task.Run(() => MonitorHook(tokenSource.Token));
    }
    
    void MonitorHook(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Dispatcher.Invoke(() =>
            {
                if (hook.Hooked)
                {
                    StatusTextBlock.Text = "Hook Status: Hooked";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.DarkGreen;
                }
                else
                {
                    StatusTextBlock.Text = "Hook Status: Unhooked";
                    StatusTextBlock.Foreground = System.Windows.Media.Brushes.DarkRed;
                }   
                
            });
            Thread.Sleep(1000);
        }
    }

    // void BrowseButton_Click(object sender, RoutedEventArgs e)
    // {
    //     OpenFileDialog openFileDialog = new()
    //     {
    //         Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*",
    //         FileName = "DarkSoulsRemastered.exe",
    //     };
    //     if (openFileDialog.ShowDialog() == true)
    //     {
    //         ExecutablePathTextBox.Text = openFileDialog.FileName;
    //     }
    // }

    void ReloadButton_Click(object sender, RoutedEventArgs e)
    {
        if (!hook.Hooked)
        {
            ResultTextBlock.Text = "Game is not hooked. Cannot reload param.";
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.DarkRed;
            return;
        }
        var button = (Button)sender;
        string? paramName = button.Content.ToString();
        if (paramName == null)
            return;
        hook.ReloadParam(paramName);
        ResultTextBlock.Text = $"{paramName} reloaded at {DateTime.Now}";
        ResultTextBlock.Foreground = System.Windows.Media.Brushes.DarkGreen;
    }
}