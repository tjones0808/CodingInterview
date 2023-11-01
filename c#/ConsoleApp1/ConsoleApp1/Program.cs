using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // String reversal examples
        Console.WriteLine("String reversal examples:");
        Console.WriteLine(Reverse("abc")); // Output: cba
        Console.WriteLine(Reverse2("abc")); // Output: cba
        Console.WriteLine(Reverse3("abc")); // Output: cba

        // Longest word examples
        Console.WriteLine("Longest Word Examples");
        Console.WriteLine(LongestWord("hello world master")); // Output: master
        Console.WriteLine(LongestWord2("hello world master exponetial")); // Output: exponetial

        // Palindrome check examples
        Console.WriteLine("Palindrome check examples");
        Console.WriteLine(IsPalindrome("abba")); // Output: True
        Console.WriteLine(IsPalindrome2("racecar")); // Output: True

        // Remove duplicates from array examples
        var array = new[] { 1, 2, 3, 1, 2, 3, 4 };
        Console.WriteLine("Remove duplicates from array examples");
        Console.WriteLine(string.Join(", ", RemoveDuplicates(array))); // Output: 1, 2, 3, 4
        Console.WriteLine(string.Join(", ", RemoveDuplicates2(array))); // Output: 1, 2, 3, 4
        Console.WriteLine(string.Join(", ", RemoveDuplicates3(array))); // Output: 1, 2, 3, 4
        Console.WriteLine(string.Join(", ", RemoveDuplicates4(array))); // Output: 1, 2, 3, 4

        // Anagram check examples
        Console.WriteLine("Anagram check examples");
        Console.WriteLine(IsAnagram("listen", "silent")); // Output: True
        Console.WriteLine(IsAnagram2("abc", "cba")); // Output: True

        // Vowel count examples
        Console.WriteLine("Vowel count examples");
        Console.WriteLine("Checking word: hello");
        Console.WriteLine(CountVowels("hello")); // Output: 2
        Console.WriteLine(CountVowels2("hello")); // Output: 2

        // Max number in array examples
        var numbers = new[] { 1, 2, 3, 4, 5 };
        Console.WriteLine("Max number in array examples");
        Console.WriteLine(Max(numbers)); // Output: 5
        Console.WriteLine(Max2(numbers)); // Output: 5

        // Prime number check examples
        Console.WriteLine("Prime number check examples");
        Console.WriteLine(IsPrime(7)); // Output: True
        Console.WriteLine(IsPrime2(10)); // Output: False

        // Factorial calculation examples
        Console.WriteLine("Factorial calculation examples");
        Console.WriteLine(Factorial(5)); // Output: 120
        Console.WriteLine(Factorial2(5)); // Output: 120

        // Remove whitespace examples
        Console.WriteLine("Remove whitespace examples");
        Console.WriteLine(RemoveWhitespace("hello world")); // Output: helloworld
        Console.WriteLine(RemoveWhitespace2("hello world")); // Output: helloworld
        Console.WriteLine(RemoveWhitespace3("hello world")); // Output: helloworld

        // Decorator pattern example
        var stringProcessor = new StringProcessor();
        Console.WriteLine("Decorator pattern example");
        Console.WriteLine(stringProcessor.GetString("hello")); // Output: olleh
    }

    // String reversal functions
    // write a function that returns the reverse of a string
    // reverse('abc') === 'cba'
    // reverse('hello') === 'olleh'
    static string Reverse(string str) => new string(str.Reverse().ToArray());

    static string Reverse2(string str)
    {
        var reversed = string.Empty;
        foreach (var ch in str)
            reversed = ch + reversed;
        return reversed;
    }
    static string Reverse3(string str) => new string(str.Aggregate(string.Empty, (reversed, ch) => ch + reversed).ToArray());

    // Longest word functions
    // write a function that returns the longest word in the sentence
    static string LongestWord(string str) => str.Split(' ').OrderByDescending(s => s.Length).First();
    static string LongestWord2(string str) {
        var words = str.Split(' ');
        var longest = string.Empty;
        foreach (var word in words) { 
            if(word.Length > longest.Length) longest = word;
        }

        return longest;
    }
    // Palindrome check functions
    // write a function that checks whether a given string is a palindrome or not (reads the same forward and backward)
    static bool IsPalindrome(string str) => str == new string(str.Reverse().ToArray());
    static bool IsPalindrome2(string str)
    {
        for (int i = 0; i < str.Length / 2; i++)
            if (str[i] != str[str.Length - i - 1])
                return false;
        return true;
    }

    // Remove duplicates from array functions
    // write a function to remove duplicate elements from an array and explain solution and time complexity

    // Solution #1
    // Explanation: This function uses the filter() method to create a new array. For each element in the array, it checks if the current index is the first occurrence of the item using indexOf(). If it is, the item is included in the result.

    // Time Complexity: O(n^2) For each element in the array, the indexOf() method scans the array, resulting in quadratic time complexity.
    static int[] RemoveDuplicates(int[] arr) => arr.Distinct().ToArray();
    static int[] RemoveDuplicates2(int[] arr) => arr.GroupBy(x => x).Select(x => x.First()).ToArray();
    static int[] RemoveDuplicates3(int[] arr)
    {
        var result = new List<int>();
        var map = new HashSet<int>();
        foreach (var item in arr)
        {
            if (!map.Contains(item))
            {
                result.Add(item);
                map.Add(item);
            }
        }
        return result.ToArray();
    }
    static int[] RemoveDuplicates4(int[] arr) => new HashSet<int>(arr).ToArray();

    // Anagram check functions
    // write a function that checks whether two strings are anagrams or not (contain the same characters)
    static bool IsAnagram(string str1, string str2) => new string(str1.OrderBy(c => c).ToArray()) == new string(str2.OrderBy(c => c).ToArray());
    static bool IsAnagram2(string str1, string str2)
    {
        var map1 = BuildCharMap(str1);
        var map2 = BuildCharMap(str2);
        if (map1.Count != map2.Count) return false;
        foreach (var kvp in map1)
            if (!map2.ContainsKey(kvp.Key) || map2[kvp.Key] != kvp.Value)
                return false;
        return true;
    }
    static Dictionary<char, int> BuildCharMap(string str)
    {
        var map = new Dictionary<char, int>();
        foreach (var ch in str)
        {
            if (map.ContainsKey(ch)) map[ch]++;
            else map[ch] = 1;
        }
        return map;
    }

    // Vowel count functions
    // write a function that returns the number of vowels in a string
    static int CountVowels(string str) => str.Count(c => "aeiouAEIOU".Contains(c));
    static int CountVowels2(string str) 
    {
        var count = 0;
        // create new vowels array with vowels in it
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
        
        // loop through each character in the string
        foreach (var ch in str)
        {
            // if the vowels array contains the character, increment the count
            if (vowels.Contains(ch)) count++;
        }
        return count;
    }

    // Max number in array functions
    static int Max(int[] arr) => arr.Max();
    static int Max2(int[] arr)
    {
        var max = arr[0];
        foreach (var num in arr)
            if (num > max)
                max = num;
        return max;
    }

    // Prime number check functions
    static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i < num; i++)
            if (num % i == 0)
                return false;
        return true;
    }
    static bool IsPrime2(int num)
    {
        if (num <= 1) return false;
        var sqrt = (int)Math.Sqrt(num);
        for (int i = 2; i <= sqrt; i++)
            if (num % i == 0)
                return false;
        return true;
    }

    // Factorial calculation functions
    static int Factorial(int num)
    {
        var result = 1;
        for (int i = 2; i <= num; i++)
            result *= i;
        return result;
    }
    static int Factorial2(int num) => num <= 1 ? 1 : num * Factorial2(num - 1);

    // Remove whitespace functions
    static string RemoveWhitespace(string str) => str.Replace(" ", string.Empty);
    static string RemoveWhitespace2(string str) => new string(str.Where(c => !char.IsWhiteSpace(c)).ToArray());
    static string RemoveWhitespace3(string str) => string.Concat(str.Split());

    // Decorator pattern implementation
    class StringProcessor
    {
        [ReverseDecorator]
        public virtual string GetString(string str) => str;
    }

    [AttributeUsage(AttributeTargets.Method)]
    class ReverseDecoratorAttribute : Attribute
    {
        public static string Apply(string str) => new string(str.Reverse().ToArray());
    }
}
