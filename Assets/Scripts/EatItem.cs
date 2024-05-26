using System.Collections;
using UnityEngine;

public class EatFruit : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Eat() {
        StartCoroutine(EatCoroutine());
    }

    IEnumerator EatCoroutine() {
        animator.SetBool("eat", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }


}
