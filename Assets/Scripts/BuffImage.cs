using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class BuffImage : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
     , IPointerClickHandler
{

    public EventSystem eventSystem;
    public GameObject HelpText;
    public GameObject HelpTextPanel;
    public GameObject BuffLevelInfo;
    public string Name { get; set; }
    private int level;

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            
            level = value;
            BuffLevelInfo.GetComponent<TMPro.TextMeshProUGUI>().text = "Level " + level.ToString();
        }
    }

    private string description;
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
            UpdateHelpText();
        }
    }

    void UpdateHelpText()
    {
        HelpText.GetComponent<TMPro.TextMeshProUGUI>().text = Name;

        //HelpTextPanel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HelpText.GetComponent<RectTransform>().rect.height);
        //new Vector2(HelpTextPanel.GetComponent<RectTransform>().rect.width,
        //HelpText.GetComponent<RectTransform>().rect.width);
    }

    public void UpdateLevelInfo(string newValue)
    {
        BuffLevelInfo.GetComponent<TMPro.TextMeshProUGUI>().text = newValue;
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            Debug.Log("Clicked on : " + this.Name + " Description : " + this.Description);
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HelpTextPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HelpTextPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HelpTextPanel.SetActive(!HelpText.active);
    }
}
