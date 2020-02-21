using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    private GameObject turret;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown() {
        if (turret) {
            Debug.Log("Can't build here!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
