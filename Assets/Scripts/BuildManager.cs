﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    
    void Awake() {
        if(instance) {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    private GameObject turretToBuild;

    void Start() {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild() {
        return turretToBuild;
    }
}
