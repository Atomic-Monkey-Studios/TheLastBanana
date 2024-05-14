using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCinematic : MonoBehaviour
{

    public GameObject playerObject;
    public Transform screenLocation;
    public bool isPlaying = false;

    public float walkingSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying) {
            
        }
    }

    public void Play() {
        isPlaying = true;
    }

    public void Stop() {
        isPlaying = false;
    }
}
