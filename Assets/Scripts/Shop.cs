using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;

    void Start () {
        buildManager = BuildManager.instance;
        standardTurret.costText.text = "$" + standardTurret.cost.ToString();
        missileLauncher.costText.text = "$" + missileLauncher.cost.ToString();
        laserBeamer.costText.text = "$" + laserBeamer.cost.ToString();
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectedMissileLauncher() {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectedLaserBeamer() {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
