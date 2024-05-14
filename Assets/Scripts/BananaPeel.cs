using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class BananaPeel : MonoBehaviour
{

    Collider2D col;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("BANANA PEEL");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400f));
            other.transform.Rotate(0f, 0f, 90f, Space.Self);

            col.enabled = false;
            rb.isKinematic = false;
            rb.AddForce(new Vector2(750, 200));
            // StartCoroutine(applyBananaEffect(other.gameObject.GetComponent<PlayerMovement>()));
        }
    }

    // IEnumerator applyBananaEffect(PlayerMovement playerMovement) {
    //     Debug.Log("aaaaaaaaaa");
    //     float oldSpeed = playerMovement.speed;
    //     playerMovement.speed *= 2;
    //     yield return new WaitForSeconds(1);
    //     playerMovement.speed = oldSpeed;
    // }
}
