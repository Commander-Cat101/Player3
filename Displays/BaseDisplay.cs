using System;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Player3Tower;
using playerthree;
using UnityEngine;
using Object = UnityEngine.Object;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using MelonLoader;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTraveler.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace Player3.Displays;

public abstract class Player3Display : ModTowerDisplay<player3>
{
    public override float Scale => 1.05f;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        node.RemoveBone("MonkeyRig:Propjectile_R");
    }

    public override void ModifyDisplayNodeAsync(UnityDisplayNode node, Action onComplete)
    {
        UseNode(GetDisplay(TowerType.BananaFarmer), bananaFarmer =>
        {
            var pitchfork = bananaFarmer.GetRenderers<SkinnedMeshRenderer>()[1].gameObject;

            var newPitchFork = Object.Instantiate(pitchfork, node.transform.GetChild(0));
            var pitchforkRenderer = newPitchFork.GetComponent<SkinnedMeshRenderer>();
            pitchforkRenderer.rootBone = node.GetBone("MonkeyRig:MonkeyJnt_Spine02");
            var boneNames = new[]
            {
                "MonkeyRig:MonkeyJnt_Hand_R", "MonkeyRig:MonkeyJnt_Hand_R",
                "MonkeyRig:MonkeyJnt_Hand_R", "MonkeyRig:MonkeyJnt_Hand_R",
                "MonkeyRig:MonkeyJnt_Hand_R"
            };
            pitchforkRenderer.bones = boneNames.Select(node.GetBone).ToIl2CppReferenceArray();
            node.genericRenderers = node.genericRenderers.AddTo(pitchforkRenderer);

            PostAddPitchfork(node, pitchfork);

            node.RecalculateGenericRenderers();

            onComplete();
        });

    }


    protected virtual void PostAddPitchfork(UnityDisplayNode node, GameObject pitchfork)
    {
        node.genericRendererLayers = new Il2CppStructArray<int>(4);
    }
}
