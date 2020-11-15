using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShop : MonoBehaviour
{
    public static List<Buff> Buffs = new List<Buff>();


    private void Start()
    {
    }

    /// <summary>
    /// Returns TRUE if buff is updated in list. Returns FALSE if buff is added as new one.
    /// </summary>
    /// <param name="buff"></param>
    /// <returns></returns>
    public static bool AddBuff(Buff buff)
    {

        int sameBuffNumber = 0;
        bool isListShouldChange = false;

        for (int i = 0; i < Buffs.Count; i++)
        {
            if (Buffs[i].GetType() == buff.GetType())
            {
                sameBuffNumber = i;
                isListShouldChange = true;
            }
        }

        Debug.Log("isListShouldChange : " + isListShouldChange);
        //Debug.Log("sameBuffNumber :" + sameBuffNumber);

        if (isListShouldChange)
        {
            Buffs[sameBuffNumber] = buff;
            return true;
        }
        else
        {
            Buffs.Add(buff);
            return false;
        }
    }

    public static void SaveBuff(Buff buff)
    {
        // ключ и значение 
        // ключ = имя бафа
        // значение = имя бафа + левел
        // PlayerPrefs.SetString();
    }
    // public PlayerShop() 
}
