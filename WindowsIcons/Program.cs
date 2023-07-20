// See https://aka.ms/new-console-template for more information

using System.Drawing.Imaging;
using WindowsIcons;



string path = @"C:\Users\TobinC\Documents\Windows Icons\WindowsIcons\WindowsIcons\WindowsIcons\" + @"icons\";
for (uint i = 0; i < 256; i++)
{
    try
    {

    }
    catch (Exception ex)
    {
        var icon = DefaultIcons.GetStockIcon(i, DefaultIcons.SHGSI_LARGEICON);
        icon.ToBitmap().Save(path + i.ToString("000") + ".png", ImageFormat.Png);
    }
}