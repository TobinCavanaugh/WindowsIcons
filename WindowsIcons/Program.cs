// See https://aka.ms/new-console-template for more information

using System.Drawing.Imaging;
using System.Text;
using WindowsIcons;

class Program
{
    public static void Main(string[] args)
    {
        string path = @"C:\Users\TobinC\Documents\Windows Icons\WindowsIcons\";

        // if (args[0] != "")
        // {
        //     path = args[0];
        // }
        //
        // //Generate the icon files
        // for (uint i = 0; i < 181; i++)
        // {
        //     try
        //     {
        //         var icon = DefaultIcons.GetStockIcon(i, DefaultIcons.SHGSI_LARGEICON);
        //         icon.ToBitmap().Save(path + i.ToString("000") + ".png", ImageFormat.Png);
        //     }
        //     catch (Exception ex)
        //     {
        //     }
        // }

        var mdFile = File.CreateText(path + "readme.md");

        mdFile.Flush();

        string[] names = Enum.GetNames(typeof(DefaultIconTypes));
        Array values = Enum.GetValues(typeof(DefaultIconTypes));

        for (int i = 0; i < names.Length; i++)
        {
            string current = ("## " + "⤹ " + names[i]);

            current = SeparateString(current);

            current = current.Replace("D V D", "DVD");
            current = current.Replace("R A M", "RAM");
            current = current.Replace("R O M", "ROM");
            current = current.Replace("R W", "RW");
            current = current.Replace("Z I P", "ZIP");
            current = current.Replace("O K", "OK");
            current = current.Replace("H D", "HD");
            current = current.Replace("S V", "SV");
            current = current.Replace("C D", "CD");
            current = current.Replace("B D", "BD");
            current = current.Replace("M P 3", "MP3");
            current = current.Replace("M P3", "MP3");
            current = current.Replace("R E", "RE");

            current += "\n";
            
            current += $"![image info](./icons/{i.ToString("000")}.png)";


            current += $"\t `DefaultIconTypes.{names[i]}` | `{i.ToString("000")}`";
            
            mdFile.WriteLine(current);
        }

        mdFile.Close();
    }

    public static string SeparateString(string current)
    {
        List<string> ignoredAbbreviations = new List<string>
        {
            "DVD",
            "RAM",
            "ROM",
            "RW",
            "ZIP",
            "OK",
            "HD",
            "SV",
            "CD",
            "USB",
        };

        StringBuilder result = new StringBuilder();
        char[] characters = current.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            if (i > 0 && char.IsUpper(characters[i]) && !char.IsWhiteSpace(characters[i - 1]) &&
                !IsAbbreviation(current.Substring(i - 1, 2), ignoredAbbreviations))
            {
                result.Append(' ');
            }

            result.Append(characters[i]);
        }

        return result.ToString();
    }

    private static bool IsAbbreviation(string potentialAbbreviation, List<string> abbreviations)
    {
        return abbreviations.Contains(potentialAbbreviation);
    }
}