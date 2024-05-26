using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public Transform itemSlot;
    public GameObject heldItem;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (heldItem.IsDestroyed()) return;
            if (heldItem.CompareTag("Item")) {
                heldItem.GetComponent<EatFruit>().Eat();
            }
            if (heldItem.CompareTag("Banana")) {
                heldItem.GetComponent<EatFruit>().Eat();
            }
        }
    }

    public void SetItem(GameObject it) {
        heldItem = it;
        heldItem.transform.position = itemSlot.position;
        heldItem.transform.SetParent(itemSlot);
    }
}
