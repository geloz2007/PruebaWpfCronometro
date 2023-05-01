using System;
using System.Windows;
using WpfService;
using WpfServices.Interface;

namespace WpfCronometro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        IChronometer chronometer;
        public MainWindow()
        {
            InitializeComponent();
            chronometer = Chronometer.ChronoNew(RefreshContenEvent);
        }

        private void RefreshContenEvent(object sender, EventArgs e)
        {
            chronometer.AddSecond();
            chronometerLabel.Content = chronometer.Value;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            chronometer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            chronometer.Pause();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            reset();
            chronometer.Stop();
        }

        private void reset()
        {
            chronometerLabel.Content = "00:00:00";
        
        }
    }
}
