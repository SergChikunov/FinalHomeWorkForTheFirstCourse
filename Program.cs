/*
Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. 
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:
[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
[“1234”, “1567”, “-2”, “computer science”] → [“-2”]
[“Russia”, “Denmark”, “Kazan”] → []
 */
string[] CreateStringsArray() //создаем пустой строковый массив
{
    Console.Write("Введите размер массива и нажмите Enter... ");
    string? inputVal = Console.ReadLine();
    CheckCorrectInput(inputVal!); // проверка на числовое значение
    int arrSize = int.Parse(inputVal!); //числовое значение, которое определяет размер массива
    string[] arr = new string[arrSize]; //создаем исходный массив, указанной с консоли размерности
    return arr;
}

void CheckCorrectInput(string input)
{
    if (int.TryParse(input, out int _) == false) //проверяем ввод на числовое значение, итог проверки присваиваем временной переменной, завершаем код, если введено не число
    {
        Console.WriteLine("Введено не числовое значение, программа завершает работу!");
        Environment.Exit(0);
    }
}

string[] FillStringArray(string[] array) //заполняем массив данными, запрашивая их ввод с консоли
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"Введите {i + 1} элемент массива - строковое значение, и нажмите Enter...");
        array[i] = Console.ReadLine();
    }
    return array;
}

void PrintArray(string[] array) // метод отображающий массив на экран
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1)
        {
            Console.Write($"{array[i]}, ");
        }
        else
        {
            Console.Write($"{array[i]}");
        }
    }
    Console.Write("]");
}

string[] NewStringArray(string[] array) //формирование результирующего массива из исходного
{
    int count = 0;
    foreach (string s in array) //определяем размер результирующего массива
    {
        if (s.Length < 4) count++;
    }
    string[] arr = new string[count]; //создаем массив соответствующего размера
    for (int i = 0, j = 0; i < array.Length; i++) // заполняем итоговый массив данными
    {
        string tempStr = array[i];
        if (tempStr.Length < 4) //проверяем соответствие текущего элемента исходного массива условию поставленному в задаче
        {
            arr[j] = tempStr; //если элемент соответствует условию, то заносим его в результирующий массив
            j++; //увеличиваем счетчик, для подготовки места под следующий элемент результирующего массива
        }
    }
    return arr;
}

string[] originalArray = CreateStringsArray();
originalArray = FillStringArray(originalArray);
Console.WriteLine("\nИсходный массив: ");
PrintArray(originalArray);
string[] resultArray = NewStringArray(originalArray);
Console.WriteLine("\n\nИтоговый массив: ");
PrintArray(resultArray);