using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Lab_final.Models;

namespace WPF_Lab_final.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public MainWindowViewModel()
        {
            field = "0";
            operationField = "";

            OneBtn = new RelayCommand(OnOneBtnExecute);
            TwoBtn = new RelayCommand(OnTwoBtnExecute);
            ThreeBtn = new RelayCommand(OnThreeBtnExecute);
            FourBtn = new RelayCommand(OnFourBtnExecute);
            FiveBtn = new RelayCommand(OnFiveBtnExecute);
            SixBtn = new RelayCommand(OnSixBtnExecute);
            SevenBtn = new RelayCommand(OnSevenBtnExecute);
            EightBtn = new RelayCommand(OnEightBtnExecute);
            NineBtn = new RelayCommand(OnNineBtnExecute);
            ZeroBtn = new RelayCommand(OnZeroBtnExecute);

            PlusBtn = new RelayCommand(OnPlusBtnExecute);
            MinusBtn = new RelayCommand(OnMinusBtnExecute);
            DivideBtn = new RelayCommand(OnDivideBtnExecute);
            MultiplyBtn = new RelayCommand(OnMultiplyBtnExecute);
            ClearBtn = new RelayCommand(OnClearBtnExecute);
            EqualBtn = new RelayCommand(OnEqualBtnExecute);

            BackspaceBtn = new RelayCommand(OnBackspaceBtnExecute);
            CleanEntryBtn = new RelayCommand(OnCleanEntryBtnExecute);
            ChangeSignBtn = new RelayCommand(OnChangeSignBtnExecute);
            CommaBtn = new RelayCommand(OnCommaBtnExecute);
        }

        #region Свойства        
        private string field;
        public string Field
        {
            get => field;
            set
            {
                field = value;
                OnPropertyChanged();
            }
        }

        //Состояние строки операции
        private string operationField;
        public string OperationField
        {
            get => operationField;
            set
            {
                operationField = value;
                OnPropertyChanged();
            }
        }

        //Первый операнд
        private double operand1;
        public double Operand1
        {
            get => operand1;
            set
            {
                operand1 = value;
                OnPropertyChanged();
            }
        }

        //Второй операнд
        private double operand2;
        public double Operand2
        {
            get => operand2;
            set
            {
                operand2 = value;
                OnPropertyChanged();
            }
        }

        //Типы операций
        public enum Operations
        {
            Empty, Add, Sub, Div, Mult
        }

        //Текущая операция
        private Operations operation;
        public Operations Operation
        {
            get => operation;
            set
            {
                operation = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Команды для ввода значений
        public ICommand OneBtn { get; }
        private void OnOneBtnExecute(object p)
        {
            InputSymbol("1");
        }

        public ICommand TwoBtn { get; }
        private void OnTwoBtnExecute(object p)
        {
            InputSymbol("2");
        }

        public ICommand ThreeBtn { get; }
        private void OnThreeBtnExecute(object p)
        {
            InputSymbol("3");
        }

        public ICommand FourBtn { get; }
        private void OnFourBtnExecute(object p)
        {
            InputSymbol("4");
        }

        public ICommand FiveBtn { get; }
        private void OnFiveBtnExecute(object p)
        {
            InputSymbol("5");
        }

        public ICommand SixBtn { get; }
        private void OnSixBtnExecute(object p)
        {
            InputSymbol("6");
        }

        public ICommand SevenBtn { get; }
        private void OnSevenBtnExecute(object p)
        {
            InputSymbol("7");
        }

        public ICommand EightBtn { get; }
        private void OnEightBtnExecute(object p)
        {
            InputSymbol("8");
        }

        public ICommand NineBtn { get; }
        private void OnNineBtnExecute(object p)
        {
            InputSymbol("9");
        }

        public ICommand ZeroBtn { get; }
        private void OnZeroBtnExecute(object p)
        {
            InputSymbol("0");
        }

        public ICommand CommaBtn { get; }
        private void OnCommaBtnExecute(object p)
        {
            InputSymbol(",");
        }

        public ICommand BackspaceBtn { get; }
        private void OnBackspaceBtnExecute(object p)
        {
            Backspace();
        }

        public ICommand CleanEntryBtn { get; }
        private void OnCleanEntryBtnExecute(object p)
        {
            CleanEntry();
        }

        public ICommand ChangeSignBtn { get; }
        private void OnChangeSignBtnExecute(object p)
        {
            ChangeSign();
        }
        #endregion

        #region Команды для расчета
        public ICommand ClearBtn { get; }
        private void OnClearBtnExecute(object p)
        {
            Clear();
        }

        public ICommand PlusBtn { get; }
        private void OnPlusBtnExecute(object p)
        {
            Input(Operations.Add);
        }

        public ICommand MinusBtn { get; }
        private void OnMinusBtnExecute(object p)
        {
            Input(Operations.Sub);
        }

        public ICommand DivideBtn { get; }
        private void OnDivideBtnExecute(object p)
        {
            Input(Operations.Div);
        }

        public ICommand MultiplyBtn { get; }
        private void OnMultiplyBtnExecute(object p)
        {
            Input(Operations.Mult);
        }

        public ICommand EqualBtn { get; }
        private void OnEqualBtnExecute(object p)
        {
            Equal();
        }

        #endregion

        #region Калькулятор
        //Строка ввода
        void InputSymbol(string symbol)
        {
            if (Field.Replace(" ", "").Replace(",", "").Replace("-", "").Length >= 15)
            {
                return;
            }

            if (OperationField.Contains("="))
            {
                Clear();
                if (symbol != ",")
                {
                    Field = symbol;
                }
                else
                {
                    Field += symbol;
                }

            }
            else if (Field == "0" && symbol != ",")
            {
                Field = symbol;
            }
            else if (Field.Contains(",") && symbol == ",")
            {
                return;
            }
            else if (symbol == ",")
            {
                Field += symbol;
            }
            else
            {
                Field += symbol;
                Field = Ariph.Format(Field, false);
            }
        }

        //Удаление последнего символа
        void Backspace()
        {
            if (Field == "Ошибка!")
            {
                Clear();
                return;
            }
            if (Field.Length == 1 ||
               (Field.Length == 2 && Field.Substring(0, 1) == "-"))
            {
                Field = "0";
                return;
            }

            else
            {
                Field = Ariph.Format(Field.Remove(Field.Length - 1), false);
            }

            if (OperationField.Contains("="))
            {
                string temp = Field;
                Clear();
                Field = temp;
            }
        }

        //Очистка поля ввода
        void CleanEntry()
        {
            if (OperationField.Contains("="))
            {
                Clear();
            }

            Field = "0";
        }

        //Смена знака
        void ChangeSign()
        {
            Field = Ariph.Format(Field, true);
        }

        //Очистка данных
        void Clear()
        {
            Operand1 = 0;
            Operand2 = 0;
            Field = "0";
            Operation = Operations.Empty;
            OperationField = "";
        }

        //Операция
        void Input(Operations operation)
        {
            if (Field == "Ошибка!")
            {
                Clear();
                return;
            }

            string result;
            string opSign = "";
            switch (operation)
            {
                case Operations.Empty:
                    return;
                case Operations.Add:
                    opSign = "+";
                    break;
                case Operations.Sub:
                    opSign = "-";
                    break;
                case Operations.Div:
                    opSign = "÷";
                    break;
                case Operations.Mult:
                    opSign = "×";
                    break;
            }

            if (Operation != Operations.Empty)
            {
                result = Ariph.Calculate(Operand1, double.Parse(Field), Operation);
                Operand1 = result != "Ошибка!" ? double.Parse(result) : 0;
            }
            else
            {
                Operand1 = double.Parse(Field);
            }

            OperationField = Ariph.Format($"{Operand1}", false) + $" {opSign}";
            Operation = operation;
            CleanEntry();
        }

        //Результат
        void Equal()
        {
            if (Field == "Ошибка!")
            {
                Clear();
                return;
            }
            if (Operation == Operations.Empty)
            {
                return;
            }

            Operand2 = double.Parse(Field);
            OperationField += " " + Ariph.Format($"{Operand2}", false) + " =";
            Field = Ariph.Calculate(Operand1, Operand2, Operation);
            Operation = Operations.Empty;
        }
        #endregion
    }
}
