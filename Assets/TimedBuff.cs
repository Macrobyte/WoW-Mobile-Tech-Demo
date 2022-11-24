using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedBuff
{
    protected float duration;
    protected int effectStacks;
    public ScriptableBuff buff { get; }

    protected readonly GameObject obj;
    public bool isFinished;

    public TimedBuff(ScriptableBuff buff, GameObject obj)
    {
        this.buff = buff;
        this.obj = obj;

    }

    public void Tick(float delta)
    {
        if(duration != -1)
        {
            duration -= delta;
            if (duration <= 0)
            {
                End();
                isFinished = true;
            }
        }      
    }

    public void Activate()
    {
        if(buff.isEffectStacked || duration <= 0)
        {
            ApplyEffect();
            effectStacks++;
        }

        if(buff.isDurationStacked || duration <= 0) 
        {
            duration += buff.duration;
        }
    }

    public float GetCurrentDuration()
    {
        return duration;
    }

    protected abstract void ApplyEffect();

    public abstract void End();
}
