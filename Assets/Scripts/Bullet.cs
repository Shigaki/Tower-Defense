﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;

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
        transform.LookAt(target);

    }
    void HitTarget() {

        if (explosionRadius > 0f) {
            Explode();
        } else {
            Damage(target);
        }


        Destroy(gameObject);
    }
    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }



}
