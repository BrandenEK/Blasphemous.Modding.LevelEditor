using System;

namespace Blasphemous.Modding.LevelEditor;

public static class Logger
{
    private static void Log(object message, ConsoleColor color)
    {
        string text = $"[{DateTime.Now:HH:mm:ss}] {message}";

        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static void Info(object message) => Log(message, ConsoleColor.White);

    public static void Warning(object message) => Log(message, ConsoleColor.Yellow);

    public static void Error(object message) => Log(message, ConsoleColor.Red);
}
