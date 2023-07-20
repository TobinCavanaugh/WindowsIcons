using System.Drawing;
using System.Runtime.InteropServices;

namespace WindowsIcons
{
    /// <summary>
    /// \brief From StackOverflow
    /// @ https://stackoverflow.com/questions/42910628/is-there-a-way-to-get-the-windows-default-folder-icon-using-c
    /// Herohtar answered Dec 1, 2019 at 20:45
    /// lincolnk edited Apr 21, 2020 at 5:34
    /// </summary>
    class DefaultIcons
    {
        public static Icon GetIcon(DefaultIconTypes type)
        {
            var info = new SHSTOCKICONINFO();
            info.cbSize = (uint) Marshal.SizeOf(info);

            SHGetStockIconInfo((uint) type, SHGSI_ICON | SHGSI_LARGEICON, ref info);

            var icon = (Icon) Icon.FromHandle(info.hIcon).Clone(); // Get a copy that doesn't use the original handle
            DestroyIcon(info.hIcon); // Clean up native icon to prevent resource leak

            return icon;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public int iSysIconIndex;
            public int iIcon;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }

        [DllImport("shell32.dll")]
        public static extern int SHGetStockIconInfo(uint siid, uint uFlags, ref SHSTOCKICONINFO psii);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr handle);

        private const uint SHGSI_ICON = 0x100;
        public const uint SHGSI_LARGEICON = 0x0;
        public const uint SHGSI_SMALLICON = 0x1;
    }

    public enum DefaultIconTypes
    {
        NewPage = 000,
        RichTextDocument = 001,
        Executable = 002,
        FolderOpen = 003,
        FolderOpen1 = 004,
        DriveFloppy = 005,
        DriveFloppySave = 006,
        Drive = 007,
        Drive1 = 008,
        DriveBattery = 009,
        DriveError = 010,
        DriveCDROM = 011,
        Chip = 012,
        DualMonitorBattery = 013,
        EarthAndMouseWeb = 014,
        MonitorAndKeyboard = 015,
        Printer = 016,
        MonitorAndEarthWeb = 017,
        ThreeMonitorNetwork = 018,
        GridFolder = 019,
        FileClock = 020,
        ControlPanel = 021,
        MagnifyingGlassSearch = 022,
        HelpInfo = 023,
        Run = 024,
        MonitorOld = 025,
        USBEject = 026,
        ButtonWarning = 027,
        PeopleOverlay = 028,
        ShortcutOverlay = 029,
        X = 030,
        RecycleEmpty = 031,
        RecycleFull = 032,
        DialUpNetworkFolder = 033,
        Desktop = 034,
        ControlPanelNew = 035,
        GridFolder1 = 036,
        PrinterFolder = 037,
        FontFolder = 038,
        Taskbar = 039,
        CDROMMusic = 040,
        Tree = 041,
        MonitorAndFolder = 042,
        StarGold = 043,
        ButtonKey = 044,
        UploadFolder = 045,
        ScreenReImage = 046,
        Lock = 047,
        MonitorAndWebpage = 048,
        SearchDirectoryMedia = 049,
        PrinterBattery = 050,
        BatteryFolder = 051,
        PrinterNew = 052,
        PrinterBatteryNew = 053,
        PrinterSaveFloppy = 054,
        DirectoryMedia = 055,
        SVCDVideo = 056,
        FolderFull = 057,
        DriveQuestionMark = 058,
        DriveDVD = 059,
        DVD = 060,
        DVDRAM = 061,
        DVDRW = 062,
        DVDR = 063,
        DVDROM = 064,
        DVDAddMusic = 065,
        CDRW = 066,
        CDR = 067,
        CDBurn = 068,
        Disc = 069,
        CDROM = 070,
        FileNewMusic = 071,
        FileNewPicture = 072,
        FileNewVideo = 073,
        FileNewAudioVideo = 074,
        FolderFlat = 075,
        FolderFlatOpen = 076,
        DefenderShield = 077,
        WarningYellowTriangle = 078,
        BlueInfoI = 079,
        RedErrorX = 080,
        GoldenKey = 081,
        DriveStorage = 082, // NOT SURE
        Rename = 083,
        RedX = 084,
        DVDVideo = 085,
        DVDVideo1 = 086,
        DiscAudio = 087,
        DVDVideo2 = 088,
        HDDVDVideo = 089,
        BDVideo = 090,
        VCDVideo = 091,
        DVDPlusR = 092,
        DVDPlusRW = 093,
        MonitorAndKeyboard1 = 094,
        Black = 095,
        People = 096,
        MP3Player = 097, //Not sure
        DiscBox = 098, //Not Sure
        Phone = 099,
        Camera = 100,
        Camcorder = 101,
        MP3PlayerAndEarbuds = 102,
        DualMonitorTransfer = 103,
        DualMonitorWebEarth = 104,
        FolderZIP = 105,
        Black1 = 106,
        DriveWindows = 107,
        DriveStorage1 = 108, //Not sure
        FileMusic = 109,
        FolderPictures = 110,
        FolderPictures1 = 111,
        FolderSearch = 112,
        PrinterAdd = 113,
        FolderTree = 114,
        Black2 = 115,
        ProjectorScreen = 116,
        PrinterBatteryOK = 117,
        PrinterSaveOK = 118,
        PrinterNewBatteryOk = 119,
        PrinterNewOk = 120,
        PrinterNewOkAlt = 121,
        FileTextPageLined = 122,
        LetterMail = 123,
        FilePicture = 124,
        FileSheetMusic = 125,
        FileVideo = 126,
        PeopleHD = 127,
        ShieldQuestionMark = 128,
        ShieldRedXError = 129,
        ShieldGreenCheckOK = 130,
        ShieldYellowExclamationWarning = 131,
        DriveHDDVD = 132,
        DriveBD = 133,
        HDDVDROM = 134,
        HDDVDR = 135,
        HDDVDRAM = 136,
        BDROM = 137,
        BDR = 138,
        BDRE = 139,
        DriveServer = 140,
        DriveServer1 = 141,
        DriveServer3 = 142,
        DriveServer4 = 143,
        DriveServer5 = 144,
        DriveServer6 = 145,
        DriveServer7 = 146,
        DriveServer8 = 147,
        DriveServer9 = 148,
        DriveServer10 = 149,
        DriveServer11 = 150,
        DriveServer12 = 151,
        DriveServer13 = 152,
        DriveServer14 = 153,
        DriveServer15 = 154,
        DriveServer16 = 155,
        DriveServer17 = 156,
        DriveServer18 = 157,
        DriveServer19 = 158,
        DriveServer20 = 159,
        Blank = 160,
        Blank1 = 161,
        Blank2 = 162,
        MusicBox = 163,
        DriveUnlocked = 164,
        DriveLockedGold = 165,
        DriveUnlockedWarning = 166,
        DriveUnlockedWindows = 167,
        DriveUnlockedWindowsWarning = 168,
        DriveUnlockedAlt = 169,
        DriveLockedGoldAlt = 170,
        DriveUnlockedWarningAlt = 171,
        MediaFolderNewFile = 172,
        GreenCheckCircleOK = 173,
        ButtonBlackPlay = 174,
        FolderFlat1 = 175,
        FolderOpen2 = 176,
        FolderFull1 = 177,
        GoldLock = 178,
        BlueArrowsTogether = 179,
        BrownBriefcase = 180,
    }
}