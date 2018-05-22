using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{

	public Color hoverColor;
    public Color notEnoughResourceColor;
	public Vector3 positionOffset;

    [HideInInspector]
	public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
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

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

	void OnMouseDown()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;

       
		if (turret != null)
		{
            buildManager.SelectNode(this);
			return;
		}

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
	}

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PLayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }

        PLayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        Debug.Log("Turret upgraded!");
    }

    public void UpgradeTurret()
    {
        if (PLayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not Enough Money to upgrade");
            return;
        }

        PLayerStats.Money -= turretBlueprint.upgradeCost;

        //Get Rid OF OLD TURRET
        Destroy(turret);

        //BUILD NEW
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret ()
    {
        PLayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
    }

	void OnMouseEnter()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HaveMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughResourceColor;
        }
        
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
    }

}