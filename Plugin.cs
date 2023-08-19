using System;
using System.Collections.Generic;
using Attachments;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using Il2CppSystem.Collections.Generic;
using PlayerLoadout.Items;
using UnityEngine;
using UserInterface.InGameBehaviours;
using UserInterface.InGameBehaviours.DeployScreenSub.LoadoutSub;

namespace NoBobbing;

[BepInPlugin("link.ryhn.battlemod.nobobbing", "No Bobbing", "1.0.0.0")]
public class Plugin : BasePlugin
{
	public static Plugin Instance;

	public override void Load()
	{
		Instance = this;
		var h = new Harmony(MyPluginInfo.PLUGIN_GUID);
		h.PatchAll();
	}
}

[HarmonyPatch(typeof(MonoBehaviourPublicObRaInAnSiAnVeSiBoInUnique))]
[HarmonyPatch("Awake")]
public class BobbingDisable
{
	[HarmonyPostfix]
	public static void Postfix(MonoBehaviourPublicObRaInAnSiAnVeSiBoInUnique __instance)
	{
		__instance.gameObject.active = false;
	}
}