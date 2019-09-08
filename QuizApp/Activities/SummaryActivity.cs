using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Newtonsoft.Json;
using QuizApp.Fragments;
using QuizApp.Models;

namespace QuizApp.Activities
{
    [Activity(Label = "SummaryActivity")]
    public class SummaryActivity : AppCompatActivity
    {
        private List<UserAnswer> userAnswers;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.summary_layout);

            var answersBundle = Intent.GetBundleExtra("UserAnswersBundle");
            var serializedUserAnswers = answersBundle.GetString("UserAnswers");
            userAnswers = JsonConvert.DeserializeObject<List<UserAnswer>>(serializedUserAnswers);

            var summaryHeaderTextView = FindViewById<TextView>(Resource.Id.summaryHeaderTextView);
            var numberOfCorrectAnswers = GetNumberOfCorrectAnswers(userAnswers);
            var numberOfQuestions = userAnswers.Count;
            summaryHeaderTextView.Text = $"Your score: {numberOfCorrectAnswers}/{numberOfQuestions}";

            var summaryRecyclerView = FindViewById<RecyclerView>(Resource.Id.quizAnswersRecyclerView);
            summaryRecyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var summaryAnswersAdapter = new SummaryAnswersAdapter(userAnswers);
            summaryAnswersAdapter.ItemClick += SummaryAnswersAdapterOnItemClick;
            summaryRecyclerView.SetAdapter(summaryAnswersAdapter);
        }

        private void SummaryAnswersAdapterOnItemClick(object sender, SummaryAnswersRecyclerViewClickEventArgs e)
        {
            var userAnswer = userAnswers[e.Position];
            if (userAnswer.IsUserAnswerCorrect == false)
            {
                var correctAnswerFragment = new CorrectAnswerFragment(userAnswer.Question.CorrectAnswer)
                {
                    Cancelable = false
                };
                correctAnswerFragment.Show(SupportFragmentManager, nameof(CorrectAnswerFragment));
            }
        }

        private int GetNumberOfCorrectAnswers(List<UserAnswer> userAnswers)
        {
            return userAnswers.Count(x => x.IsUserAnswerCorrect);
        }
    }
}