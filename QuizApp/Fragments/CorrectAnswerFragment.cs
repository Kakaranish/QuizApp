using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace QuizApp.Fragments
{
    public class CorrectAnswerFragment : AppCompatDialogFragment
    {
        private string correctAnswer;

        public CorrectAnswerFragment(string correctAnswer)
        {
            this.correctAnswer = correctAnswer;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var inflatedView = inflater.Inflate(Resource.Layout.correct_answer_layout, container, false);
            var correctAnswerTextView = inflatedView.FindViewById<TextView>(Resource.Id.correctAnswerTextView);
            var correctAnswerOkButton = inflatedView.FindViewById<Button>(Resource.Id.correctAnswerOkButton);

            correctAnswerTextView.Text = correctAnswer;
            correctAnswerOkButton.Click += (sender, args) => Dismiss();

            return inflatedView;
        }
    }
}