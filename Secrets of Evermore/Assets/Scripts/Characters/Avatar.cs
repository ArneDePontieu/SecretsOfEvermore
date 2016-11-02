using UnityEngine;
using System.Collections;

public class Avatar : Character
{

    public bool IsSelected { get; set; }
    public VisualCharacter VCharacter { get; set; }

    public float BonusWeaponDamage { get; set; }
    public float BonusArmorDefence { get; set; }

    public Avatar()
    {
        BonusArmorDefence = 0.0f;
        BonusWeaponDamage = 0.0f;
    }

}
