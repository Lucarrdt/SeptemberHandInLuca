using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextClassification.Controller;
using TextClassification.Domain;
using TextClassification.Foundation;

namespace SeptemberHandIn1._1_Controller;

public class ObservableData : Bindable
    {
        private ObservableCollection<string> _observableA;
        private ObservableCollection<string> _observableB;
        private ObservableCollection<string> _observableAb;
        private ObservableCollection<int> _observableTokens;
        private ObservableCollection<string> _observableDictionaryList;
        public static List<string> tokens;


        public ObservableData()
        {
            tokens = new List<string>();
            FileListBuilder fileListBuilder = new FileListBuilder();
            fileListBuilder.GenerateFileNamesInA();
            fileListBuilder.GenerateFileNamesInB();
            FileLists fileLists = fileListBuilder.GetFileLists();

            _observableA = new ObservableCollection<string>(fileLists.GetA().Select(StringOperations.getFileName));
            _observableB = new ObservableCollection<string>(fileLists.GetB().Select(StringOperations.getFileName));
            _observableAb = new ObservableCollection<string>(ObservableA.Concat(ObservableB));

            KnowledgeBuilder knowledgeBuilder = new KnowledgeBuilder();
            knowledgeBuilder.BuildFileLists();
            ObservableCollection<int> temp = new ObservableCollection<int>();
            for (int i = 0; i < _observableA.Count; i++)
            {
                temp.Add(knowledgeBuilder.GetTokenCount("ClassA", ObservableA[i]));
            }
            for (int i = 0; i < _observableB.Count; i++)
            {
                temp.Add(knowledgeBuilder.GetTokenCount("ClassB", ObservableB[i]));
            }
            _observableTokens = temp;

            

        }

        public ObservableCollection<string> ObservableA
        {
            get => _observableA;
            set
            {
                _observableA = value;
                PropertyIsChanged();
            }
        }

        public ObservableCollection<string> ObservableB
        {
            get => _observableB;
            set
            {
                _observableB = value;
                PropertyIsChanged();
            }
        }

        public ObservableCollection<string> ObservableAb
        {
            get => _observableAb;
            set
            {
                _observableAb = value;
                PropertyIsChanged();
            }
        }

        public ObservableCollection<int> ObservableTokens
        {
            get => _observableTokens;
            set
            {
                _observableTokens = value;
                PropertyIsChanged();
            }
        }

        public ObservableCollection<string> ObservableDictionaryList
        {
            get => _observableDictionaryList;

            set
            {
                _observableDictionaryList = value;
                PropertyIsChanged();
            }
        }
    }

