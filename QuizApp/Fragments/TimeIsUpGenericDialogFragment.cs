using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace QuizApp.Fragments
{
    public class TimeIsUpGenericDialogFragment : DialogFragment
    {
        public event EventHandler<EventArgs> GoToSummaryEvent;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var inflatedLayout = inflater.Inflate(Resource.Layout.time_is_up_layout, container, false);
            var goToSummaryButton = inflatedLayout.FindViewById<Button>(Resource.Id.goToSummaryButton);
            goToSummaryButton.Click += GoToSummaryButtonOnClick;

            return inflatedLayout;
        }

        private void GoToSummaryButtonOnClick(object sender, EventArgs e)
        {
            GoToSummaryEvent?.Invoke(sender, e);
        }
    }
}