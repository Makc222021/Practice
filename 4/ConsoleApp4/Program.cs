using System;

public static class StringExtensions
{
    public static string ReplaceVowelsWithAsterisk(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        foreach (char vowel in vowels)
        {
            input = input.Replace(vowel, '*');
        }
        return input;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input = "Hello, World!";
        string result = input.ReplaceVowelsWithAsterisk();
        Console.WriteLine(result); // H*ll*, W*rld!  
    }
}