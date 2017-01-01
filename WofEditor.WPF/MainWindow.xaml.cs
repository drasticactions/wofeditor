using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WofEditor.WPF.ViewModels;

namespace WofEditor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = (MainWindowViewModel)DataContext;
            ViewModel.Init();
        }

        public MainWindowViewModel ViewModel { get; set; }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.Update();
        }

        private void OpenDat_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Wheel Of Fortune Database (*.DAT) | *.DAT;";
            if (openFileDialog.ShowDialog() == true)
            {
                ViewModel.LoadQuestions(openFileDialog.FileName);
            }
        }

        private void SaveDat_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Wheel Of Fortune Database (*.DAT) | *.DAT;";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "DAT";
            if (saveFileDialog.ShowDialog() == true)
            {
                ViewModel.SaveNewDat(saveFileDialog.FileName);
            }
        }

        private void SaveTestButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Wheel Of Fortune Database (*.DAT) | *.DAT;";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "DAT";
            if (saveFileDialog.ShowDialog() == true)
            {
                ViewModel.SaveTestDat(saveFileDialog.FileName);
            }
        }
    }
}
