using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{

    [Header("Self")]
    public Character self;
    [SerializeField] private Image selfImage;
    [SerializeField] private Image selfHealth;
    [SerializeField] private Image selfResource;
    [SerializeField] private TMPro.TMP_Text selfName;

    [Header("Target")]
    public GameObject target;
    [SerializeField] private Image targetImage;
    [SerializeField] private Image targetHealth;
    [SerializeField] private Image targetResource;
    [SerializeField] private TMPro.TMP_Text targetName;

    [Header("Target Of Target")]
    public GameObject targetOfTarget;
    [SerializeField] private Image targetoftargetImage;
    [SerializeField] private Image targetoftargetHealth;
    [SerializeField] private Image targetoftargetResource;
    [SerializeField] private TMPro.TMP_Text targetoftargetName;


    private void Start()
    {
        self = PlayerController.Instance.gameObject.GetComponent<Character>();
        selfImage.sprite = self.GetSprite();
        selfHealth.fillAmount = self.GetCurrentHealth() / self.GetMaxHealth();
        selfResource.fillAmount = self.GetCurrentResource() / self.GetMaxResource();
        selfName.text = self.GetName();

        targetOfTarget.gameObject.SetActive(false);
        target.gameObject.SetActive(false);
    }

    private void Update()
    {
        HandleTargeting();
              
    }


    public void HandleTargeting()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);


            if (hit.collider != null)
            {
                target.gameObject.SetActive(true);

                Character targetHit = hit.collider.transform.gameObject.GetComponent<Character>(); ;

                self.SetTarget(targetHit);
                SetTargetPanel(targetHit);
            }


        }
    }


    void SetTargetPanel(Character target)
    {   
        targetImage.sprite = target.GetSprite();

        SetTargetOfTargetPanel(target);
    }

    void SetTargetOfTargetPanel(Character target)
    {
        Character targetoftarget = target.GetTarget();

        
        if (targetoftarget != null)
        {
            targetOfTarget.gameObject.SetActive(true);
            targetoftargetImage.sprite = targetoftarget.GetSprite();
        }
        else
        {
            targetOfTarget.gameObject.SetActive(false);
        }

        

        
    }
}