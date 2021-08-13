using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Stopwatch {
    class ContinueButtonState : IButtonState {
        public IButtonState ReactToButtonPress(Stopwatch stopwatch, Button mainButton, Button restartButton) {

            stopwatch.Start();
            mainButton.Content = "STOP";
            mainButton.FontSize = 54;

            return new StopButtonState();
        }
    }
}
