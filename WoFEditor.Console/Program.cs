using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoF;
using System.IO;

namespace WoFEditor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var wheelData = File.ReadAllBytes("WHEEL.DAT");
            //var test = Helpers.GetListOfQuestions(wheelData);
            //var newTest = Helpers.CreateNewWheelDatFile(test);
            //var result = wheelData.SequenceEqual(newTest);
            //var test2 = Helpers.GetListOfQuestions(newTest);
            var gameQuestions = new List<GameQuestion>();
            for (var i = 0; i < 5600; i++)
            {
                gameQuestions.Add(new GameQuestion { Category = "       QUEERS       ", Question = "             MY CUNT'S      A CUNT              " });
            }

            var newDat = Helpers.CreateNewWheelDatFile(gameQuestions);
            var newQuestions = Helpers.GetListOfQuestions(newDat);
            File.WriteAllBytes("NEWWHEEL.DAT", newDat);
        }
    }
}
