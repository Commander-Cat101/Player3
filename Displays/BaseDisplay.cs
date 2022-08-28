using System;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Player3Tower;
using playerthree;
using UnhollowerBaseLib;
using UnityEngine;
using Object = UnityEngine.Object;

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
