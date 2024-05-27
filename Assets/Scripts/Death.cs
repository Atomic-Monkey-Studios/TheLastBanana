using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            string currentSceneName = SceneManager.GetActiveScene().name;
            GetComponent<AudioSource>().Play();
            SceneChanger.Instance.ChangeScene(currentSceneName);
            // SceneManager.LoadScene(currentSceneName);
        } else if (other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject); // DIE STUPID MONKEY !
        }
    }
}
