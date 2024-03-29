﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start() {
        target = Waypoints.points[0];
    }

    void Update() {
        Vector3 direction = target.position - this.transform.position;
        this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

}
