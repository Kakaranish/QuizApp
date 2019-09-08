using System;
using System.Timers;
using Android.Support.V7.App;
using Android.Widget;
using QuizApp.Fragments;

namespace QuizApp
{
    public class QuizTimer
    {
        private Timer _timer;
        private TextView _displayTextView;
        private AppCompatActivity _activity;
        private TimeSpan? _remainingTime = null;

        public event EventHandler<EventArgs> CountdownCompleted;
        public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(60);
        public TimeSpan TickInterval { get; set; } = TimeSpan.FromSeconds(1);

        public QuizTimer(AppCompatActivity activity, TextView displayTextView)
        {
            _activity = activity;
            _displayTextView = displayTextView;

            InitTimer();
        }

        public void Start()
        {
            _remainingTime = Duration;
            _timer.Start();
            _activity.RunOnUiThread(() => 
                _displayTextView.Text = $"{_remainingTime.Value.Minutes:D2}:{_remainingTime.Value.Seconds:D2}"
            );
        }

        public void Stop()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }

            _remainingTime = null;
        }

        private void StopAndZeroDisplay()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }

            _activity.RunOnUiThread(() => _displayTextView.Text = "00:00");
            _remainingTime = null;
        }

        private void InitTimer()
        {
            _timer = new Timer
            {
                Interval = TickInterval.TotalMilliseconds
            };

            _timer.Elapsed += UpdateDisplayTextView;
        }

        private void UpdateDisplayTextView(object sender, ElapsedEventArgs args)
        {
            if (_remainingTime == null)
            {
                throw new ArgumentNullException(nameof(_remainingTime));
            }

            _remainingTime = _remainingTime.Value.Subtract(TickInterval);
            if (_remainingTime.Value.Seconds > 0)
            {
                _activity.RunOnUiThread(() => 
                    _displayTextView.Text = $"{_remainingTime.Value.Minutes:D2}:{_remainingTime.Value.Seconds:D2}"
                );
            }
            else
            {
                StopAndZeroDisplay();

                CountdownCompleted?.Invoke(sender, args);
            }
        }
    }
}