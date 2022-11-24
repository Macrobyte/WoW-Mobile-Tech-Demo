using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
    private readonly PlayerMovement playerMovement;

    public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        playerMovement = obj.GetComponent<PlayerMovement>();
    }

    protected override void ApplyEffect()
    {
        SpeedBuff speedBuff = (SpeedBuff)buff;
        playerMovement.Speed += speedBuff.speedBoost;
        Debug.Log("SpeedBuff: " + speedBuff.speedBoost);
    }

    public override void End()
    {
        SpeedBuff speedBuff = (SpeedBuff)buff;
        playerMovement.Speed -= speedBuff.speedBoost * effectStacks ;
        effectStacks = 0;
    }
}
