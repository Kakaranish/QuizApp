using System;

using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using QuizApp.Models;

namespace QuizApp.Fragments
{
    public class AnswerCorrectnessFragment : AppCompatDialogFragment
    {
        public event EventHandler<EventArgs> NextQuestion;

        private UserAnswer _userAnswer;

        private ImageView answerTypeImageView;
        private TextView statementTextView;
        private TextView correctAnswerTextView;
        private Button nextQuestionButton;

        public override void OnCreate(Bundle savedInstanceState)
        {
            var bundle = Arguments;
            var serializedAnswer = bundle.GetString("Answer");
            _userAnswer = JsonConvert.DeserializeObject<UserAnswer>(serializedAnswer);
            
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var inflatedView = inflater.Inflate(Resource.Layout.answer_correctness_layout, container);
            InitViews(inflatedView);

            nextQuestionButton.Click += NextQuestionButtonOnClick;

            return inflatedView;
        }

        private void InitViews(View inflatedView)
        {
            answerTypeImageView = inflatedView.FindViewById<ImageView>(Resource.Id.answerTypeImageView);
            statementTextView = inflatedView.FindViewById<TextView>(Resource.Id.statementTextView);
            correctAnswerTextView = inflatedView.FindViewById<TextView>(Resource.Id.correctAnswerTextView);
            nextQuestionButton = inflatedView.FindViewById<Button>(Resource.Id.nextQuestionButton);

            if (_userAnswer.IsUserAnswerCorrect)
            {
                answerTypeImageView.SetImageResource(Resource.Drawable.correct);
                statementTextView.SetHeight(0);
                correctAnswerTextView.Text = "Your answer is correct!";
            }
            else
            {
                answerTypeImageView.SetImageResource(Resource.Drawable.wrong);
                statementTextView.Text = "The correct answer is actually";
                correctAnswerTextView.Text = _userAnswer.Question.CorrectAnswer;
            }
        }

        private void NextQuestionButtonOnClick(object sender, EventArgs e)
        {
            Dismiss();
            NextQuestion?.Invoke(this, e);
        }
    }
}