using System.Collections.Generic;

public static class GameSettings
{
    public static int BPM = 80;
    public static int dotIndex = 0;
    public static int selectedLevel = 1;
    public static string songTitle = "";
    public static List<string> wordsPerLevel = new List<string>(new string[] {"Watch", "Hand", "Dance", "Sing", "Chicken"});
}
