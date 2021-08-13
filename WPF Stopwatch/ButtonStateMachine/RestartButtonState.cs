using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Stopwatch {
    class RestartButtonState : IButtonState {
        public IButtonState ReactToButtonPress(Stopwatch stopwatch, Button mainButton, Button restartButton) {

            stopwatch.Restart();
            mainButton.Content = "START";

            restartButton.Opacity = 0;

            return new StartButtonState();
        }
    }
}
