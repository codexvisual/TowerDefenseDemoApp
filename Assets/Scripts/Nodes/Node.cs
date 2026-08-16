using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color insufficientFundColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgaded = false;

    private Renderer render;
    private Color startColor;

    public Vector3 positionOffset;

    BuildManager buildManager;

    
    void Start () {
        render = GetComponent<Renderer>();
        startColor = render.material.color;

        buildManager = BuildManager.instance;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            Debug.Log("Cannot deploy here!");
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret(TurretBlueprint blueprint) {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Insufficient fund!");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        GameObject turrets = (GameObject)Instantiate(blueprint.turretPrefab, GetBuildPosition(), Quaternion.identity);
        turret = turrets;

        turretBlueprint = blueprint;
    }

    public void UpgardeTurret() {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Insufficient fund!");
            return;
        }

        PlayerStats.money -= turretBlueprint.cost;

        Destroy(turret);

        GameObject turrets = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = turrets;

        isUpgaded = true;

        Debug.Log("Turret Upgraded!");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
            return;       

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            render.material.color = hoverColor;
        }
        else {
            render.material.color = insufficientFundColor;
        }
       
    }

    void OnMouseExit()
    {  
       render.material.color = startColor;
    }

    public void SellTurrets() {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
    }

}
