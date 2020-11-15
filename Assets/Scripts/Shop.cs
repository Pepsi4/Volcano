using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private GoldenSmileBuff goldenSmileBuff;
    private MushroomSmileBuff mushroomSmileBuff;

    public UnityEngine.Events.UnityEvent OnCoinsValueChanged; // going to execute when coins value are changed.

    private void Start()
    {
        goldenSmileBuff = new GoldenSmileBuff();
        mushroomSmileBuff = new MushroomSmileBuff();
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

                    UpdateUI(goldenSmileBuff.Price, goldenSmileBuff.Name + (goldenSmileBuff.Level + 1), goldenSmileBuff.Description);
                    BuffsShower.UpdateBuffsPanel();

                }
                break;

            case "MushroomSmileBuff":
                if (CoinsController.Coins >= mushroomSmileBuff.Price)
                {
                    PlayerShop.AddBuff(mushroomSmileBuff);

                    CoinsController.Coins -= mushroomSmileBuff.Price;
                    OnCoinsValueChanged.Invoke();

                    mushroomSmileBuff.IncreaseChance();
                    mushroomSmileBuff.IncreasePrice();
                    mushroomSmileBuff.Level++;

                    UpdateUI(mushroomSmileBuff.Price, mushroomSmileBuff.Name + (mushroomSmileBuff.Level + 1), mushroomSmileBuff.Description);
                    BuffsShower.UpdateBuffsPanel();

                }
                break;
        }
    }
}


public class Buff : MonoBehaviour
{
    public virtual SlimeType SlimeType { get; set; }

    protected float _chance = 0.15f;
    public float Chance { get { return _chance; } set { _chance = value; } }
    virtual public string Description { get; set; }
    public int Level { get; set; } = 0;

    [SerializeField]
    public virtual Sprite Sprite { get; set; }
    virtual public string Name { get; set; }

    protected float _pricePercentsModifier = 100f;
    private float _deltaPricePercents = 10f; // something is wrong here...

    public void IncreasePrice()
    {
        _pricePercentsModifier += _deltaPricePercents;
        _deltaPricePercents += 10;
    }
}

public interface IBuff
{

}

public enum SlimeType
{
    Slime = 1,
    MushroomSlime = 2,
    GoldenSlime = 3,
    MiddleSlime = 4,
    FireSlime = 5,
    IceSlime = 6
}

public class SlimeBuff : Buff
{
    public override SlimeType SlimeType { get; set; } = SlimeType.Slime;
    //new public int SlimeType2 = 1;
    public override string Name { get { return "SlimeBuff"; } }
}

public class MiddleSlimeBuff : Buff
{
    new int _chance = 50;
    public override SlimeType SlimeType { get; set; } = SlimeType.MiddleSlime;
    public override string Name { get { return "MiddleSlimeBuff"; } }
}

public class FireSmileBuff : Buff
{
    public override SlimeType SlimeType { get; set; } = SlimeType.FireSlime;

    public override Sprite Sprite
    {
        get
        {
            Debug.Log("Sprites/" + GetType());
            return Resources.Load<Sprite>("Sprites/" + GetType());
        }
    }

    public override string Description
    {
        get
        {
            return "In the next session chanse of spawn a fire smile will be " + _chance + "%";
        }
    }

    public override string Name
    {
        get
        {
            return "Fire Slime";
        }
    }

    private int price = 160;
    public int Price
    {
        get { return (price * (int)_pricePercentsModifier / 100); }

        set { price = value; }
    }

    private int _increaseChance = 5;

    public void IncreaseChance()
    {
        _chance += _increaseChance;
    }
}


public class IceSlimeBuff : Buff
{
    public override SlimeType SlimeType { get; set; } = SlimeType.IceSlime;

    public override Sprite Sprite
    {
        get
        {
            Debug.Log("Sprites/" + GetType());
            return Resources.Load<Sprite>("Sprites/" + GetType());
        }
    }

    public override string Description
    {
        get
        {
            return "In the next session chanse of spawn an ice smile will be " + _chance + "%";
        }
    }

    public override string Name
    {
        get
        {
            return "Ice Slime";
        }
    }

    private int price = 160;
    public int Price
    {
        get { return (price * (int)_pricePercentsModifier / 100); }

        set { price = value; }
    }

    private int _increaseChance = 5;

    public void IncreaseChance()
    {
        _chance += _increaseChance;
    }
}

public class MushroomSmileBuff : Buff
{
    public override SlimeType SlimeType { get; set; } = SlimeType.MushroomSlime;
    public override Sprite Sprite
    {
        get
        {
            Debug.Log("Sprites/" + GetType());
            return Resources.Load<Sprite>("Sprites/" + GetType());
        }
    }

    public override string Description
    {
        get
        {
            return "In the next session chanse of spawn a mashroom smile will be " + _chance + "%";
        }
    }

    public override string Name
    {
        get
        {
            return "Mushroom Slime";
        }
    }

    private int price = 60;
    public int Price
    {
        get { return (price * (int)_pricePercentsModifier / 100); }

        set { price = value; }
    }



    private int _increaseChance = 5;

    public void IncreaseChance()
    {
        _chance += _increaseChance;
    }
}

public class GoldenSmileBuff : Buff
{
    override public SlimeType SlimeType { get; set; } = SlimeType.GoldenSlime;

    public override Sprite Sprite
    {
        get
        {
            Debug.Log(GetType());
            return Resources.Load<Sprite>("Sprites/" + GetType());
        }
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
            return "GOLDEN SMILE";
        }
    }

    private int price = 60;
    public int Price
    {
        get { return (price * (int)_pricePercentsModifier / 100); }

        set { price = value; }
    }


    private int _increaseChance = 5;

    public void IncreaseChance()
    {
        _chance += _increaseChance;
    }
}

