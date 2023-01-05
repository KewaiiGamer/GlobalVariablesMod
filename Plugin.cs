using System;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using MoonSharp.Interpreter;

namespace GlobalVariablesMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            Harmony.CreateAndPatchAll(typeof(ScriptEditor_Patch));
        }
    }
    public class ScriptEditor_Patch
    {
        private static List<int> globalInts = new();
        private static List<string> globalStrings = new();
        private static List<bool> globalBooleans = new();
        private static List<double> globalDoubles = new();
        
        [HarmonyPatch(typeof(MatchActions), "InitalizeMatchActions")] // Specify target method with HarmonyPatch attribute
        [HarmonyPostfix]
        public static void InitalizeMatchActions()
        {
            MatchActions.actionScript.Globals[(object) "globalInts"] = globalInts;
            MatchActions.actionScript.Globals[(object) "globalStrings"] = globalStrings;
            MatchActions.actionScript.Globals[(object) "globalBooleans"] = globalBooleans;
            MatchActions.actionScript.Globals[(object) "globalDoubles"] = globalDoubles;
        }
    }
}
