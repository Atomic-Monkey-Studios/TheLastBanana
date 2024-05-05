using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{


    public int direction = 1;
    public int movingTo = 1;

    public float speed = 2f;

    private List<Vector3> points; 

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();
        foreach(Transform point in transform) {
            points.Add(point.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = CurrentTarget();
        float distanceToTarget = (target - transform.position).magnitude;

        if (distanceToTarget < 0.1f) {
            UpdateTarget();
            target = CurrentTarget();
        }

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    private Vector3 CurrentTarget() {
        return points[movingTo];
    }

    private void UpdateTarget() {
        if (movingTo + direction == -1) {
            direction = 1;
        } else if (movingTo + direction == points.Count) {
            direction = -1;
        }
        movingTo += direction;
    }





}


