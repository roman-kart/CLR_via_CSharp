namespace Attributes;

public sealed class Program
{
    [ConsoleForeign(ConsoleColor.Red)]
    public delegate void WriteRed(string content);
    [ConsoleForeign(ConsoleColor.Green)]
    public delegate void WriteGreen(string content);
    public static void Main(string[] args)
    {
        WriteRed writeRed = (string content) =>
        {
            Console.WriteLine($"Alex: {content}");
        };
        WriteGreen writeGreen = new WriteGreen((string str) =>
        {
            Console.WriteLine($"Bob: {str}");
        });

        ColoriseWrite.Do<String, Object>(writeGreen, "Oh, I'm sorry!");
        ColoriseWrite.Do<String, Object>(writeRed, "Sorry for what?");
        ColoriseWrite.Do<String, Object>(writeRed, "Our dad told us not to be ashamed of our attributes.");
        ColoriseWrite.Do<String, Object>(writeRed, "Especially, they're so really useful.");
    }
}