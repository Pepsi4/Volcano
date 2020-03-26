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
    public string Name { get; set; }
    public string Description { get; set; }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            Debug.Log("Clicked on : " + this.Name + " Description : " + this.Description);
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HelpText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HelpText.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HelpText.SetActive(!HelpText.active);
    }
}
