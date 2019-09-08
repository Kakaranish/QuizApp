using System;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Widget;
using QuizApp.Models;
using Color = Android.Graphics.Color;

namespace QuizApp
{
    public class SummaryAnswersAdapter : RecyclerView.Adapter
    {
        public event EventHandler<SummaryAnswersRecyclerViewClickEventArgs> ItemClick;

        private List<UserAnswer> userAnswers;
        private static Color CorrectAnswerColor = Color.ParseColor("#ff669900");
        private static Color IncorrectAnswerColor = Color.ParseColor("#ffff4444");

        public SummaryAnswersAdapter(List<UserAnswer> userAnswers)
        {
            this.userAnswers = userAnswers;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layoutInflater = LayoutInflater.From(parent.Context);
            var itemView = layoutInflater.Inflate(Resource.Layout.summary_answer_layout, parent, false);

            var viewHolder = new SummaryAnswersRecyclerViewViewHolder(itemView, OnClick);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = (SummaryAnswersRecyclerViewViewHolder) viewHolder;

            var userAnswer = userAnswers[position];
            holder.questionNumberTextView.Text = $"Question {position + 1}";
            holder.questionTextView.Text = userAnswer.Question.Question;

            holder.answerTextView.Text = userAnswer.Answer;
            if (userAnswer.IsUserAnswerCorrect)
            {
                holder.answerTextView.SetTextColor(CorrectAnswerColor);
            }
            else
            {
                holder.answerTextView.SetTextColor(IncorrectAnswerColor);

                if (userAnswer.Answer == null)
                {
                    holder.answerTextView.Text = "You gave no answer";
                }
            }
        }

        public override int ItemCount => userAnswers.Count;

        void OnClick(SummaryAnswersRecyclerViewClickEventArgs args) => ItemClick?.Invoke(this, args);
    }

    public class SummaryAnswersRecyclerViewViewHolder : RecyclerView.ViewHolder
    {
        public TextView questionNumberTextView;
        public TextView questionTextView;
        public TextView answerTextView;

        public SummaryAnswersRecyclerViewViewHolder(View itemView, Action<SummaryAnswersRecyclerViewClickEventArgs> clickListener) : base(itemView)
        {

            questionNumberTextView = itemView.FindViewById<TextView>(Resource.Id.summary_questionNumberTextView);
            questionTextView = itemView.FindViewById<TextView>(Resource.Id.summary_questionTextView);
            answerTextView = itemView.FindViewById<TextView>(Resource.Id.summary_answerTextView);

            itemView.Click += (sender, e) => clickListener(new SummaryAnswersRecyclerViewClickEventArgs
            {
                View = itemView,
                Position = AdapterPosition
            });
        }
    }

    public class SummaryAnswersRecyclerViewClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}