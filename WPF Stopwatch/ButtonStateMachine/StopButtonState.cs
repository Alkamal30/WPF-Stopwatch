using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Stopwatch {
    class StopButtonState : IButtonState {
        public IButtonState ReactToButtonPress(Stopwatch stopwatch, Button mainButton, Button restartButton) {

            stopwatch.Stop();
            mainButton.Content = "CONTINUE";
            mainButton.FontSize = 48;

            return new ContinueButtonState();
        }
    }
}
