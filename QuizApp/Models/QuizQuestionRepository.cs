using System.Collections.Generic;

namespace QuizApp
{
    public static class QuizQuestionRepository
    {
        public static readonly List<QuizQuestion> HistoryQuestions = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Question = "During which decade was slavery abolished in the United States?",
                CorrectAnswer = "1860s",
                AnswerA = "1860s",
                AnswerB = "1840s",
                AnswerC = "1850s",
                AnswerD = "1870"
            },
            new QuizQuestion
            {
                Question = "During which year did Christopher Columbus first arrive in the Americas?",
                CorrectAnswer = "1495",
                AnswerA = "1495",
                AnswerB = "1492",
                AnswerC = "1498",
                AnswerD = "1501"
            },
            new QuizQuestion
            {
                Question = "Which year was the first edition of FIFA World Cup played",
                CorrectAnswer = "1930",
                AnswerA = "1985",
                AnswerB = "1920",
                AnswerC = "1930",
                AnswerD = "2002"
            },
            new QuizQuestion
            {
                Question =
                    "World War II also known as the Second World War, was a global war that lasted from 1939 to ?",
                CorrectAnswer = "1945",
                AnswerA = "1986",
                AnswerB = "1922",
                AnswerC = "1945",
                AnswerD = "1939"
            },
            new QuizQuestion
            {
                Question =
                    "The assassination of Julius Caesar was the result of a conspiracy by many Roman senators, he was stabbed by?",
                CorrectAnswer = "Junius Brutus",
                AnswerA = "Uchenna Nnodim",
                AnswerB = "Cassius Longinus",
                AnswerC = "Junius Brutus",
                AnswerD = "Orsa Kemi"
            }
        };

        public static List<QuizQuestion> GeographyQuestions = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Question = "What is the largest country in the world (by Area)?",
                CorrectAnswer = "Russia",
                AnswerA = "Russia",
                AnswerB = "Canada",
                AnswerC = "United Sates",
                AnswerD = "China"
            },
            new QuizQuestion
            {
                Question = "Which of the following countries does NOT have a population exceeding 200 million?",
                CorrectAnswer = "Nigeria",
                AnswerA = "Brazil",
                AnswerB = "Indonesia",
                AnswerC = "Pakistan",
                AnswerD = "Nigeria"
            },
            new QuizQuestion
            {
                Question = "Muscat is the capital of which country?",
                CorrectAnswer = "Oman",
                AnswerA = "Oman",
                AnswerB = "Jordan",
                AnswerC = "Yemen",
                AnswerD = "Bahrain"
            },
            new QuizQuestion
            {
                Question = "Which is the world's smallest continent (by area)?",
                CorrectAnswer = "Oceania",
                AnswerA = "Oceania",
                AnswerB = "Antractica",
                AnswerC = "South America",
                AnswerD = "Europe"
            },
            new QuizQuestion
            {
                Question = "Which of the following countries is NOT a member state of the European Union?",
                CorrectAnswer = "Norway",
                AnswerA = "Finland",
                AnswerB = "Sweden",
                AnswerC = "Norway",
                AnswerD = "Denmark"
            }
        };

        public static List<QuizQuestion> SpaceQuestions = new List<QuizQuestion>
        {
            new QuizQuestion
            {
                Question = "Who was the frst man to ever walk on the Moon?",
                CorrectAnswer = "Niel Armstrong",
                AnswerA = "Uchenna Nnodim",
                AnswerB = "Niel Armstrong",
                AnswerC = "Benjamin Franklin",
                AnswerD = "Pele Pele"
            },
            new QuizQuestion
            {
                Question = "The coldest and farthest Planet from the Sun is ?",
                CorrectAnswer = "Pluto",
                AnswerA = "Earth",
                AnswerB = "Pluto",
                AnswerC = "Neptune",
                AnswerD = "Saturn"
            },
            new QuizQuestion
            {
                Question = "The galaxy that contains Solar System which Earth belongs to is called what?",
                CorrectAnswer = "Milky Way",
                AnswerA = "Chocolate Path",
                AnswerB = "Phantom Zone",
                AnswerC = "Milky Way",
                AnswerD = "Solar Container"
            },
            new QuizQuestion
            {
                Question = "How many days does it take the Earth to complete her orbit",
                CorrectAnswer = "365 Days",
                AnswerA = "365 Days",
                AnswerB = "30 Days",
                AnswerC = "272 Days",
                AnswerD = "None of the Above"
            },
            new QuizQuestion
            {
                Question =
                    "An explosion which leads to gigantic explosion throwing star's outer layers are thrown out is called",
                CorrectAnswer = "Supernova",
                AnswerA = "Black hole",
                AnswerB = "Double ring",
                AnswerC = "Massive Explosion",
                AnswerD = "Supernova"
            }
        };

        public static List<QuizQuestion> GetQuizQuestionsForCategoryName(string categoryName)
        {
            switch (categoryName)
            {
                case "History":
                    return HistoryQuestions;
                case "Geography":
                    return GeographyQuestions;
                case "Space":
                    return SpaceQuestions;
                default:
                    return new List<QuizQuestion>();
            }
        }
    }
}