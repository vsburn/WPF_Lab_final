using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Lab_final.ViewModels;

namespace WPF_Lab_final.Models
{
    public static class Ariph
    {
        internal static string Calculate(double operand1, double operand2, MainWindowViewModel.Operations operation)
        {
            switch (operation)
            {
                case MainWindowViewModel.Operations.Empty:
                    {
                        return "";
                    }
                case MainWindowViewModel.Operations.Add:
                    {
                        return Format($"{operand1 + operand2}", false);
                    }
                case MainWindowViewModel.Operations.Sub:
                    {
                        return Format($"{operand1 - operand2}", false);
                    }
                case MainWindowViewModel.Operations.Div:
                    {
                        if (operand2 == 0)
                        {
                            return "Ошибка!";
                        }
                        return Format($"{operand1 / operand2}", false);
                    }
                case MainWindowViewModel.Operations.Mult:
                    {
                        return Format($"{operand1 * operand2}", false);
                    }
                default:
                    {
                        break;
                    }
            }
            return "";
        }
        internal static string Format(string num, bool changeSign)
        {
            double result = (changeSign ? -1 : 1) * double.Parse(num);
            if (num.Replace(" ", "").Replace(",", "").Replace("-", "").Length > 15)
            {
                return $"{result:0.###############E+0}";
            }
            return $"{result:#,###,###,###,###,##0.################}";
        }
    }
}
