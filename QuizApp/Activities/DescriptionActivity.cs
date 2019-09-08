using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using QuizApp.Activities;

namespace QuizApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class DescriptionActivity : AppCompatActivity
    {
        private string categoryName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.category_description_layout);

            categoryName = Intent.GetStringExtra("Category");
            var category = CategoryRepository.Categories[this.categoryName];

            var categoryTextView = FindViewById<TextView>(Resource.Id.categoryTextView);
            var categoryDescriptionTextView = FindViewById<TextView>(Resource.Id.categoryDescriptionTextView);
            var categoryImageView = FindViewById<ImageView>(Resource.Id.categoryImageView);
            var startQuizButton = FindViewById<Button>(Resource.Id.startQuizButton);
            
            SetUpCategoryImageView(categoryImageView, category);

            categoryTextView.Text = category.Name;
            categoryDescriptionTextView.Text = category.Description;
            startQuizButton.Click += StartQuizButtonOnClick;
        }

        private void SetUpCategoryImageView(ImageView categoryImageView, Category category)
        {
            if (category.ImageResourceId == null)
            {
                HideCategoryImageView(categoryImageView);
            }
            var categoryImageDrawable = GetDrawable(category.ImageResourceId.Value);
            if (categoryImageDrawable != null)
            {
                categoryImageView.SetImageDrawable(categoryImageDrawable);
            }
            else
            {
                HideCategoryImageView(categoryImageView);
            }
        }

        private void HideCategoryImageView(ImageView categoryImageView)
        {
            var layoutParams = new TableRow.LayoutParams();
            layoutParams.Height = 0;
            categoryImageView.LayoutParameters = layoutParams;
        }

        private void StartQuizButtonOnClick(object sender, EventArgs e)
        {
            if (CategoryHasAnyQuestions(categoryName) == false)
            {
                var toast = Toast.MakeText(this, "This category has no quiz questions at this moment.",
                    ToastLength.Short);
                toast.Show();
                Finish();
                return;
            }

            var intent = new Intent(this, typeof(QuizActivity));
            intent.PutExtra("Category", categoryName);
            StartActivity(intent);
            Finish();
        }

        private bool CategoryHasAnyQuestions(string categoryName)
        {
            var questionsForCategory = QuizQuestionRepository.GetQuizQuestionsForCategoryName(categoryName);
            return questionsForCategory.Count > 0;
        }
    }
}