using System;
using System.Threading;
using DS1RParamReloader.GameHook;

namespace DS1RParamReloader;

/// <summary>
/// Old command-line version. Not used anymore, but kept for posterity.
/// </summary>
internal static class CommandLine
{
    [STAThread]
    static void Main_CommandLine()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.WriteLine(@"

                          ~~~ DS1R PARAM RELOADER ~~~

                      Assembly by Metal-Crow (@shinymetal_crow)
                         PropertyHook by JKAnderson (@TKGP)
                         Executable by Grimrukh (@Grimrukh)
");

        DSRHook hook = new(1000, 5000);
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
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && DSRAssembly.ParamEnums.ContainsKey(input))
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
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "exit":
                        selectedParam = "";
                        break;
                    // Typing anything else (or nothing) will trigger a reload.
                    case "" when !hook.Hooked:
                        Console.WriteLine("Game hook lost. Is it still running?");
                        break;
                    case "":
                        hook.ReloadParam(selectedParam);
                        Console.WriteLine($"{selectedParam} reloaded at {DateTime.Now}");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Type 'exit' to change GameParam name, or nothing (just ENTER) to reload.");
                        break;
                }
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }
}