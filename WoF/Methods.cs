using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace WoF
{
    public static class Helpers
    {
        static readonly Regex Trimmer = new Regex(@"\s\s+");
        static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;
        public static string GenerateTopBottomRow (string text)
        {
            if (text.Length > 11) throw new Exception("Must be less than 11 characters");
            var newString = text.ToUpper();
            var spaces = (11 - text.Length) / 2;
            newString = newString.PadLeft(spaces).PadRight(spaces).Truncate(11);
            return newString;
        }

        public static string GenerateMiddleRow(string text)
        {
            if (text.Length > 13) throw new Exception("Must be less than 13 characters");
            var newString = text.ToUpper();
            var spaces = (13 - text.Length) / 2;
            newString = newString.PadLeft(spaces).PadRight(spaces).Truncate(13);
            return newString;
        }

        public static string GenerateCategoryRow(string text)
        {
            if (text.Length > 20) throw new Exception("Must be less than 13 characters");
            var newString = text.ToUpper();
            var spaces = (20 - text.Length) / 2;
            newString = newString.PadLeft(spaces).PadRight(spaces).Truncate(20);
            return newString;
        }

        public static List<GameQuestion> GetListOfQuestions(byte[] wheelData)
        {
            var gameQuestions = new List<GameQuestion>();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            // 68 is the length of a question and category.
            // the category is the last 20 bytes.
            for (var i = 0; i < wheelData.Length; i += 68)
            {
                var questionRaw = wheelData.SubArray(i, 68);
                var question = questionRaw.SubArray(0, 48);
                var category = questionRaw.SubArray(48, 20);
                var questionString = Encoding.ASCII.GetString(question);
                var categoryString = Encoding.ASCII.GetString(category);
                gameQuestions.Add(CreateGameQuestion(questionString, categoryString));
            }
            return gameQuestions;
        }

        public static GameQuestion CreateGameQuestion(string question, string category)
        {
            var questionNormalized = TextInfo.ToTitleCase(Trimmer.Replace(question, " ").ToLower().Trim());
            var categoryNormalized = TextInfo.ToTitleCase(Trimmer.Replace(category, " ").ToLower().Trim());
            return new GameQuestion
            {
                Category = category,
                Question = question,
                NormalizedQuestion = questionNormalized,
                NormalizedCategory = categoryNormalized
            };
        }

        public static byte[] CreateNewWheelDatTestFile(GameQuestion question)
        {
            var questionBytes = Encoding.ASCII.GetBytes(question.Question.ToUpper());
            var categoryBytes = Encoding.ASCII.GetBytes(question.Category.ToUpper());
            if (questionBytes.Length != 48) throw new Exception($"Question '{question.Question}' is not 48 bytes long!");
            if (categoryBytes.Length != 20) throw new Exception($"Category '{question.Category}' is not 20 bytes long!");
            var test = new byte[68];
            questionBytes.CopyTo(test, 0);
            categoryBytes.CopyTo(test, 48);
            var gameByteArray = new byte[380800];
            for(var i = 0; i < 380800; i += 68)
            {
                test.CopyTo(gameByteArray, i);
            }
            return gameByteArray;
        }

        public static byte[] CreateNewWheelDatFile(List<GameQuestion> gameQuestions)
        {
            if (gameQuestions.Count != 5600) throw new Exception("You _must_ have 5600 questions");
            var gameByteArray = new byte[380800];
            var byteNum = 0;
            foreach(var question in gameQuestions)
            {
                var test = new byte[68];
                var questionBytes = Encoding.ASCII.GetBytes(question.Question.ToUpper());
                var categoryBytes = Encoding.ASCII.GetBytes(question.Category.ToUpper());
                if (questionBytes.Length != 48) throw new Exception($"Question '{question.Question}' is not 48 bytes long!");
                if (categoryBytes.Length != 20) throw new Exception($"Category '{question.Category}' is not 20 bytes long!");
                questionBytes.CopyTo(test, 0);
                categoryBytes.CopyTo(test, 48);
                test.CopyTo(gameByteArray, byteNum);
                byteNum = byteNum + 68;
            }

            return gameByteArray;
        }
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    public static class LinqExtensions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
