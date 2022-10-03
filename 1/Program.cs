// See https://aka.ms/new-console-template for more information 
using System.ComponentModel.DataAnnotations;
string str1 = Console.ReadLine();
string str2 = Console.ReadLine();
string str3 = "", str4 = "";

if (str1.Length >= str2.Length)
{
    str3 = str1.ToUpper();
    str4 = str2.ToUpper();
}
else
{
    str3 = str2.ToUpper();
    str4 = str1.ToUpper();
}

foreach (char i in str3)
{
    if (str4.IndexOf(i) == -1)
    {
        Console.WriteLine("Не является");
        Environment.Exit(0);
    }
    else
    {
        str3 = str3.Remove(str3.IndexOf(i), 1);
    }
}

if (str3 == "")
{
    Console.WriteLine("Является");
}