using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

internal class Program
{
    [DllImport("user32.dll")]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll")]
    public static extern bool EmptyClipboard();

    [DllImport("user32.dll")]
    public static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);

    [DllImport("user32.dll")]
    public static extern bool CloseClipboard();

    private static async Task Main(string[] args)
    {
        Console.WriteLine("0 Na_East  1 Na_West  2 Us_Central  3 Australia");
        Console.WriteLine("0 Solo Show  1 Duos Show  2 Squads Show  3 Lets Get Kraken  4 Slime Climb Time  5 X-Treme Squads Show");
        Console.WriteLine("0 Like And Subscribe For A Cookie  1 Like For A Cookie  2 Subscribe For A Cookie\n");

        string[] servers = { "Na-East", "Na-West", "Us-Central", "Australia" };
        string[] gamemodes = { "Solo Show", "Duos Show", "Squads Show", "Lets Get Kraken", "Slime Climb Time", "X-Treme Squads Show" };
        string[] promos = { "Like And Subscribe For A Cookie", "Like For A Cookie", "Subscribe For A Cookie" };

        Console.WriteLine("Please enter the server number:");
        int serverNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter the gamemode number:");
        int gamemodeNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter the promo number:");
        int promoNumber = Convert.ToInt32(Console.ReadLine());

        string result = string.Format("Server: ({0}) Gamemode: ({1}) {2}", servers[serverNumber], gamemodes[gamemodeNumber], promos[promoNumber]);
        Console.WriteLine(result);

        // Copy the result to the clipboard
        OpenClipboard(IntPtr.Zero);
        EmptyClipboard();
        IntPtr hGlobal = Marshal.StringToHGlobalUni(result);
        SetClipboardData(13, hGlobal);
        CloseClipboard();

        Console.WriteLine("\nThe result has been copied to the clipboard!!.");

        Console.ReadKey();
    }
}
