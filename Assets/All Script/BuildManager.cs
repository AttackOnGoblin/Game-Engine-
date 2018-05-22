using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject standardTurretPrefab;
    public GameObject MissileLauncherPrefab;

    private TurretBlueprint turretToBuild;

	public bool CanBuild { get { return turretToBuild != null; } }
    public bool HaveMoney { get { return PLayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PLayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money"); 
            return;
        }

        PLayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money Left" + PLayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
   
}

