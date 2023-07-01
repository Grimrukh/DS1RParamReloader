using System;
using System.Collections.Generic;
using System.Threading;
using PropertyHook;

namespace DS1RParamReloader.GameHook;

internal class DSRHook : PHook
{
    static Dictionary<int, string> VersionStrings { get; } = new()
    {
        [0x4869400] = "1.01",
        [0x496BE00] = "1.01.1",
        [0x37CB400] = "1.01.2",
        [0x3817800] = "1.03",
        // TODO: Add 1.03.1
    };

    public DSRHook(int refreshInterval, int minLifetime) :
        base(refreshInterval, minLifetime, p => p.MainWindowTitle == "DARK SOULS™: REMASTERED")
    {
        // No need to do anything here.
    }

    public string Version
    {
        get
        {
            if (!Hooked) return "N/A";
            int size = Process.MainModule.ModuleMemorySize;
            return VersionStrings.TryGetValue(size, out string version) ? version : $"0x{size:X8}";

        }
    }

    public bool Focused => Hooked && User32.GetForegroundProcessID() == Process.Id;

    public void ReloadParam(string paramName)
    {
        byte[] reloadAsm = DSRAssembly.GetParamReloadAssembly(paramName);
        IntPtr address = Allocate(4048, Kernel32.PAGE_EXECUTE_READWRITE);
        byte[] zerosOffset = BitConverter.GetBytes(address.ToInt64() + 0x10a);
        byte[] paramNameOffset = BitConverter.GetBytes(address.ToInt64() + 0x122);
        Array.Copy(zerosOffset, 0, reloadAsm, 0xd8, 8);
        Array.Copy(paramNameOffset, 0, reloadAsm, 0x13, 8);
        Kernel32.WriteBytes(Handle, address, reloadAsm);
        Execute(address);
        Thread.Sleep(50);  // need to briefly sleep, or freeing memory will crash the game
        Free(address);
    }
}