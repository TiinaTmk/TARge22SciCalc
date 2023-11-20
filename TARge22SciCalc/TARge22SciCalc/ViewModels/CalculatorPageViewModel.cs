using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ViewModels
{
    [INotifyPropertyChanged]
    internal partial class CalculatorPageViewModel
    {
        [ObservableProperty]
        private string inputText = string.Empty;

        [ObservableProperty]
        private string calculatedResult = "0";

        private bool isSciOpWaiting = false;

        [RelayCommand]
        private void Reset()
        {
            CalculatedResult = "0";
            InputText = string.Empty;
            isSciOpWaiting = false;
        }

        [RelayCommand]
        private void Calculate()
        {
            if (InputText.Length == 0)
            {
                return;
            }

            if (isSciOpWaiting)
            {
                InputText += ")";
                isSciOpWaiting = false;
            }

            try
            {
                var inputString = NormalizeInputString();
                var expression = new NCalc.Expression(inputString);
                var result = expression.Evaluate();

                CalculatedResult = result.ToString();
            }
            catch (Exception ex)
            {
                CalculatedResult = "NaN";
            }
        }

        private string NormalizeInputString()
        {
            Dictionary<string, string> _opMapper = new()
            {
                {"×", "*"},
                {"÷", "/"},
                {"SIN", "Sin"},
                {"COS", "Cos"},
                {"TAN", "Tan"},
                {"ASIN", "Asin"},
                {"ACOS", "Acos"},
                {"ATAN", "Atan"},
                {"LOG", "Log"},
                {"EXP", "Exp"},
                {"LOG10", "Log10"},
                {"POW", "Pow"},
                {"SQRT", "Sqrt"},
                {"ABS", "Abs"},
            };

            var retString = InputText;

            foreach (var key in _opMapper.Keys)
            {
                retString = retString.Replace(key, _opMapper[key]);
            }

            return retString;
        }

        [RelayCommand]
        private void Backspace()
        {
            if (InputText.Length > 0)
            {
                InputText = InputText.Substring(0, InputText.Length - 1);
            }
        }

        [RelayCommand]
        private void NumberInput(string key)
        {
            InputText += key;
        }

        [RelayCommand]
        private void MathOperator(string op)
        {
            if (isSciOpWaiting)
            {
                InputText += ")";
                isSciOpWaiting = false;
            }
            InputText += $" {op} ";
        }

        [RelayCommand]
        private void RegionOperator(string op)
        {
            if (isSciOpWaiting)
            {
                InputText += ")";
                isSciOpWaiting = false;
            }
            InputText += $" {op} ";
        }

        [RelayCommand]
        private void ScientificOperator(string op)
        {
            InputText += $"{op}(";
            isSciOpWaiting = true;
        }

        [RelayCommand]
        private void AC()
        {
            Reset();
        }

        [RelayCommand]
        private void Multiply()
        {
            MathOperator("×");
        }

        [RelayCommand]
        private void Divide()
        {
            MathOperator("÷");
        }

        [RelayCommand]
        private void Add()
        {
            MathOperator("+");
        }

        [RelayCommand]
        private void Subtract()
        {
            MathOperator("-");
        }

        [RelayCommand]
        private void Equals()
        {
            Calculate();
        }

        [RelayCommand]
        private void Dot()
        {
            NumberInput(".");
        }

        [RelayCommand]
        private void Zero()
        {
            NumberInput("0");
        }

        [RelayCommand]
        private void One()
        {
            NumberInput("1");
        }

        [RelayCommand]
        private void Two()
        {
            NumberInput("2");
        }

        [RelayCommand]
        private void Three()
        {
            NumberInput("3");
        }

        [RelayCommand]
        private void Four()
        {
            NumberInput("4");
        }

        [RelayCommand]
        private void Five()
        {
            NumberInput("5");
        }

        [RelayCommand]
        private void Six()
        {
            NumberInput("6");
        }

        [RelayCommand]
        private void Seven()
        {
            NumberInput("7");
        }

        [RelayCommand]
        private void Eight()
        {
            NumberInput("8");
        }

        [RelayCommand]
        private void Nine()
        {
            NumberInput("9");
        }
    }
}
