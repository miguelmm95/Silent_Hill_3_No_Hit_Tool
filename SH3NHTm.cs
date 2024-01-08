using Memory.Win64;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silent_Hill_3_NHT_minimalist
{
    public partial class SH3NHTm : Form
    {
        public SH3NHTm()
        {
            InitializeComponent();
        }

        ulong IGTAddr;
        ulong beefAddr;
        ulong HPAddr;
        ulong damageAddr;
        ulong savesAddr;
        ulong shootingAddr;
        ulong meleeAddr;
        ulong difficultyAddr;
        ulong puzzleAddr;
        ulong itemAddr;
        ulong handgunAddr;
        ulong shotgunAddr;
        ulong machinegunAddr;
        ulong wormtAddr;
        ulong missiotAddr;
        ulong leonardtAddr;
        ulong alessatAddr;
        ulong diositotAddr;
        MemoryHelper64 helper;

        private void SH3NHTm_Load(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName("sh3").FirstOrDefault();

            if (p == null) return;

            helper = new MemoryHelper64(p);

            IGTAddr = helper.GetBaseAddress(0x6CE66F4);
            beefAddr = helper.GetBaseAddress(0x6D2CAB8);
            HPAddr = helper.GetBaseAddress(0x498668);
            damageAddr = helper.GetBaseAddress(0x498650);
            savesAddr = helper.GetBaseAddress(0x6CE66E4);
            shootingAddr = helper.GetBaseAddress(0x6CE66EA);
            meleeAddr = helper.GetBaseAddress(0x6CE66EC);
            difficultyAddr = helper.GetBaseAddress(0x6CE66DE);
            puzzleAddr = helper.GetBaseAddress(0x6CE66DF);
            itemAddr = helper.GetBaseAddress(0x6CE66E8);
            handgunAddr = helper.GetBaseAddress(0x6D2CAA2);
            shotgunAddr = helper.GetBaseAddress(0x6D2CAA4);
            machinegunAddr = helper.GetBaseAddress(0x6D2CAA6);
            wormtAddr = helper.GetBaseAddress(0x6CE6704);
            missiotAddr = helper.GetBaseAddress(0x6CE6708);
            leonardtAddr = helper.GetBaseAddress(0x6CE670C);
            alessatAddr = helper.GetBaseAddress(0x6CE6710);
            diositotAddr = helper.GetBaseAddress(0x6CE6714);

            IGT.Text = helper.ReadMemory<float>(IGTAddr).ToString();
            FPS.Text = helper.ReadMemory<short>(beefAddr).ToString();
            HP.Text = helper.ReadMemory<float>(HPAddr).ToString();
            damagetaken.Text = helper.ReadMemory<float>(damageAddr).ToString();
            saves.Text = helper.ReadMemory<byte>(savesAddr).ToString();
            enemiesshooting.Text = helper.ReadMemory<short>(shootingAddr).ToString();
            enemiesmelee.Text = helper.ReadMemory<short>(meleeAddr).ToString();
            actionlevel.Text = helper.ReadMemory<byte>(difficultyAddr).ToString();
            riddlelevel.Text = helper.ReadMemory<byte>(puzzleAddr).ToString();
            items.Text = helper.ReadMemory<short>(itemAddr).ToString();
            handgun.Text = helper.ReadMemory<short>(handgunAddr).ToString();
            shotgun.Text = helper.ReadMemory<short>(shotgunAddr).ToString();
            machinegun.Text = helper.ReadMemory<short>(machinegunAddr).ToString();
            wormtime.Text = helper.ReadMemory<float>(wormtAddr).ToString();
            missiotime.Text = helper.ReadMemory<float>(missiotAddr).ToString();
            leonardtime.Text = helper.ReadMemory<float>(leonardtAddr).ToString();
            alessatime.Text = helper.ReadMemory<float>(alessatAddr).ToString();
            godtime.Text = helper.ReadMemory<float>(diositotAddr).ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float totalTime = helper.ReadMemory<float>(IGTAddr);
            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            IGT.Text = time.ToString("hh' : 'mm' : 'ss");

            
            FPS.Text = helper.ReadMemory<short>(beefAddr).ToString();
            HP.Text = helper.ReadMemory<float>(HPAddr).ToString("F0");
            damagetaken.Text = helper.ReadMemory<float>(damageAddr).ToString("F0");
            saves.Text = helper.ReadMemory<byte>(savesAddr).ToString();
            enemiesshooting.Text = helper.ReadMemory<short>(shootingAddr).ToString();
            enemiesmelee.Text = helper.ReadMemory<short>(meleeAddr).ToString();


            byte actionLevelValue = helper.ReadMemory<byte>(difficultyAddr);

            string actionLevelText;

            switch (actionLevelValue)
            {
                case 0:
                    actionLevelText = "Beginner";
                    break;
                case 1:
                    actionLevelText = "Easy";
                    break;
                case 2:
                    actionLevelText = "Normal";
                    break;
                case 3:
                    actionLevelText = "Hard";
                    break;
                default:
                    actionLevelText = "Unknown"; // Add a default case if needed
                    break;
            }
            actionlevel.Text = actionLevelText;


            byte riddleLevelValue = helper.ReadMemory<byte>(puzzleAddr);

            string riddleLevelText;

            switch (riddleLevelValue)
            {
                case 0:
                    riddleLevelText = "Easy";
                    break;
                case 1:
                    riddleLevelText = "Normal";
                    break;
                case 2:
                    riddleLevelText = "Hard";
                    break;
                default:
                    riddleLevelText = "Unknown"; // Add a default case if needed
                    break;
            }
            riddlelevel.Text = riddleLevelText;


            items.Text = helper.ReadMemory<short>(itemAddr).ToString();
            handgun.Text = helper.ReadMemory<short>(handgunAddr).ToString();
            shotgun.Text = helper.ReadMemory<short>(shotgunAddr).ToString();
            machinegun.Text = helper.ReadMemory<short>(machinegunAddr).ToString();


            TimeSpan timer;

            float wormTimer = helper.ReadMemory<float>(wormtAddr);
            timer = TimeSpan.FromSeconds(wormTimer);
            wormtime.Text = $"{(int)timer.TotalMinutes:D2}:{timer.Seconds:D2}";

            float missionaryTimer = helper.ReadMemory<float>(missiotAddr);
            timer = TimeSpan.FromSeconds(missionaryTimer);
            missiotime.Text = $"{(int)timer.TotalMinutes:D2}:{timer.Seconds:D2}";

            float leonardTimer = helper.ReadMemory<float>(leonardtAddr);
            timer = TimeSpan.FromSeconds(leonardTimer);
            leonardtime.Text = $"{(int)timer.TotalMinutes:D2}:{timer.Seconds:D2}";

            float alessaTimer = helper.ReadMemory<float>(alessatAddr);
            timer = TimeSpan.FromSeconds(alessaTimer);
            alessatime.Text = $"{(int)timer.TotalMinutes:D2}:{timer.Seconds:D2}";

            float diositoTimer = helper.ReadMemory<float>(diositotAddr);
            timer = TimeSpan.FromSeconds(diositoTimer);
            godtime.Text = $"{(int)timer.TotalMinutes:D2}:{timer.Seconds:D2}";

        }
    }
}
