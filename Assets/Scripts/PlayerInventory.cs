using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public Transform itemSlot;
    public GameObject heldItem;
    public AudioSource audioSource;

    private bool eating = false;

    // Start is called before the first frame update
    void Start()
    {
        eating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (heldItem.IsDestroyed() || eating) return;
            eating = true;
            StartCoroutine(EatCoroutine());
        }
    }

    public void SetItem(GameObject it) {
        heldItem = it;
        heldItem.transform.position = itemSlot.position;
        heldItem.transform.SetParent(itemSlot);
        if (it.CompareTag("Banana")) gameObject.GetComponent<EndCinematic>().enabled = true;
    }

    IEnumerator EatCoroutine() {
        heldItem.GetComponent<Animator>().SetTrigger("eat");
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        Destroy(heldItem);
        eating = false;
        if (heldItem.CompareTag("Banana")) {
            yield return new WaitForSeconds(1.5f);
            gameObject.GetComponent<EndGame>().End(true);
        }
    }
}
