using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Info")]
    [SerializeField] protected new string name;
    [SerializeField] protected Sprite image;

    [Header("Character Stats")]
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    [SerializeField] protected float maxResource;
    protected float currentResource;

    private enum Resource { Rage, Mana, None }

    [SerializeField] private Resource resource;
    

    [SerializeField] protected Character target;
    [SerializeField] protected bool isTargeted;

    private readonly Dictionary<ScriptableBuff, TimedBuff> buffs = new Dictionary<ScriptableBuff, TimedBuff>();

    protected void Update()
    {
        HandleBuffTick();
    }


    public virtual void AddBuff(TimedBuff buff)
    {
        if(buffs.ContainsKey(buff.buff))
        {
            buffs[buff.buff].Activate();
        }
        else
        {
            buffs.Add(buff.buff, buff);
            buff.Activate();
        }
    }
    
    private void HandleBuffTick()
    {
        foreach (var buff in buffs.Values.ToList())
        {
            buff.Tick(Time.deltaTime);
            if (buff.isFinished)
            {
                buffs.Remove(buff.buff);
            }
        }
    }


    #region Setters
    public void SetIsTargeted(bool isTargeted)
    {
        this.isTargeted = isTargeted;
    }

    public void SetTarget(Character target)
    {
        this.target = target;
    }

    #endregion

    #region Getters
    public string GetName()
    {
        return name;
    }

    public Sprite GetSprite()
    {
        return image;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxResource()
    {
        return maxResource;
    }

    public float GetCurrentResource()
    {
        return currentResource;
    }

    public Character GetTarget()
    {
        return target;
    }
    #endregion



}
