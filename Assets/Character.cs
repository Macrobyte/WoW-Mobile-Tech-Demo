using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Info")]
    [SerializeField] protected string name;
    [SerializeField] protected Sprite image;

    [Header("Character Stats")]
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    [SerializeField] protected float maxResource;
    protected float currentResource;
    [SerializeField] protected Color resourceColor;

    [SerializeField] protected Character target;
    [SerializeField] protected bool isTargeted;







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

    public Color GetResourceColor()
    {
        return resourceColor;
    }

    public Character GetTarget()
    {
        return target;
    }
    #endregion



}
