using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public Button upgradeButton;
    public TMP_Text upgradeCost;

    public TMP_Text sellAmount;

    public void setTarget(Node _target){
        target = _target;
        transform.position = target.getBuildPosition();
        if (target.isUpgraded == false) {
            upgradeCost.text = "$" + target.blueprint.upgradeCost;
            upgradeButton.interactable = true;
            sellAmount.text = "$" + target.blueprint.sellAmount;
        }
        
        if (target.isUpgraded) {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
            sellAmount.text = "$" + target.blueprint.upgradeSellAmount;
        }
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
