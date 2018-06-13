using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager {

    public List<Building> buildingList = new List<Building>();
    public Dictionary<string, Building> buildingDic = new Dictionary<string, Building>();
    public MaskPoint[,] maskPointArray;

    public List<int[]> BuildingColorTypes = new List<int[]>();

    public Dictionary<int, int[]> BuildingTypeDic = new Dictionary<int, int[]>();
    public enum BuildingType
    {
        building1,
		building2,
		building3,
		building4,
		building5,
		building6,
		building7,

    }

    public BuildingManager()
    {
        //BuildingColorTypes.Add(new int[]{ 1,1,1,1});
		BuildingTypeDic[0] = new int[] { 2, 0, 0, 0 };
		BuildingTypeDic[1] = new int[] { 2, 0, 0, 1};
		BuildingTypeDic[2] = new int[] { 2, 0, 1, 0 };
		BuildingTypeDic[3] = new int[] { 2,0,1,1 };
		BuildingTypeDic[4] = new int[] { 2,1,0,0};
		BuildingTypeDic[5] = new int[] { 2,1,0,1};
		BuildingTypeDic[6] = new int[] { 2,1,1,0 };
		BuildingTypeDic[7] = new int[] { 2,1,1,1 };
		BuildingTypeDic[8] = new int[] { 2,2,0,0 };
		BuildingTypeDic[9] = new int[] { 2,2,0,1 };
		BuildingTypeDic[10] = new int[] { 2,2,1,0 };
		BuildingTypeDic[11] = new int[] { 2,2,1,1 };
		BuildingTypeDic[12] = new int[] { 2,0,2,0 };
		BuildingTypeDic[13] = new int[] { 2,0,2,1 };
		BuildingTypeDic[14] = new int[] { 2,1,2,1 };
		BuildingTypeDic[15] = new int[] { 2,2,2,0 };
		BuildingTypeDic[16] = new int[] { 2,2,2,1 };
		BuildingTypeDic[17] = new int[] { 0,0,0,1 };
		BuildingTypeDic[18] = new int[] { 0,0,1,1 };
		BuildingTypeDic[19] = new int[] { 0,1,0,1 };
		BuildingTypeDic[20] = new int[] { 0,1,1,1 };
    }

    public void ShowBuildings(MaskPoint[,] maskPointArray)
    {
        //for(int i=0;i<maskPointArray.GetLength(0);i++)
        //{
        //    for(int j=0;j<maskPointArray.GetLength(1);j++)
        //    {
        //        if(maskPointArray[i, j]!=null&& buildingDic.ContainsKey(maskPointArray[i, j].cubeIndex))
        //        {
        //            Building building = buildingDic[maskPointArray[i, j].cubeIndex];
        //            if (building != null && !building.maskPoint.Contains(maskPointArray[i, j]))
        //            {
        //                building.maskPoint.Add(maskPointArray[i, j]);
        //            }
        //        }
                
        //    }
        //}

        //foreach(Building building in buildingList)
        //{
        //    building.Show();
        //}
    }

    public void ShowBuildings(List<ScannerGridGroup> groupList)
    {
        foreach(ScannerGridGroup group in groupList)
        {
            if(!string.IsNullOrEmpty( group.buildingID) && buildingDic.ContainsKey(group.buildingID) )
            {
                buildingDic[group.buildingID].Show(group);
            }
        }
    }

    public void AddBuilding(Building building)
    {
        if(!buildingList.Contains(building))
        {
            buildingList.Add(building);
        }
        
        if(!buildingDic.ContainsKey(building.index))
        {
            buildingDic[building.index] = building;
        }
    }
}
