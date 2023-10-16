namespace _3.Задание
{




   
    class Program
    {


        /// <summary>
        /// Пользователь вводит число от 1 до 9999 (сумму выдачи в банкомате). 
        /// Необходимо вывести на экран словами введенную сумму и в конце написать название валюты с правильным окончанием.
        /// </summary>
        static void Main()
        {
            // Создание делегатов Action<T> и Func<T>
            Action<string> displayAmount = DisplayAmountInWords;
            Func<int, string> convertAmount = ConvertNumberToWords;

            // Ввод суммы выдачи
            Console.Write("Введите сумму выдачи в банкомате (от 1 до 9999): ");
            int amount = int.Parse(Console.ReadLine());

            // Преобразование числа в слова
            string amountInWords = convertAmount(amount);

            // Вывод суммы на экран
            displayAmount(amountInWords);


            Console.ReadLine();
        }

        static string ConvertNumberToWords(int number)
        {
            string[] units =
            {
            "ноль", "одна", "две", "три", "четыре",
            "пять", "шесть", "семь", "восемь", "девять",
            "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать",
            "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
        };

            string[] tens =
            {
            "", "", "двадцать", "тридцать", "сорок",
            "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто"
        };

            string[] hundreds =
            {
            "", "сто", "двести", "триста", "четыреста",
            "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
        };

            if (number == 0)
            {
                return "ноль";
            }

            // Получение разрядов числа
            int thousands = number / 1000;
            int hundredsPart = (number % 1000) / 100;
            int tensPart = (number % 100) / 10;
            int unitsPart = number % 10;

            string result = "";

            // Преобразование тысяч
            if (thousands > 0)
            {
                result += $"{units[thousands]} тысяч ";
            }

            // Преобразование сотен
            if (hundredsPart > 0)
            {
                result += $"{hundreds[hundredsPart]} ";
            }

            // Преобразование десятков и единиц
            if (tensPart > 1)
            {
                result += $"{tens[tensPart]} ";
                if (unitsPart > 0)
                {
                    result += units[unitsPart];
                }
            }
            else if (tensPart == 1)
            {
                result += units[tensPart * 10 + unitsPart];
            }
            else if (unitsPart > 0)
            {
                result += units[unitsPart];
            }

            return result;
        }

        static void DisplayAmountInWords(string amount)
        {
            Console.WriteLine($"Сумма выдачи: {amount} {GetCurrencyEnding(amount)}");
        }

        static string GetCurrencyEnding(string amount)
        {
            int lastDigit;

            if (int.TryParse(amount[^1].ToString(), out lastDigit))
            {
                if (amount.Length >= 2 && amount[^2] == '1')
                {
                    return "рублей";
                }
                else if (lastDigit == 1)
                {
                    return "рубль";
                }
                else if (lastDigit >= 2 && lastDigit <= 4)
                {
                    return "рубля";
                }
                else
                {
                    return "рублей";
                }
            }
            else
            {
                if (amount.Length >= 2 && amount[^2] == '1')
                {
                    return "рублей";
                }
                else if (lastDigit == 1)
                {
                    return "рубль";
                }
                else if (lastDigit >= 2 && lastDigit <= 4)
                {
                    return "рубля";
                }
                else
                {
                    return "рублей";
                }
               // return "недопустимое значение";
            }
        }
    }

}