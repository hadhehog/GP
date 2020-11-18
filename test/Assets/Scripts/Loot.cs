using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    //public Item item;
    public float chance;
    public int minQuantity;
    public int maxQuantity;

    public int Quantity { get; set; }
}

[CreateAssetMenu]
public class LootTable: ScriptableObject
{
    public Loot[] loots;

    public ArrayList GetLoot()
    {
        ArrayList dropList = new ArrayList();
        float drawn = Random.Range(0f, 100f);

        foreach (Loot loot in loots)
        {
            if (drawn <= loot.chance)
            {
                loot.Quantity = RandomQuantity(loot);
                dropList.Add(loot);
            }
        }

        return dropList;
    }

    public int RandomQuantity(Loot loot)
    {
        return Random.Range(loot.minQuantity, loot.maxQuantity);
    }
}