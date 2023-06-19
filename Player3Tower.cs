using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Net.NetworkInformation;
using MelonLoader;
using weapondisplays;
using Player3.Displays;
using playerthree;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Action = System.Action;
using bananafarmfake;
using Il2CppSystem.Runtime.ConstrainedExecution;
using RandomTowers;
using Il2CppSystem;
using Il2CppSystem.Diagnostics.Tracing;
using Il2CppSystem.ComponentModel;
using UnityEngine.Assertions.Comparers;
using Bomb;
using TemplateMod.MinionMonkey.Displays.Projectiles;
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
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Player3Tower
{
    public class Player3Tower : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            ModHelper.Msg<Player3Tower>("Player3Tower loaded!");
        }
    }
}
namespace player3displays
{
    public abstract class Player3T1Display : ModTowerDisplay<player3>
    {
        public override float Scale => .9f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.RemoveBone("DartMonkeyDart");
        }

        public override void ModifyDisplayNodeAsync(UnityDisplayNode node, Action onComplete)
        {
            UseNode(GetDisplay(TowerType.BananaFarmer), bananaFarmer =>
            {
                var pitchfork = bananaFarmer.GetRenderers<SkinnedMeshRenderer>()[1].gameObject;

                var newPitchFork = Object.Instantiate(pitchfork, node.transform.GetChild(0));
                var pitchforkRenderer = newPitchFork.GetComponent<SkinnedMeshRenderer>();
                pitchforkRenderer.rootBone = node.GetBone("NewMonkeyRigDart:MonkeyJnt_Spine02");
                var boneNames = new[]
                {
                "NewMonkeyRigDart:MonkeyJnt_Hand_R", "NewMonkeyRigDart:MonkeyJnt_Hand_R",
                "NewMonkeyRigDart:MonkeyJnt_Hand_R", "NewMonkeyRigDart:MonkeyJnt_Hand_R",
                "NewMonkeyRigDart:MonkeyJnt_Hand_R"
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
    public abstract class Player3500ForkDisplay : ModTowerDisplay<player3>
    {
        public override float Scale => .9f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.RemoveBone("AlchemistRig:Propjectile_R");
        }

        public override void ModifyDisplayNodeAsync(UnityDisplayNode node, Action onComplete)
        {
            UseNode(GetDisplay(TowerType.BananaFarmer), bananaFarmer =>
            {
                var pitchfork = bananaFarmer.GetRenderers<SkinnedMeshRenderer>()[1].gameObject;

                var newPitchFork = Object.Instantiate(pitchfork, node.transform.GetChild(0));
                var pitchforkRenderer = newPitchFork.GetComponent<SkinnedMeshRenderer>();
                pitchforkRenderer.rootBone = node.GetBone("AlchemistRig:MonkeyJnt_Spine02");
                var boneNames = new[]
                {
                "AlchemistRig:MonkeyJnt_Hand_R", "AlchemistRig:MonkeyJnt_Hand_R",
                "AlchemistRig:MonkeyJnt_Hand_R", "AlchemistRig:MonkeyJnt_Hand_R",
                "AlchemistRig:MonkeyJnt_Hand_R"
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
    public class Player3BaseDisplay : Player3T1Display
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Max() < 5 && tiers[2] < 3;
        }
    }
    public class Player3500Display : Player3500ForkDisplay
    {
        public override string BaseDisplay => GetDisplay(TowerType.Alchemist, 0, 0, 5);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[0] == 5;
        }
    }
    public class Player050Display : ModTowerDisplay<player3>
    {
        // Copy the Boomerang Monkey display
        public override string BaseDisplay => GetDisplay(TowerType.Druid, 0, 4, 0);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[1] == 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }
    public class Player003Display : ModTowerDisplay<player3>
    {
        // Copy the Boomerang Monkey display
        public override string BaseDisplay => GetDisplay(TowerType.Quincy);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[2] == 3;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }
    public class Player004Display : ModTowerDisplay<player3>
    {
        // Copy the Boomerang Monkey display
        public override string BaseDisplay => GetDisplay(TowerType.Quincy);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[2] == 4;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }
    public class Player005Display : ModTowerDisplay<player3>
    {
        // Copy the Boomerang Monkey display
        public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 0, 5, 0);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[2] == 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }
}
namespace weapondisplays
{
    public class BananaDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "BananaDisplay");
        }
    }
}
namespace playerthree
{
    public class player3 : ModTower
    {

        public override TowerSet TowerSet => TowerSet.Magic;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 850;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Player 3 joined the game";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 75;
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            attackModel.range = 75;
            attackModel.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;
        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.NinjaMonkey).towerIndex + 1;
        }
    }
}
namespace playerthreeupgrades
{
    public class Farmer : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 1100;
        public override string Description => "Now places farms at a slow speed";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var farm = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            farm.range = towerModel.range;
            farm.name = "Farm_Weapon";
            farm.weapons[0].Rate = 15f;
            farm.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            farm.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<BananaFarmer000Farm>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(farm);
            var projectile = attackModel.weapons[0].projectile;

            
        }
    }
    public class FasterTilling : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 600;
        public override string Description => "Farms are placed slightly faster";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            attackModel.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Farm"))
                {
                    attacks.weapons[0].Rate -= 1.5f;
                }

            }
        }
    }
    public class BetterRevenue : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 2300;
        public override string Description => "Farms are improved and make more money per round";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Farm"))
                {
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<BananaFarmer120Farm>().Duplicate();
                }

            }
        }
    }
    public class BananaForests : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 12300;
        public override string Description => "Replaces the farms with banana forests that last for longer";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Farm"))
                {
                    attacks.weapons[0].Rate -= 1f;
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<BananaFarmer320Farm>().Duplicate();
                }

            }
        }
    }
    public class BananaFactory : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 126000;
        public override string Description => "Farms become mega factorys that make LOTS of money";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Farm"))
                {
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<BananaFarmer500Farm>().Duplicate();
                }

            }
        }
    }
    public class SpikyBananas : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 100;
        public override string Description => "Spiky bananas deal extra damage";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.GetDamageModel().damage += 1;
        }
    }
    public class HeatTippedBananas : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 500;
        public override string Description => "Now damages moab class bloons and deals x2 damage to ceramic bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.GetDamageModel().damage += 1;
            projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectile.AddBehavior(new DamageModifierForBloonTypeModel("CeramicDamage", "ceramic", 2f, 0f, true));
        }
    }
    public class BoxOTowers : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1800;
        public override string Description => "Throws a random assortment of towers";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var towerninja = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towerninja.range = towerModel.range;
            towerninja.name = "Ninja_Tower";
            towerninja.weapons[0].Rate = 15f;
            towerninja.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towerninja.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            towerninja.weapons[0].projectile.AddBehavior(new CreateTowerModel("Ninja320place", GetTowerModel<Ninja320>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towerninja);
            var towersniper = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towersniper.range = towerModel.range;
            towersniper.name = "Sniper_Tower";
            towersniper.weapons[0].Rate = 4.5f;
            towersniper.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towersniper.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            towersniper.weapons[0].projectile.AddBehavior(new CreateTowerModel("Sniperplace", GetTowerModel<Sniper000>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towersniper);
            var towerquincy = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towerquincy.range = towerModel.range;
            towerquincy.name = "Quincy_Tower";
            towerquincy.weapons[0].Rate = 12f;
            towerquincy.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towerquincy.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            towerquincy.weapons[0].projectile.AddBehavior(new CreateTowerModel("Quincyplace", GetTowerModel<Quincy>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towerquincy);

        }
    }
    public class BiggerBox : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 2000;
        public override string Description => "Throws towers faster and gains a new selection";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Tower"))
                {
                    attacks.weapons[0].Rate *= .8f;
                    
                }

            }
            var towerpat = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towerpat.range = towerModel.range;
            towerpat.name = "Pat_Tower";
            towerpat.weapons[0].Rate = 12f;
            towerpat.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towerpat.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
            towerpat.weapons[0].projectile.AddBehavior(new CreateTowerModel("Patplace", GetTowerModel<PatFusty>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towerpat);
        }
    }
    public class GoldenEmperor : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 58900;
        public override string Description => "The Emperors army is much improved";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Tower"))
                {
                    attacks.weapons[0].Rate *= .8f;

                }
                if (attacks.name.Contains("Quincy"))
                {
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<Quincy14>().Duplicate();

                }
                if (attacks.name.Contains("Pat"))
                {
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<PatFusty14>().Duplicate();

                }
                if (attacks.name.Contains("Sniper"))
                {
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<Sniper005>().Duplicate();

                }
                if (attacks.name.Contains("Ninja"))
                {
                    attacks.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = GetTowerModel<Ninja520>().Duplicate();

                }
            }
        }
    }
    public class QuickHands : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 200;
        public override string Description => "Quick Hands allow faster throwing";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0].Rate -= .2f;
        }
    }
    public class HeavyBananas : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 300;
        public override string Description => "Heavy bananas pierce through more bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0].projectile.pierce += 1;
        }
    }

    public class QuadSuit : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => BOTTOM;
        public override string DisplayName => "Q.U.A.D Suit";
        public override int Tier => 3;
        public override int Cost => 800;
        public override string Description => "Gains Quincy Undercover Automated Defence suit that helps fight the bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0].Rate -= .2f;
            towerModel.GetAttackModel().weapons[0].projectile.pierce += 1;
        }
    }
    public class LaserReactorCore : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";


        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 12500;
        public override string Description => "Adds a massive targetable laser to the back of the suit";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0] = Game.instance.model.GetTowerFromId("DartlingGunner-300").GetAttackModel().weapons[0].Duplicate();
            towerModel.GetAttackModel().weapons[0].Rate *= .5f;

        }
    }
    public class QuadExoAlpha : ModUpgrade<player3>
    {
        public override string Portrait => "player3-Portrait.png";
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 115000;

        public override string DisplayName => "Q.U.A.D Exo-Suit";
        public override string Description => "The alpha exo suit improves abilities beyond human possibilities";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("SuperMonkey-050").GetBehavior<AbilityModel>().Duplicate());
            var attackAbil = towerModel.GetBehavior<AbilityModel>();
            towerModel.GetBehavior<AbilityModel>().icon = GetSpriteReference(mod, "QuadExoAlpha-Icon");
            towerModel.GetBehavior<AbilityModel>().cooldown = 25f;
            towerModel.GetAttackModel().weapons[0].Rate *= .01f;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage *= 3;
        }
    }
}
namespace bananafarmfake
{
    public class BananaFarmer000Farm : ModTower
    {
        public override string Portrait => "000-BananaFarm";
        public override string Name => "Banana Farm";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.BananaFarm;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Banana Farm";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 3, false, false));
        }
        public class Player3Farm000Display : ModTowerDisplay<BananaFarmer000Farm>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 0, 0, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }
        
    }
    public class BananaFarmer120Farm : ModTower
    {
        public override string Portrait => "000-BananaFarm";
        public override string Name => "Banana Farm 1-2-0";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "BananaFarm-120";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Improved Banana Farm";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 1, false, false));
        }
        public class Player3Farm120Display : ModTowerDisplay<BananaFarmer120Farm>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 1, 2, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class BananaFarmer320Farm : ModTower
    {
        public override string Portrait => "300-BananaFarm";
        public override string Name => "Banana Farm 3-2-0";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "BananaFarm-320";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Improved Banana Forest";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 50f, 1, false, false));
        }
        public class Player3Farm320Display : ModTowerDisplay<BananaFarmer320Farm>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 3, 2, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class BananaFarmer500Farm : ModTower
    {
        public override string Portrait => "500-BananaFarm";
        public override string Name => "Banana Farm 5-0-0";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "BananaFarm-500";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Improved Banana Factory";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 1, false, false));
        }
        public class Player3Farm500Display : ModTowerDisplay<BananaFarmer500Farm>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 5, 2, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
}
namespace RandomTowers
{
    public class Ninja320 : ModTower
    {
        public override string Portrait => "320-Ninja";
        public override string Name => "320 Ninja";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "NinjaMonkey-320";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Ninja 320";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 15f, 1, false, false));
        }
        public class Player3Ninja1Display : ModTowerDisplay<Ninja320>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.NinjaMonkey, 3, 2, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class Sniper000 : ModTower
    {
        public override string Portrait => "000-Sniper";
        public override string Name => "000 Sniper";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.SniperMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Sniper 000";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 1, false, false));
        }
        public class Player3Sniper1Display : ModTowerDisplay<Sniper000>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.SniperMonkey, 0, 0, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class Quincy : ModTower
    {
        public override string Portrait => "1-Quincy";
        public override string Name => "1 Quincy";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.Quincy;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Quincy 1";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 1, false, false));
        }
        public class Player3Quincy1Display : ModTowerDisplay<Quincy>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.Quincy);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class PatFusty : ModTower
    {
        public override string Portrait => "1-PatFusty";
        public override string Name => "1 PatFusty";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.PatFusty;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "PatFusty 1";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 1, false, false));
        }
        public class Player3Pat1Display : ModTowerDisplay<PatFusty>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.PatFusty);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class PatFusty14 : ModTower
    {
        public override string Portrait => "1-PatFusty";
        public override string Name => "14 PatFusty";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "PatFusty 14";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "PatFusty 14";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 25f, 1, false, false));
        }
        public class Player3Pat10Display : ModTowerDisplay<PatFusty14>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.PatFusty);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class Quincy14 : ModTower
    {
        public override string Portrait => "1-Quincy";
        public override string Name => "14 Quincy";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "Quincy 14";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Quincy 14";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 25f, 1, false, false));
        }
        public class Player3Quincy10Display : ModTowerDisplay<Quincy14>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.Quincy);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class Sniper005 : ModTower
    {
        public override string Portrait => "000-Sniper";
        public override string Name => "005 Sniper";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "SniperMonkey-005";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Sniper 005";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 1, false, false));
        }
        public class Player3Sniper004Display : ModTowerDisplay<Sniper005>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.SniperMonkey, 0, 0, 5);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
    public class Ninja520 : ModTower
    {
        public override string Portrait => "320-Ninja";
        public override string Name => "520 Ninja";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => "NinjaMonkey-520";

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Ninja 520";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 1, false, false));
        }
        public class Player3Ninja420Display : ModTowerDisplay<Ninja520>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.NinjaMonkey, 5, 2, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
}
namespace Bomb
{
    public class BombTower : ModTower
    {
        public override string Portrait => "1-Quincy";
        public override string Name => "Q.U.A.D Drone";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.SentryParagon;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Quincy Bomb";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

        }
        public class Player3DronePadDisplay : ModTowerDisplay<BombTower>
        {
            public override float Scale => .3f;
            public override string BaseDisplay => GetDisplay(TowerType.Quincy);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }
    }
}