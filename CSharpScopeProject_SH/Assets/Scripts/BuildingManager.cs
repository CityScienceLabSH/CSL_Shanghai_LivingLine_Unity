using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager {

    public List<Building> buildingList = new List<Building>();
    public Dictionary<int, Building> buildingDic = new Dictionary<int, Building>();
    public MaskPoint[,] maskPointArray;

    public List<int[]> BuildingColorTypes = new List<int[]>();

    public Dictionary<BuildingType, int[]> BuildingTypeDic = new Dictionary<BuildingType, int[]>();
    public enum BuildingType
    {
        normal,
        Office
    }

    public BuildingManager()
    {
        //BuildingColorTypes.Add(new int[]{ 1,1,1,1});

        BuildingTypeDic[BuildingType.normal] = new int[] { 1, 1, 1, 1 };
        BuildingTypeDic[BuildingType.Office] = new int[] { 0, 1, 0, 1 };
    }

    public void ShowBuildings(MaskPoint[,] maskPointArray)
    {
        for(int i=0;i<maskPointArray.GetLength(0);i++)
        {
            for(int j=0;j<maskPointArray.GetLength(1);j++)
            {
                if(maskPointArray[i, j]!=null&& buildingDic.ContainsKey(maskPointArray[i, j].cubeIndex))
                {
                    Building building = buildingDic[maskPointArray[i, j].cubeIndex];
                    if (building != null && !building.maskPoint.Contains(maskPointArray[i, j]))
                    {
                        building.maskPoint.Add(maskPointArray[i, j]);
                    }
                }
                
            }
        }

        foreach(Building building in buildingList)
        {
            building.Show();
        }
    }

    public void AddBuilding(Building building)
    {
        if(!buildingList.Contains(building))
        {
            buildingList.Add(building);
        }
        
        if(buildingDic.ContainsKey(building.index))
        {
            buildingDic[building.index] = building;
        }
    }
}
