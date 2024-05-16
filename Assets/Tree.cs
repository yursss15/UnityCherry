using System.Collections;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float treeSpeed = 2.0f;
    public GameObject cherryPrefab;

    void Start()
    {
        StartCoroutine(DropCherry());
    }

    IEnumerator DropCherry()
    {
        while (true)  
        {

            GameObject cherry = Instantiate<GameObject>(cherryPrefab);
            cherry.transform.position = transform.position;

            yield return new WaitForSeconds(1.0f); 
        }
    }

    void Update()
    {
        transform.Translate(treeSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bounds")
            treeSpeed *= -1.0f;
    }
}