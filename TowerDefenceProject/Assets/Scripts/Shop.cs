using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint nunTurret;
    
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectChurchTower()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void NunTurret()
    {
        buildManager.SelectTurretToBuild(nunTurret);
    }
}
