using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using TestManyPage.Models;

namespace TestManyPage.ViewModels
{
    internal class Page2ViewModel:ViewModelBase
    {
        public double Count
        {
            get => Data.first1;
            set => this.RaiseAndSetIfChanged(ref Data.first1, value);
        }
        public double Count2
        {
            get => Data.second2;
            set => this.RaiseAndSetIfChanged(ref Data.second2, value);
        }

        public List<string> Varios => Data.ActionsList;
        public List<string> strings => Data.History;

        public string SelectItem
        {
            get => Data._selectedOperations;
            set
            {
                this.RaiseAndSetIfChanged(ref Data._selectedOperations, value);
                DoOperationsToString();
            }

        }
        public string Result
        {
            get => Data.result;
            set => this.RaiseAndSetIfChanged(ref Data.result, value);
        }

        public char selOperToString
        {
            get => Data.selectedOperations23;
            set => this.RaiseAndSetIfChanged(ref Data.selectedOperations23, value);
        }

        public void DoOperationsToString()
        {


            switch (Data._selectedOperations)
            {
                case "Сложение":
                    selOperToString = '+';
                    break;
                case "Вычитание":
                    selOperToString = '-';
                    break;
                case "Умножение":
                    selOperToString = '*';
                    break;
                case "Деление":
                    selOperToString = '/';
                    break;
            }
        }

        public void DoOperations()
        {
            string operation = "";

            switch (Data._selectedOperations)
            {
                case "Сложение":
                    Result = (Data.first1 + Data.second2).ToString();
                    operation = $"{Count} + {Count2} = {Result}";
                    break;
                case "Вычитание":
                    Result = (Data.first1 - Data.second2).ToString();
                    operation = $"{Count} - {Count2} = {Result}";
                    break;
                case "Умножение":
                    Result = (Data.first1 * Data.second2).ToString();
                    operation = $"{Count} * {Count2} = {Result}";
                    break;
                case "Деление":
                    Result = (Data.first1 / Data.second2).ToString();
                    operation = $"{Count} / {Count2} = {Result}";
                    break;
            }
            if (!string.IsNullOrEmpty(operation))
            {
                Data.History.Add(operation);

                if (Data.History.Count > Data.MaxHistoryCount)
                    Data.History.RemoveAt(0);

                this.RaisePropertyChanged(nameof(HistoryDisplay));
            }

        }
        public string HistoryDisplay
        {
            get => string.Join(Environment.NewLine, Data.History);
        }

        public void BackToStr()
        {
            MainWindowViewModel.Instance.Uc = new Page1();
        }
    }
}
