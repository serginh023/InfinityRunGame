using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemPool
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}

public static class Utils
{
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = r.Next(n+1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

public class Pool : MonoBehaviour
{
    public static Pool singleton;

    public List<ItemPool> items;

    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this;

        pooledItems = new List<GameObject>();
        foreach (ItemPool item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject go = Instantiate(item.prefab);
                go.SetActive(false);
                pooledItems.Add(go);
            }
        }
    }

    public GameObject GetRandom()
    {
        Utils.Shuffle(pooledItems);

        for(int i = 0; i < pooledItems.Count; i++)
            if (!pooledItems[i].activeInHierarchy)
                return pooledItems[i];


        foreach(ItemPool item in items)
        {
            if (item.expandable)
            {
                GameObject go = Instantiate(item.prefab);
                go.SetActive(false);
                pooledItems.Add(go);
                return go;
            }
        }

        return null;
    }

}
