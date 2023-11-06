using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("insribed)")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public string GameOver = "Medium";
    public float BasketSpaceingY = 2f;

    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {

        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (BasketSpaceingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AppleDestroyed()
    {
        // Destroy all of the falling Apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");// 3
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb");// 3
        foreach (GameObject BombGone in tBombArray)
        {
            Destroy(BombGone);
        }
        //// Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the List and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketList.Count == 0)
        {
            Application.LoadLevel(GameOver);
        }

    }
    public void BombDestroyed()
    {
        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb");// 3
        foreach (GameObject tGO in tBombArray)
        {
            Destroy(tGO);
        }
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");// 3
        foreach (GameObject AppleGone in tAppleArray)
        {
            Destroy(AppleGone);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the List and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketList.Count == 0)
        {
            Application.LoadLevel(GameOver);
        }


    }
}
