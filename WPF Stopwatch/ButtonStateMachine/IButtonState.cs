using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Stopwatch {
    interface IButtonState {

        IButtonState ReactToButtonPress(Stopwatch stopwatch, Button mainButton, Button restartButton);

    }
}
