using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private Transform target;

    public float speed = 70f;

    public void Seek(Transform target) {
        this.target = target;
    }

    void Update() {
        if (!target) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - this.transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        
    }
    void HitTarget() {
        Destroy(gameObject);
    }

}
