using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuffController : MonoBehaviour
{
    public static UIBuffController Instance;

    [SerializeField] private GameObject buffPanel;
    [SerializeField] private GameObject UIbuffPrefab;
    [SerializeField] private GameObject buffDescriptionPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        buffDescriptionPanel = GameObject.Find("Buff Description Panel");
        buffDescriptionPanel.SetActive(false);       
    }

    public void AddBuff(TimedBuff buff)
    {
        GameObject UIbuffObject = Instantiate(UIbuffPrefab, buffPanel.transform);
        UIbuffObject.GetComponent<UIBuff>().buff = buff;
        UIbuffObject.GetComponent<UIBuff>().buffDescriptionPanel = buffDescriptionPanel;
    }

    
}
