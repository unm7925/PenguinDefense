using System;
using UnityEngine;
public class Weapon_Knife:Weapon
{
    protected override void Attack(Transform _transform , TargetSystem _targetSystem)
    {
        Vector2 pos = _transform.position;
        _targetSystem.GetClosesTarget(pos);
    }
}
