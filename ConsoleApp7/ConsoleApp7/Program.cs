using System;
using System.Text.RegularExpressions;

namespace SzyfrCezara2503
{
	class Program
	{
		static void Main(string[] args)
		{
			var rx = new Regex("^[a-z]*$");
			//Zmienna
			Console.WriteLine("Podaj wiadomosc do zaszyfrowania: ");

			string text;

			while (true)
			{
				text = Console.ReadLine();

				if (String.IsNullOrWhiteSpace(text))
				{
					Console.WriteLine("Podaj wiadomosc do zaszyfrowania");
				}

				else if (!rx.IsMatch(text))
				{
					Console.WriteLine("Nie mozesz uzyc innych znakow niz liter alfabetu");
				}

				else
				{
					break;
				}
			}
			Console.WriteLine("O ile chcesz przesunac litery?: ");
			int shift;
			while (!int.TryParse(Console.ReadLine(), out shift))
			{
				Console.WriteLine("Liczba:");
			}
			Console.WriteLine($"Tekst po zaszyfrowaniu: {Regex.Replace(SzyfrCezara(text, shift), @"\s+", " ")}");
		}
		static string SzyfrCezara(string text, int shift)
		{
			char[] c = text.ToLower().ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				if (!char.IsWhiteSpace(c[i]))
				{
					c[i] = (char)(c[i] + shift);
				}

				if (c[i] > 'z' && !char.IsWhiteSpace(c[i]))
				{
					c[i] = (char)(c[i] - 26);
				}

				else if (c[i] < 'a' && !char.IsWhiteSpace(c[i]))
				{
					c[i] = (char)(c[i] + 26);
				}
			}
			return new string(c);
		}


		static void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}