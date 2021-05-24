using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ParamReloader.GameHook;

namespace ParamReloader
{
    class Program
    {
        static string GAME_PATH = null;
        
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (File.Exists("PARAMRELOADER.cfg"))
            {
                GAME_PATH = File.ReadAllText("PARAMRELOADER.cfg");
            }

            Console.WriteLine(@"

                          ~~~ DS1R PARAM RELOADER ~~~

                      Assembly by Metal-Crow (@shinymetal_crow)
                         PropertyHook by JKAnderson (@TKGP)
                         Executable by Grimrukh (@grimrukh)
");

            GAME_PATH = GetGameDir();
            if (GAME_PATH == null)
            {
                Console.WriteLine("No EXE selected. Exiting ParamReloader.");
                return;
            }

            DSRHook hook = new DSRHook(5000, 5000);
            hook.Start();

            Console.WriteLine("Waiting for game application to start...");
            while (!hook.Hooked)
                Thread.Sleep(100);

            Console.WriteLine("Hooked.");

            Console.WriteLine(@"
Usage:

    Navigate to your DS1R game executable on first use. That directory will
    be used whenever you run this file. To clear it, delete the 'PARAMRELOADER.cfg'
    file that will appear next to this executable.
    
    Type the name of the GameParam table you want to reload. Options:

        AtkParam_Npc             AtkParam_Pc           BehaviorParam
        BehaviorParam_PC         Bullet                CalcCorrectGraph
        CharaInitParam           CoolTimeParam         EquipMtrlSetParam
        EquipParamAccessory      EquipParamGoods       EquipParamProtector
        EquipParamWeapon         FaceGenParam          GameAreaParam
        HitMtrlParam             ItemLotParam          KnockBackParam
        LevelSyncParam           LockCamParam          Magic
        MenuColorTableParam      MoveParam             NpcParam
        NpcThinkParam            ObjActParam           ObjectParam
        QwcChange                QwcJudge              RagdollParam
        ReinforceParamProtector  ReinforceParamWeapon  ShopLineupParam
        SkeletonParam            SpEffectParam         SpEffectVfxParam
        TalkParam                WhiteCoolTimeParam

    Note that some tables, like CalcCorrectGraph and MenuColorTableParam, may
    not have the effects you expect simply be altering them. Others may require
    other forms of 'refreshing' to take effect, like reloading the map (ItemLotParam)
    or moving far enough away from enemies to reset them (NpcThinkParam).

    Once chosen, press ENTER to reload those params. The console will print out
    the timestamp of the reload so you can easily see when you last reloaded.

    Type 'exit' before pressing ENTER to return to this main menu and select a
    different table name.

    NOTE: This is for DARK SOULS REMASTERED ONLY. It will likely cause PTDE to crash.
");

            string selectedParam = "";
            while (true)
            {
                if (selectedParam == "")
                {
                    // Choose param name.
                    Console.WriteLine("ENTER PARAM NAME >>>");
                    string input = Console.ReadLine();
                    if (DSRAssembly.ParamEnums.ContainsKey(input))
                    {
                        selectedParam = input;
                        Console.WriteLine("Press ENTER to reload. Type 'exit' and press ENTER to exit.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid param name. See list above.");
                    }
                }
                else
                {
                    // Press ENTER to reload or type 'exit' to exit.
                    string input = Console.ReadLine();
                    if (input == "exit")
                    {
                        selectedParam = "";
                    }
                    else if (input == "")
                    {
                        // Typing anything else (or nothing) will trigger a reload.
                        if (!hook.Hooked)
                        {
                            Console.WriteLine("Game hook lost. Is it still running?");
                        }
                        else
                        {
                            hook.ReloadParam(selectedParam);
                            Console.WriteLine($"{selectedParam} reloaded at {DateTime.Now}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid command. Type 'exit' to change GameParam name, or nothing (just ENTER) to reload.");
                    }
                }
            }
          
        }

        static string GetGameDir()
        {
            if (GAME_PATH != null)
            {
                return GAME_PATH;
            }

            Console.WriteLine("\nPress ENTER to select your Dark Souls Remastered executable.");
            Console.ReadLine();
            OpenFileDialog ofd = new OpenFileDialog { Filter = "EXE Files|*.exe" };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GAME_PATH = Path.GetDirectoryName(ofd.FileName) + "\\";
                File.WriteAllText("PARAMRELOADER.cfg", GAME_PATH);
                return GAME_PATH;
            }
            else
            {
                return null;
            }
        }
    }
}
