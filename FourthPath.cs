using MelonLoader;
using BTD_Mod_Helper;
using FourthPath;
using PathsPlusPlus;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Enums;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using JetBrains.Annotations;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppSystem.IO;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Utils;

[assembly: MelonInfo(typeof(FourthPath.FourthPath), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace FourthPath;

public class FourthPath : BloonsTD6Mod
{

    public class FourthPath2 : PathPlusPlus
    {
        public override string Tower => TowerType.BombShooter;
        public override int UpgradeCount => 5;


    }
    public class CamoBombs : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 50;
        public override int Tier => 1;
        public override string Icon => VanillaSprites.MonkeySenseUpgradeIcon;

        public override string Description => "Darts can pop Frozen bloons";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
        }
    }
    public class BitExtraRange : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 250;
        public override int Tier => 2;
        public override string Icon => VanillaSprites.LongerRangeUpgradeIcon;
        public override string Description => "Bombs get more range";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetBehavior<AttackModel>().range += 15;
            towerModel.range += 15;
        }

    }
    partial class FastSpeed : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 1420;
        public override int Tier => 3;
        public override string Icon => VanillaSprites.FasterBarrelSpinUpgradeIcon;
        public override string Description => "Bomb shooter shoots really fast";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].rate -= 0.5f;
        }
    }
    public class QuadDropilesDamage : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 7500;
        public override int Tier => 4;
        public override string Icon => VanillaSprites.JuggernautUpgradeIcon;
        public override string Description => "Bomb shooter does Quad damage";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 500;
        }
    }
    public class UlimatePower : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 150000;
        public override int Tier => 5;
        public override string Icon => VanillaSprites.TrueSonGodUpgradeIcon;
        public override string Description => "Power!!";
        public override string? Portrait => "Bcrush_X_TSG";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.display = new PrefabReference() { guidRef = "02869eae1ede09640bbf409d69d6aabe" };
            var attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "dcd6cd8511c9a03458a32f42f860882c" };
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().damage += 9998;
            attackModel.weapons[0].rate -= 0.25f;
            attackModel.range += 100;
            towerModel.range += 100;
        }
    }
}