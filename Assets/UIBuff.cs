using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuff : MonoBehaviour
{
    public TimedBuff buff;

    public string buffName;
    public string buffDescription;
    public TMPro.TMP_Text buffDuration;
    public Image buffIcon;
    public Button buffButton;
    public GameObject buffDescriptionPanel;


    private void Awake()
    {
        buffDuration = GetComponentInChildren<TMPro.TMP_Text>();
        buffIcon = GetComponentsInChildren<Image>()[1];
    }


    void Start()
    {
        buffName = buff.buff.name;
        buffDescription = buff.buff.description;
        buffIcon.sprite = buff.buff.icon;

        buffButton = GetComponent<Button>();
        buffButton.onClick.AddListener(() => SetBuffDescriptionPanel());

    }

    private void SetBuffDescriptionPanel()
    {
        buffDescriptionPanel.SetActive(true);
        buffDescriptionPanel.GetComponentsInChildren<TMPro.TMP_Text>()[0].text = buffName;
        buffDescriptionPanel.GetComponentsInChildren<TMPro.TMP_Text>()[1].text = buffDescription;
        buffDescriptionPanel.GetComponentsInChildren<Button>()[1].onClick.AddListener(() => DismissBuff());
    }

    private void DismissBuff()
    {
        buff.End();
        Destroy(gameObject);
        buffDescriptionPanel.SetActive(false);
    }
    
    void Update()
    {
        if (buff.GetCurrentDuration() != -1)
        {
            if (buff.GetCurrentDuration() > 0)
            {
                if (buff.GetCurrentDuration() > 60)
                {
                    buffDuration.text = Mathf.Floor(buff.GetCurrentDuration() / 60).ToString() + "m";
                }
                else
                {
                    buffDuration.text = Mathf.Floor(buff.GetCurrentDuration()).ToString() + "s";
                }
            }
            else
            {
                buffDuration.text = "";
                Destroy(gameObject);
                buffDescriptionPanel.SetActive(false);
            }
        }
        else
        {
            buffDuration.text = "";
        }

    }
}
