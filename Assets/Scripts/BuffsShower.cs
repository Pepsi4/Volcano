using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BuffsShower : MonoBehaviour
{
    public GameObject BuffsPanel;
    public GameObject BuffImageObject;

    private const int defaultValueSpawnY = 200;
    private static int spawnY;
    private const int differenceY = 150;

    public void UpdateBuffsPanel()
    {
        this.gameObject.DestroyChildren();
        spawnY = defaultValueSpawnY;

        foreach (Buff buff in PlayerShop.Buffs)
        {
            GameObject gameObject = Instantiate(BuffImageObject, new Vector2(transform.position.x, spawnY), new Quaternion(), transform);
            gameObject.GetComponent<Image>().sprite = buff.Sprite;
            gameObject.transform.localPosition = new Vector2(0, spawnY);
           // gameObject.AddComponent<BuffImage>();
            gameObject.GetComponent<BuffImage>().Name = buff.Name;
            gameObject.GetComponent<BuffImage>().Description = buff.Description;
            spawnY -= differenceY;
        }
    }

}

public static class GameObjectExtension
{
    public static void DestroyChildren(this GameObject go)
    {
        foreach (Transform child in go.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
