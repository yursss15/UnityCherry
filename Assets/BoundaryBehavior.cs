using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoundaryBehavior : MonoBehaviour
{
    public int score;

    public int i;

    public GameObject basketPrefab;

    private List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();

        float bottomEdge = transform.position.y + 1.3f;

        for (i = 0; i < 3; i++)
        {
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = basket.transform.position;
            pos.y = bottomEdge + (i * 0.5f);
            basket.transform.position = pos;
            basketList.Add(basket);
        }
    }

    public void IncrementScore()
    {
        score += 1;
        GameObject.Find("scoreOutput").GetComponent<Text>().text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cherry")
        {
            Destroy(collision.gameObject);

            int topBasket = basketList.Count - 1;

            if (topBasket > -1)
            {
                Destroy(basketList[topBasket]);
                basketList.RemoveAt(topBasket);
            }

            if (topBasket <= 0)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
