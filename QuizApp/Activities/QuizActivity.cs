using System;
using System.Collections.Generic;
using System.Drawing;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using QuizApp.Fragments;
using QuizApp.Models;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace QuizApp.Activities
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : AppCompatActivity
    {
        private string category;
        private List<QuizQuestion> questions;
        private List<UserAnswer> userAnswers;
        private int questionNumber;
        private QuizTimer quizTimer;

        private TextView timerTextView;
        private TextView questionHeaderTextView;
        private TextView questionTextView;
        private RadioGroup answerRadioGroup;
        private RadioButton answerARadioButton;
        private RadioButton answerBRadioButton;
        private RadioButton answerCRadioButton;
        private RadioButton answerDRadioButton;

        public int DisplayedQuestionNumber => questionNumber + 1;

        public QuizActivity()
        {
            questionNumber = 0;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.quiz_layout);
            
            category = Intent.GetStringExtra("Category");
            questions = QuizQuestionRepository.GetQuizQuestionsForCategoryName(category);

            InitUserAnswers();
            InitViews();
            InitToolbar();
            InitQuizTimer();

            StartQuiz();
        }

        private void InitUserAnswers()
        {
            userAnswers = new List<UserAnswer>();
            questions.ForEach(question => userAnswers.Add(new UserAnswer
            {
                Question = question,
                Answer = null
            }));
        }

        private void InitViews()
        {
            timerTextView = FindViewById<TextView>(Resource.Id.timerTextView);
            questionHeaderTextView = FindViewById<TextView>(Resource.Id.questionHeaderTextView);
            questionTextView = FindViewById<TextView>(Resource.Id.questionTextView);
            answerRadioGroup = FindViewById<RadioGroup>(Resource.Id.answersRadioGroup);
            answerARadioButton = FindViewById<RadioButton>(Resource.Id.answerARadioButton);
            answerBRadioButton = FindViewById<RadioButton>(Resource.Id.answerBRadioButton);
            answerCRadioButton = FindViewById<RadioButton>(Resource.Id.answerCRadioButton);
            answerDRadioButton = FindViewById<RadioButton>(Resource.Id.answerDRadioButton);

            var proceedButton = FindViewById<Button>(Resource.Id.proceedButton);
            proceedButton.Click += ProceedButtonOnClick;
        }

        private void InitQuizTimer()
        {
            quizTimer = new QuizTimer(this, timerTextView)
            {
                TickInterval = TimeSpan.FromSeconds(1),
                Duration = TimeSpan.FromMinutes(2)
            };
            quizTimer.CountdownCompleted += (sender, args) =>
            {
                var timeIsUpDialogFragment = new TimeIsUpGenericDialogFragment();
                timeIsUpDialogFragment.GoToSummaryEvent += TimeIsUpDialogFragmentOnGoToSummaryEvent;
                timeIsUpDialogFragment.Show(SupportFragmentManager, "TimeIsUpDialogFragment");
            };
        }

        private void InitToolbar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.quizToolbar);
            toolbar.Title = $"{category} Quiz";
            toolbar.SetTitleTextColor(Color.White.ToArgb());
            SetSupportActionBar(toolbar);

            var arrowBackDrawable = GetDrawable(Resource.Drawable.outline_arrowback);
            arrowBackDrawable.SetTint(Color.White.ToArgb());
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(arrowBackDrawable);
        }

        private void StartQuiz()
        {
            InitQuestionForCurrentQuestionIndex();
            quizTimer.Start();
        }

        private void ProceedButtonOnClick(object sender, EventArgs e)
        {
            var selectedAnswer = GetSelectedAnswer();
            if (selectedAnswer == null)
            {
                var toast = Toast.MakeText(this, "Select answer before moving to next question.", ToastLength.Short);
                toast.Show();

                return;
            }

            var currentQuestion = questions[questionNumber];
            var answer = userAnswers[questionNumber];
            answer.Answer = selectedAnswer;

            var bundle = new Bundle();
            var serializedAnswer = JsonConvert.SerializeObject(answer);
            bundle.PutString("Answer", serializedAnswer);

            var answerCorrectnessDialogFragment = new AnswerCorrectnessFragment
            {
                Arguments = bundle
            };
            answerCorrectnessDialogFragment.NextQuestion += AnswerCorrectnessDialogFragmentOnNextQuestion;
            answerCorrectnessDialogFragment.Show(SupportFragmentManager, "answer_correctness_fragment");
        }

        private string GetSelectedAnswer()
        {
            var selectedAnswerRadioButton = FindViewById<RadioButton>(answerRadioGroup.CheckedRadioButtonId);

            return selectedAnswerRadioButton?.Text;
        }

        private void AnswerCorrectnessDialogFragmentOnNextQuestion(object sender, EventArgs e)
        {
            ++questionNumber;

            if (ThereAreMoreQuestions())
            {
                InitQuestionForCurrentQuestionIndex();
            }
            else
            {
                InitSummaryActivity();
            }
        }

        private void InitQuestionForCurrentQuestionIndex()
        {
            var currentQuestion = questions[questionNumber];
            questionHeaderTextView.Text = $"Question {DisplayedQuestionNumber}/{questions.Count}";
            questionTextView.Text = currentQuestion.Question;

            answerARadioButton.Text = currentQuestion.AnswerA;
            answerBRadioButton.Text = currentQuestion.AnswerB;
            answerCRadioButton.Text = currentQuestion.AnswerC;
            answerDRadioButton.Text = currentQuestion.AnswerD;
            answerRadioGroup.ClearCheck();
        }

        private void InitSummaryActivity()
        {
            var serializedUserAnswers = JsonConvert.SerializeObject(userAnswers);
            var bundle = new Bundle();
            bundle.PutString("UserAnswers", serializedUserAnswers);

            var intent = new Intent(this, typeof(SummaryActivity));
            intent.PutExtra("UserAnswersBundle", bundle);
            StartActivity(intent);
            Finish();
        }

        private bool ThereAreMoreQuestions() => questionNumber < questions.Count;

        private void TimeIsUpDialogFragmentOnGoToSummaryEvent(object sender, EventArgs e)
        {
            InitSummaryActivity();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ArrowBackOnClick();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void ArrowBackOnClick()
        {
            var alertDialogBuilder = new AlertDialog.Builder(this);
            alertDialogBuilder
                .SetMessage("Do you want to abort quiz?")
                .SetPositiveButton("Yes", (sender, args) => InitSummaryActivity())
                .SetNegativeButton("No", (sender, args) => {});

            var alertDialog = alertDialogBuilder.Create();
            alertDialog.Show();
        }
    }
}