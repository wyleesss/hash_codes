using System.Text;

class CompareRemakedChar
{
    private static string _specialSymbols = "oOоОaAаАiIіІeEеЕHНcCсСBВKКPРXxХхTТMМ";
    public string SpecialSymbols => _specialSymbols;

    public string UkrSpecialSymbols => "оОаАіІеЕНсСВКРхХТМ";
    public string EngSpecialSymbols => "oOaAiIeEHcCBKPxXTM";

    private char _character;
    public char Character
    {
        get => _character;
        set => _character = value;
    }

    public CompareRemakedChar() => _character = '\0';

    public CompareRemakedChar(char character) => _character = character;

    public static bool operator == (CompareRemakedChar ch1, CompareRemakedChar ch2)
    {
        if (_specialSymbols.Contains(ch1._character) && _specialSymbols.Contains(ch2._character))
        {
            return (Char.IsUpper(ch1._character) && Char.IsUpper(ch1._character))
                || (Char.IsLower(ch1._character) && Char.IsLower(ch2._character));
        }

        return ch1._character == ch2._character;
    }

    public static bool operator != (CompareRemakedChar ch1, CompareRemakedChar ch2) => !(ch1 == ch2); 

    public override bool Equals(Object? obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            return false;

        return ((CompareRemakedChar)obj)._character == _character;
    }

    public override int GetHashCode() => _character.GetHashCode();

    public override string ToString() => char.ToString(_character);
}

namespace Program
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            CompareRemakedChar First = new CompareRemakedChar();
            CompareRemakedChar Second = new CompareRemakedChar();

            do
            {
                Console.Clear();

                Console.WriteLine("input two chars one by one -> |1st|");
                Console.WriteLine("?  =  ?");
                First.Character = Console.ReadKey().KeyChar;

                Console.Clear();

                Console.WriteLine("input two chars one by one -> |2nd|");
                Console.WriteLine($"'{First}'  =  ?");
                Second.Character = Console.ReadKey().KeyChar;

                Console.Clear();

                Console.WriteLine("PRESS ANY KEY TO CONTINUE, 'ESC' - EXIT");
                Console.WriteLine($"'{First}'  =  '{Second}'");
                Console.WriteLine($"\nresult -> {First == Second}\n");

                Console.WriteLine($"ASCII codes:\n" +
                    $"{(int)First.Character}" +
                    $"  <{(First.Character == Second.Character ? '=' : "!=")}>  " +
                    $"{(int)Second.Character}");
            } 
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}