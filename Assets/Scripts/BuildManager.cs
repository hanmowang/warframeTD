using UnityEngine;
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node) {
        if (selectedNode == node) {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.setTarget(node);
    }
    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }
    public TurretBlueprint GetTurretToBuild () {
        return turretToBuild;
    }
}
