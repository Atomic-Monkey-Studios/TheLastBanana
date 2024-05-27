using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartCinematic : MonoBehaviour
{

    public GameObject billboard;
    public Transform panicLocation;

    public float walkingSpeed = 4f;


    private CinematicPhase phase = CinematicPhase.Start;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.GetComponent<PlayerMovement>().enabled = false;
        animator = gameObject.GetComponent<Animator>();
    }

    void OnEnable() {
        Debug.Log("Starting cinematic n°1");
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        gameObject.GetComponent<Animator>().SetFloat("walkingSpeed", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < panicLocation.position.x) {
            transform.position += new Vector3(walkingSpeed * Time.deltaTime, 0f);
        } else {
            if (phase == CinematicPhase.Start) {
                phase = CinematicPhase.Watching;
                animator.SetBool("isWalking", false);

                StartCoroutine(wait());
            }
        }
    }

    IEnumerator wait() {
        billboard.GetComponent<Animator>().SetTrigger("triggerCutscene");

        yield return new WaitForSeconds(4.5f);

        animator.SetBool("isAngry", true);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<StartCinematic>().enabled = false;
        // SceneChanger.Instance.ChangeScene("LevelDesign");
    }

}



enum CinematicPhase {
    Start,
    Watching,
    Running,
}