using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasketBehavior : MonoBehaviour
{
    void Update()
    {
        Vector3 rawMouse = Input.mousePosition;

        Vector3 convertedMouse = Camera.main.ScreenToWorldPoint(rawMouse);

        Vector3 pos = transform.position;

        pos.x = convertedMouse.x;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cherry")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Bounds").GetComponent<BoundaryBehavior>().IncrementScore();
        }
    }
}
