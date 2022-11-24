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
    public GameObject targetPanel;
    [SerializeField] private Character currentTarget;
    [SerializeField] private Image targetImage;
    [SerializeField] private Image targetHealth;
    [SerializeField] private Image targetResource;
    [SerializeField] private TMPro.TMP_Text targetName;

    [Header("Target Of Target")]
    public GameObject targetOfTargetPanel;
    [SerializeField] private Character targetOfCurrentTarget;
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

        targetOfTargetPanel.gameObject.SetActive(false);
        targetPanel.gameObject.SetActive(false);
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
                Character targetHit = hit.collider.transform.gameObject.GetComponent<Character>();

                if (currentTarget == null)
                {
                    currentTarget = targetHit;
                    currentTarget.SetIsTargeted(true);
                    self.SetTarget(targetHit);
                    SetTargetPanel(targetHit);

                    targetOfCurrentTarget = currentTarget.GetTarget();
                }
                else if (currentTarget != targetHit)
                {
                    currentTarget.SetIsTargeted(false);
                    currentTarget = targetHit;              
                    currentTarget.SetIsTargeted(true);
                    self.SetTarget(targetHit);
                    SetTargetPanel(targetHit);

                    targetOfCurrentTarget = currentTarget.GetTarget();

                }
            }
        }
    }
    
    void SetTargetPanel(Character target)
    {
        targetPanel.gameObject.SetActive(true);
        targetImage.sprite = target.GetSprite();
        targetHealth.fillAmount = target.GetCurrentHealth() / target.GetMaxHealth();
        targetResource.fillAmount = target.GetCurrentResource() / target.GetMaxResource();
        targetName.text = target.GetName();

        SetTargetOfTargetPanel(target);
    }

    void SetTargetOfTargetPanel(Character target)
    {
        Character targetoftarget = target.GetTarget();

        if (target.GetTarget() != null)
        {
            
            targetOfTargetPanel.gameObject.SetActive(true);
            targetoftargetImage.sprite = targetoftarget.GetSprite();
            targetoftargetHealth.fillAmount = targetoftarget.GetCurrentHealth() / targetoftarget.GetMaxHealth();
            targetoftargetResource.fillAmount = targetoftarget.GetCurrentResource() / targetoftarget.GetMaxResource();
            targetoftargetName.text = targetoftarget.GetName();
        }
        else
        {
            targetOfTargetPanel.gameObject.SetActive(false);
        }
    }
}