using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BuffImage : MonoBehaviour
{
    public string Name { get; set; }
    public string Description { get; set; }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            Debug.Log("Clicked on : " + this.Name + " Description : " + this.Description);
        });
    }
}
