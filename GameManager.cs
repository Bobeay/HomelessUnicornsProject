using UnityEngine;
using TMPro; 
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    public TextMeshProUGUI evoPointsDisplay; 
    public TextMeshProUGUI dateText;        
    public GameObject strategyMenu;          
    public TextMeshProUGUI lakeButtonText;   

    [Header("Game Data")]
    public float evoPoints = 5f; 

    [Header("World Objects")]
    public GameObject riverObject;   
    public Material blueWaterMat;    
    public GameObject landObject;    
    public Material greenGrassMat;  
    public GameObject humanPrefab;   

    void Awake() 
    { 
        if (Instance == null) Instance = this; 
    }

    void Update()
    {
     
        DateTime currentDate = new DateTime(3333, 1, 1).AddDays(Time.timeSinceLevelLoad / 50f);
        if (dateText != null) 
            dateText.text = currentDate.ToString("MMM dd, yyyy").ToUpper();

   
        if (evoPointsDisplay != null) 
            evoPointsDisplay.text = Mathf.FloorToInt(evoPoints) + " EVO";
    }

  

    public void ToggleMenu() 
    { 
        if(strategyMenu != null) 
            strategyMenu.SetActive(!strategyMenu.activeSelf); 
    }

    public void Action_HealLand() 
    {
        if (evoPoints >= 2) 
        {
            evoPoints -= 2;
            
          
            if (landObject != null)
            {
                Terrain terrain = landObject.GetComponent<Terrain>();
                if (terrain != null && greenGrassMat != null)
                {
                    terrain.materialTemplate = greenGrassMat;
                }
            }
        }
    }

    public void Action_PurifyLake()
    {
        if (evoPoints >= 2) 
        {
            evoPoints -= 2;
            if (riverObject != null && blueWaterMat != null)
                riverObject.GetComponent<Renderer>().material = blueWaterMat;
        }
    }

    public void Action_SpawnHuman() 
    {
        if (evoPoints >= 1) 
        {
            evoPoints -= 1;
            if (humanPrefab != null)
            {
        
                Instantiate(humanPrefab, new Vector3(0, 5, 0), Quaternion.identity);
            }
        }
    }
}