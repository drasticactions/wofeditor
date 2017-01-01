using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoF;
using System.IO;

namespace WofEditor.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<GameQuestion> GameQuestions { get; set; }

        public GameQuestion SelectedQuestion { get; set; }

        public char[] Prompt { get; set; }

        public char[] Category { get; set; }

        public void Update()
        {
            if (SelectedQuestion != null)
            {
                Prompt = SelectedQuestion.Question.ToCharArray();
                Category = SelectedQuestion.Category.ToCharArray();
            }
            OnPropertyChanged("GameQuestions");
            OnPropertyChanged("Prompt");
            OnPropertyChanged("Category");
            OnPropertyChanged("SelectedQuestion");
        }

        public void Init()
        {
            LoadQuestions("WHEEL.DAT");
        }

        public void LoadQuestions(string path)
        {
            var wheelData = File.ReadAllBytes(path);
            GameQuestions = Helpers.GetListOfQuestions(wheelData);
            Update();
        }

        public void SaveNewDat(string path)
        {
            var newDat = Helpers.CreateNewWheelDatFile(GameQuestions);
            File.WriteAllBytes(path, newDat);
        }

        public void SaveTestDat(string path)
        {
            var newGameQuestion = Helpers.CreateGameQuestion(new string(Prompt), new string(Category));
            var newDat = Helpers.CreateNewWheelDatTestFile(newGameQuestion);
            File.WriteAllBytes(path, newDat);
        }

        public void Save()
        {
            var newGameQuestion = Helpers.CreateGameQuestion(new string(Prompt), new string(Category));
            SelectedQuestion.Category = newGameQuestion.Category;
            SelectedQuestion.NormalizedCategory = newGameQuestion.NormalizedCategory;
            SelectedQuestion.NormalizedQuestion = newGameQuestion.NormalizedQuestion;
            SelectedQuestion.Question = newGameQuestion.Question;
            Update();
        }
    }
}
