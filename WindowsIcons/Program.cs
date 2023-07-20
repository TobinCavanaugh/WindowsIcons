// See https://aka.ms/new-console-template for more information

using System.Drawing.Imaging;
using System.Text;
using WindowsIcons;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter your path to export images: (Default = NONE)");
        string imageExportPath = Console.ReadLine();

        if (imageExportPath == "" || imageExportPath == null || imageExportPath == " ")
        {
            Console.WriteLine("Not a valid path!");
            return;
        }

        if (!imageExportPath.EndsWith("\\"))
        {
            imageExportPath += @"\";
        }

        //Generate the icon files
        for (uint i = 0; i < 181; i++)
        {
            try
            {
                //Get the icon
                var icon = DefaultIcons.GetIcon((DefaultIconTypes) i);

                //Calculate the path
                string spath = imageExportPath + i.ToString("000") + ".png";

                //Save the image
                icon.ToBitmap().Save(spath, ImageFormat.Png);

                Console.WriteLine($"Wrote to {spath}");
            }
            catch (Exception ex)
            {
            }
        }

        Console.WriteLine("Generate MD File? Y/N (Default = \"Y\")");
        if (Console.ReadLine().ToLower().Contains("n"))
        {
            return;
        }

        //Open/Create the file
        var mdFile = File.CreateText(imageExportPath + "generated.md");

        //Clear it
        mdFile.Flush();

        string[] names = Enum.GetNames(typeof(DefaultIconTypes));

        List<(string, int)> values = new();
        for (int i = 0; i < names.Length; i++)
        {
            values.Add((names[i], i));
        }

        Console.WriteLine("Image MD File Path Prefix (Default = \"./\")");
        string prefix = "./";

        string readPrefix = Console.ReadLine();
        
        //If its an actual prefix
        if (!(readPrefix == "" || readPrefix == null || readPrefix == " "))
        {
            prefix = readPrefix;
        }
        
        
        
        
        //Do custom sorting here
        var sortedVals = values.OrderBy(x => x.Item1).ToList();
        

        for (int i = 0; i < names.Length; i++)
        {
            //Make a subheader with the name
            string current = ("## " + "⤹ " + sortedVals[i].Item1);

            //This seperation will break up abbreviation
            current = SeparateString(current);

            //Recombine the abbreviations manually (not ideal but whatever )
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

            //Add a newline
            current += "\n";

            //Paste in the image with a local path
            //TODO If you're messing with this, change the path here to have subfolders etc
            current += $"![{names[i]}]({prefix}{sortedVals[i].Item2.ToString("000")}.png)";

            //This puts the enum reference and enum value into code blocks for easy copy paste
            current += $"\t `DefaultIconTypes.{sortedVals[i].Item1}` | `{sortedVals[i].Item2.ToString("000")}`";

            //Add this whole dealio onto the md file
            mdFile.WriteLine(current);
        }

        //Add a lil tag on the end, feel free to remove this idc
        mdFile.WriteLine(
            "\nMarkdown file generated using <a href=\"https://github.com/TobinCavanaugh/WindowsIcons\"> Windows Icons </a>");

        //Close the file
        mdFile.Close();

        Console.WriteLine("Generated MD file successfully!");
    }

    /// <summary>
    /// Separates the string by caps, taking into account spaces
    /// </summary>
    /// <param name="current"></param>
    /// <returns></returns>
    private static string SeparateString(string current)
    {
        StringBuilder result = new StringBuilder();
        char[] characters = current.ToCharArray();

        //Go through the string
        for (int i = 0; i < characters.Length; i++)
        {
            //Requirements for split:
            // - Not the first character
            // - Is uppercase
            // - Previous character isnt space
            if (i > 0 && char.IsUpper(characters[i]) && !char.IsWhiteSpace(characters[i - 1]))
            {
                //Append the space 
                result.Append(' ');
            }

            //Then append the rest of the string
            result.Append(characters[i]);
        }

        return result.ToString();
    }
}