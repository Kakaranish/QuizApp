using System;
using System.Collections.Generic;


namespace QuizApp
{
    public static class CategoryRepository
    {
        public static Dictionary<string, Category> Categories { get; set; } = new Dictionary<string, Category>
        {
            {
                "History",
                new Category
                {
                    Name = "History",
                    Description = "History description. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras a libero nec velit maximus interdum quis ac orci. In sed velit nec metus dictum aliquam sit amet ac mauris. Pellentesque mi est, fringilla consequat feugiat quis, maximus in arcu. Phasellus luctus sed ante at mollis.",
                    ImageResourceId = Resource.Drawable.history
                }
            },
            {
                "Geography",
                new Category
                {
                    Name = "Geography",
                    Description = "Geography description. Donec eu nisl vitae nibh gravida pellentesque. Nulla in lacus elementum, tincidunt lacus in, sollicitudin urna. Cras euismod odio et rhoncus tristique. Quisque ut suscipit nunc, sed pretium metus. Donec non neque eu orci tempus vestibulum ut a ante. In fermentum convallis imperdiet.",
                    ImageResourceId = Resource.Drawable.geography
                }
            },
            {
                "Business",
                new Category
                {
                    Name = "Business",
                    Description = "Business description. Donec eu nisl vitae nibh gravida pellentesque. Nulla in lacus elementum, tincidunt lacus in, sollicitudin urna. Cras euismod odio et rhoncus tristique. Quisque ut suscipit nunc, sed pretium metus. Donec non neque eu orci tempus vestibulum ut a ante. In fermentum convallis imperdiet.",
                    ImageResourceId = Resource.Drawable.business
                }
            },
            {
                "Programming",
                new Category
                {
                    Name = "Programming",
                    Description = "Programming description. Donec pharetra dolor quis ex accumsan, id auctor quam consequat. Integer placerat nunc libero. Nam nisi dolor, vulputate sed purus id, facilisis elementum ligula. Praesent id nibh facilisis, egestas ex in, ultricies mi. Nulla et accumsan nibh, sed rhoncus justo.",
                    ImageResourceId = Resource.Drawable.programming
                }
            },
            {
                "Engineering",
                new Category
                {
                    Name = "Engineering",
                    Description = "Engineering description. Donec eu nisl vitae nibh gravida pellentesque. Nulla in lacus elementum, tincidunt lacus in, sollicitudin urna. Cras euismod odio et rhoncus tristique. Quisque ut suscipit nunc, sed pretium metus. Donec non neque eu orci tempus vestibulum ut a ante. In fermentum convallis imperdiet.",
                    ImageResourceId = Resource.Drawable.engineering
                }
            },
            {
                "Space",
                new Category
                {
                    Name = "Space",
                    Description = "Space description. Donec eu nisl vitae nibh gravida pellentesque. Nulla in lacus elementum, tincidunt lacus in, sollicitudin urna. Cras euismod odio et rhoncus tristique. Quisque ut suscipit nunc, sed pretium metus. Donec non neque eu orci tempus vestibulum ut a ante. In fermentum convallis imperdiet.",
                    ImageResourceId = Resource.Drawable.space
                }
            }
        };
    }
}