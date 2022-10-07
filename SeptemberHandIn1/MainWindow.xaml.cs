using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SeptemberHandIn1._1_Controller;
using SeptemberHandIn1._5_Foundation;
using TextClassification.Controller;
using TextClassification.Domain;

namespace SeptemberHandIn1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BagOfWords bof;
        private KnowledgeBuilder kb;
        private List<string> entries;
        private Knowledge knowledge;
        private ObservableData _observableData = new ObservableData();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _observableData;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            long training = TimeMilliseconds.GetMilliseconds();
            kb = new();
            kb.Train();
            long trainingTime = TimeMilliseconds.GetMilliseconds() - training;
            TextBoxTrainingTime.Text = trainingTime.ToString();
            
            knowledge = kb.GetKnowledge();
            bof = knowledge.GetBagOfWords();
            entries = bof.GetEntriesInDictionary();
            _observableData.ObservableDictionaryList = new ObservableCollection<string>(entries);
        }
    }
}