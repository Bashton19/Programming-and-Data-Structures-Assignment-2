using System;
using System.Linq;
 
namespace CaesarShift
{
    class Program
    {
        static char Encrypt(char ch, int code)
        {
            if (!char.IsLetter(ch)) return ch;
 
            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((ch + code - offset) % 26 + offset);
        }
 
        static string Encrypt(string input, int code)
        {
            return new string(input.Select(ch => Encrypt(ch, code)).ToArray());
        }
 
        static string Decrypt(string input, int code)
        {
            return Encrypt(input, 26 - code);
        }
 
        const string a = "we attack at dawn";
		const string b = "fn jan anjmh oxa hxda xamnab";
 
        static void Main()
        {
 
            Console.WriteLine("x = 7");
			Console.WriteLine("Plain text: " + a);
            string c = Encrypt(a, 7);
            Console.WriteLine("Encoded text: " + c);
          
			Console.WriteLine();
			
			Console.WriteLine("x = 9");
			Console.WriteLine("Encoded text: " + b);
			string d = Decrypt(b, 9);
			Console.WriteLine("Plain text: " + d);
        }
    }
}