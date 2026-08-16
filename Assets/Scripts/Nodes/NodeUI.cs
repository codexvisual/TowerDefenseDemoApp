using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    private Node target;

    public GameObject uiCanvass;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    public void SetTarget(Node t) {
        target = t;

        transform.position = target.GetBuildPosition();
       
        if (!target.isUpgaded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "Upgraded";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        uiCanvass.SetActive(true);
    }

    public void Hide() {
        uiCanvass.SetActive(false);
    }

    public void Upgrade() {
        target.UpgardeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() {
        target.SellTurrets();
        BuildManager.instance.DeselectNode();
    }
}
