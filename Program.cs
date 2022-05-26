/* Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, 
которая покажет количество чётных чисел в массиве.


1. Создать массив случайных 3х значных цифр.
    1.1 Размер массива установлю на 10
    1.2 Случайные числа от 100 до 1000
2. Создать метод подсчёта чётных чисел.
3. Создать метод вывода массива.
4. Метод ввода длины массива и проверки на число >0
*/


int [] arrayCreation(int length)
{ //Метод создания массива
    Random rnd= new Random (); //подключаем рандом
    int[] array = new int[length]; //создаём массив размером length
    for (int i = 0; i< array.Length; i++) //создаём цикл прохода по всему массиву (не используем foreach так как массив пустой)
        array[i] = rnd.Next(100,1000); //присвоение случайного значения каждому элементу массива
return array; //возвращаем массив
}

int evenCountInArray(int[] array)
{ // метод подсчёта чётных значений
    int count = 0; //создаём переменную счётчик, которая и будет выводится
    foreach (int item in array)
    { //Пробегаем все элементы массива
        if (item % 2 == 0) //проверяем - если элемент массива при делении на 2 даёт остаток 0, значит элемент чётный
            count++; //увеличиваем счётчик
    }
return count; //выводим счётчик
}

string printArray(int[] array)
{ // метод печати массива
    System.Text.StringBuilder result = new System.Text.StringBuilder(); //можно вывести System.Text вверх программы и тогда использовать просто StringBuilder
    for (int i = 0; i < array.Length; i++)
    { 
        if ((i == 0) && (array.Length > 1) ) //Для того что бы первое значение было обрамлено в [
            result.Append("[").Append(array[i]).Append(", "); //.Append добавляет текст к изначальному пустому result
        else if ((i == 0) && (array.Length == 1) ) //Если длина массива 1
            result.Append("[").Append(array[i]).Append("]"); //однозначный массив
        else if ( i < array.Length -1 )
            result.Append(array[i]).Append(", "); //середина, просто с запятыми
        else 
            result.Append(array[i]).Append("]"); //Для того что бы последнее значение было обрамлено в [
    }
return result.ToString(); //.ToString() - чтобы StringBuilder перевёл итог в формат String
}

int numberInput(string TextToWriteBeforeInput)
{ //метод ввода и проверки если число
    bool examIfStrIsInt = true;
    int number = 0;
    do
    { //цикл проверки ввода, пока введённое значение не будет числом
        Console.Write($"{TextToWriteBeforeInput}");
        string numberStr = Console.ReadLine();
        if (int.TryParse(numberStr, out int numberInt))
        { //сама проверка 
            if (numberInt < 0)
                Console.WriteLine("Длина массива не может быть меньше 1, повторите попытку");
            else
            {
                number = numberInt;
                examIfStrIsInt = false;
            }
        }
        else Console.WriteLine("Ввели не число, повторите попытку");
    } while (examIfStrIsInt);
return number;    
}

Console.WriteLine("Задача 34:\n"+
"Задайте массив заполненный случайными положительными трёхзначными числами.\n"+
"Напишите программу, которая покажет количество чётных чисел в массиве.\n");

int arrayLength = numberInput("Введите длину массива : "); // Ввод длины массива

int[] array = arrayCreation(arrayLength); //создание массива в теле программы
Console.WriteLine($"\n{printArray(array)} - > {evenCountInArray(array)}"); // печать массива и результата поиска
Console.ReadLine();
