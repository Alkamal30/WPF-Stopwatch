using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Stopwatch {
    class ButtonStateMachine {

        private IButtonState _buttonState;

        public ButtonStateMachine() {
            _buttonState = new StartButtonState();
        }

        public void ChangeMainButtonState(Stopwatch stopwatch, Button mainButton, Button restartButton) {
            _buttonState = _buttonState.ReactToButtonPress(stopwatch, mainButton, restartButton);
        }

        public void ChangeRestartButtonState(Stopwatch stopwatch, Button mainButton, Button restartButton) {
            _buttonState = new RestartButtonState();
            _buttonState = _buttonState.ReactToButtonPress(stopwatch, mainButton, restartButton);
        }

    }
}
