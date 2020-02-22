using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private GoldenSmileBuff goldenSmileBuff;

    public UnityEngine.Events.UnityEvent OnCoinsValueChanged; // going to execute when coins value are changed.

    private void Start()
    {
        goldenSmileBuff = new GoldenSmileBuff();
    }

    [SerializeField]
    private TextMeshProUGUI priceText;

    [SerializeField]
    protected TextMeshProUGUI descriptionText;

    [SerializeField]
    protected TextMeshProUGUI nameText;

    [SerializeField]
    private BuffsShower BuffsShower;

    private void UpdateUI(int price, string name, string description)
    {
        priceText.text = price.ToString();
        nameText.text = name;
        descriptionText.text = description;
    }

    public void BuyItem(string name)
    {
        switch (name)
        {
            case "GoldenSmileBuff":
                if (CoinsController.Coins >= goldenSmileBuff.Price)
                {
                    PlayerShop.AddBuff(goldenSmileBuff);





                    CoinsController.Coins -= goldenSmileBuff.Price;
                    OnCoinsValueChanged.Invoke();

                    goldenSmileBuff.IncreaseChance();
                    goldenSmileBuff.IncreasePrice();
                    goldenSmileBuff.Level++;

                    UpdateUI(goldenSmileBuff.Price, goldenSmileBuff.Name, goldenSmileBuff.Description);
                    BuffsShower.UpdateBuffsPanel();

                }

                break;
        }
    }
}

public class Buff : MonoBehaviour
{
    virtual public string Description { get; set; }
    public int Level { get; set; } = 1;

    [SerializeField]
    public virtual Sprite Sprite { get; set; }
    virtual public string Name { get; set; }

    protected float _pricePercentsModifier = 100f;
    private float _deltaPricePercents = 10f;

    public void IncreasePrice()
    {
        _pricePercentsModifier += _deltaPricePercents;
        _deltaPricePercents += 10;
    }
}

public interface IBuff
{

}

public class GoldenSmileBuff : Buff
{
    public override Sprite Sprite
    {
        get { return Resources.Load<Sprite>("Sprites/Slime"); }
    }

    public override string Description
    {
        get
        {
            return "In the next session chanse of spawn a golden smile will be " + _chance + "%";
        }
    }

    public override string Name
    {
        get
        {
            return "GOLDEN SMILE LEVEL " + Level;
        }
    }

    private int price = 60;
    public int Price
    {
        get { return (price * (int)_pricePercentsModifier / 100); }

        set { price = value; }
    }


    private float _chance = 15f;
    private float _increaseChance = 5f;

    public void IncreaseChance()
    {
        _chance += _increaseChance;
    }
}

public enum Buffs
{
    GoldenSlime
}
