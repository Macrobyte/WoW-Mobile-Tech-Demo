using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
public class SpeedBuff : ScriptableBuff
{
    public float speedBoost;

    public override TimedBuff InitializeBuff(GameObject obj)
    {
        return new TimedSpeedBuff(this, obj);
    }
}
