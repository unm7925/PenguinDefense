using System;


public enum UpgradeType
{
    Damage,
    Cooldown,
    ProjectileSpeed,
    ProjectileCount,
    BounceCount,
    PierceCount,
    AoERadius
}

[Serializable]
public class UpgradeOption
{
    public UpgradeType type;
    public float value;
    public string description;
}
