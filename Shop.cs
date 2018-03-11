using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

    }

    public void SelectStandardTurret ()
    {
        Debug.Log("Turret");
        buildManager.SelectTurretToBuild(standardTurret);
        

    }

    public void SelectAnotherTurret ()
    {
        buildManager.SelectTurretToBuild(anotherTurret);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
    }

    private void OnMouseExit()
    {
        Debug.Log("Exit");
        Destroy(gameObject);
    }

}
