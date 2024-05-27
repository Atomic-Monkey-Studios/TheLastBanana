
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    
    public int killCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End(bool bananaEaten) {
        if (bananaEaten && killCount == 0) {
            SceneChanger.Instance.ChangeScene("NoBananasAndFight");
        } else if (bananaEaten && killCount > 0) {
            SceneChanger.Instance.ChangeScene("NoBananasAndDeath");
        } else if (!bananaEaten && killCount == 0) {
            SceneChanger.Instance.ChangeScene("BananasAndLove");
        } else if (!bananaEaten && killCount > 0) {
            SceneChanger.Instance.ChangeScene("BananasAndDeath");
        }
    }
}
