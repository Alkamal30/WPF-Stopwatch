using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Stopwatch {
    public partial class MainWindow : Window {

        private Stopwatch _stopwatch;
        private string _outputFormat = @"hh\:mm\:ss\.fff";


        public MainWindow() {
            InitializeComponent();

            _stopwatch = new Stopwatch();

            BindButtonsReactions();
            LaunchUpdateTimer();
        }

        private void BindButtonsReactions() {
            StartButton.Click += OnStartButtonClicked;
            StopButton.Click += OnStopButtonClicked;
            RestartButton.Click += OnRestartButtonClicked;
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Start();
        }
        
        private void OnStopButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Stop();
        }

        private void OnRestartButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Restart();
        }


        private void LaunchUpdateTimer() {
            System.Windows.Threading.DispatcherTimer updateTimer = new System.Windows.Threading.DispatcherTimer();
            updateTimer.Tick += new EventHandler(UpdateTimerTick);
            updateTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            updateTimer.Start();
        }

        private void UpdateTimerTick(object sender, EventArgs eventArgs) {
            StopwatchText.Text = _stopwatch.DeltaTime.ToString(_outputFormat);
        }
    }
}
