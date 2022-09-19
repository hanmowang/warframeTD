using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint blueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;



    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {    
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        } 
        if (!buildManager.canBuild) {
            Debug.Log("No Turret Selected!");
            return;
        }
        
        buildTurret(buildManager.GetTurretToBuild());
    }
    public Vector3 getBuildPosition() {
        return transform.position + positionOffset;
    }

    void buildTurret(TurretBlueprint _blueprint) {

        if (PlayerStats.Money < _blueprint.cost) {
            Debug.Log("too broke to build");
            return;
        }
        PlayerStats.Money -= _blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(_blueprint.prefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        blueprint = _blueprint;
        Debug.Log("Money left: " + PlayerStats.Money);
    }

    public void UpgradeTurret() {
        if (PlayerStats.Money < blueprint.upgradeCost) {
            Debug.Log("too broke to upgrade ");
            return;
        }
        PlayerStats.Money -= blueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(blueprint.upgradePrefab, getBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret upgraded!");
    }

    public void SellTurret() 
    {
        PlayerStats.Money += blueprint.sellAmount;
        isUpgraded = false;
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f); 

        Destroy(turret);
        blueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (!buildManager.canBuild) {
            return;
        }
        if (buildManager.hasMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}