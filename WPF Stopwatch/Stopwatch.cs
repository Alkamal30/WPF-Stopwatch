using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Stopwatch {
    class Stopwatch {

        private bool _isWorked;
        private DateTime _startTime;
        private TimeSpan _deltaTime;

        public TimeSpan DeltaTime {
            get {
                if(_isWorked)
                    return _deltaTime + CalculateDifferenceBetweenStartTimeAndCurrentTime();
                else
                    return _deltaTime;
            }
        }


        public Stopwatch() {
            _isWorked = false;
            NullifyVariables();
        }

        public void Start() {
            if(!_isWorked) {
                StartWork();
            }
        }

        public void Stop() {
            if(_isWorked) {
                StopWork();
            }
        }

        public void Restart() {
            Stop();
            NullifyVariables();
        }


        private void NullifyVariables() {
            _startTime = new DateTime();
            _deltaTime = new TimeSpan();
        }

        private void StartWork() {
            _isWorked = true;
            _startTime = DateTime.Now;
        }

        private void StopWork() {
            _isWorked = false;
            _deltaTime += CalculateDifferenceBetweenStartTimeAndCurrentTime();
        }

        private TimeSpan CalculateDifferenceBetweenStartTimeAndCurrentTime() {
            DateTime currentTime = DateTime.Now;
            return currentTime.Subtract(_startTime);
        }

    }
}
