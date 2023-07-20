// See https://aka.ms/new-console-template for more information

using System.Drawing.Imaging;
using WindowsIcons;

class Program
{
    public static void Main(string[] args)
    {
        string path = @"C:\Users\TobinC\Documents\Windows Icons\WindowsIcons\WindowsIcons\WindowsIcons\icons\";

        if (args[0] != "")
        {
            path = args[0];
        }
        
        //Generate the icon files
        for (uint i = 0; i < 181; i++)
        {
            try
            {
                var icon = DefaultIcons.GetStockIcon(i, DefaultIcons.SHGSI_LARGEICON);
                icon.ToBitmap().Save(path + i.ToString("000") + ".png", ImageFormat.Png);
            }
            catch (Exception ex)
            {
            }
        }
        
        
        
    }
}