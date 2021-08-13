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
using System.Windows.Media.Animation;

namespace WPF_Stopwatch {
    public partial class StopwatchWindow : Window {

        private Stopwatch _stopwatch;
        private string _outputFormat = @"h\:mm\:ss\.fff";


        public StopwatchWindow() {
            InitializeComponent();

            _stopwatch = new Stopwatch();

            BindButtonsReactions();
            LaunchUpdateTimer();
        }

        private void BindButtonsReactions() {
            MainButton.Click += OnStartButtonClicked;
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Start();

            MainButton.Content = "STOP";

            MainButton.Click -= OnStartButtonClicked;
            MainButton.Click += OnStopButtonClicked;
            RestartButton.Click += OnRestartButtonClicked;
            SmoothlyShowRestartButton();
        }

        private void OnStopButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Stop();

            MainButton.FontSize = 48;
            MainButton.Content = "CONTINUE";

            MainButton.Click -= OnStopButtonClicked;
            MainButton.Click += OnContinueButtonClicked;
        }

        private void OnContinueButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Start();

            MainButton.FontSize = 54;
            MainButton.Content = "STOP";

            MainButton.Click -= OnContinueButtonClicked;
            MainButton.Click += OnStopButtonClicked;
        }

        private void OnRestartButtonClicked(object sender, RoutedEventArgs e) {
            _stopwatch.Restart();

            MainButton.FontSize = 54;
            MainButton.Content = "START";

            MainButton.Click -= OnStopButtonClicked;
            MainButton.Click -= OnContinueButtonClicked;
            MainButton.Click += OnStartButtonClicked;
            RestartButton.Click -= OnRestartButtonClicked;
            SmoothlyHideRestartButton();
        }

        private void SmoothlyShowRestartButton() {

            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 0;
            opacityAnimation.To = 1;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.5);

            RestartButton.BeginAnimation(OpacityProperty, opacityAnimation);
        }

        private void SmoothlyHideRestartButton() {

            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = 1;
            opacityAnimation.To = 0;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.5);

            RestartButton.BeginAnimation(OpacityProperty, opacityAnimation);
        }

        private void WindowOpacityAnimationCompleted(object sender, EventArgs e) {
            Application.Current.Shutdown();
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
