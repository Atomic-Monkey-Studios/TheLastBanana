using UnityEngine;

public class CollectItem : MonoBehaviour
{

    
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerInventory>().SetItem(gameObject);
            col.enabled = false;
        }
    }
}
