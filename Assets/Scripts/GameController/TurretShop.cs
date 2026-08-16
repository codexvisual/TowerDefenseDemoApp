using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour {

    BuildManager builManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint gatlingGunTurret;
    public TurretBlueprint missileLauncherTower;

	void Start () {
        builManager = BuildManager.instance;
	}
	
	void Update () {
		
	}

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Purchased!");
        builManager.SelectTurretToDeploy(standardTurret);
    }

    public void SelectGatlingGun() {
        Debug.Log("Missile Launcher Purchased!");
        builManager.SelectTurretToDeploy(gatlingGunTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Laser Purchased!");
        builManager.SelectTurretToDeploy(missileLauncherTower);
    }
}
