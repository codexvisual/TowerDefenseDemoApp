using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private TurretBlueprint turretToDeploy;

    public GameObject standardTurretPrefab;
    public GameObject gatlingGunPrefab;
    public GameObject missileLauncherPrefab;

    private Node selectedNode;

    public NodeUI nodeUI;

    void Start() {

    }

    void Awake () {

        if (instance != null) {

        }
        instance = this;
	}

    public bool CanBuild { get { return turretToDeploy != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToDeploy.cost; } }

    public void SelectNode(Node node) {

        if (selectedNode == node) {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToDeploy = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToDeploy(TurretBlueprint turret) {
        turretToDeploy = turret;
        selectedNode = null;

        nodeUI.Hide();
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild() {
        return turretToDeploy;
    }
}
