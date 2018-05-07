using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public int index;
    public List<MaskPoint> maskPoint = new List<MaskPoint>();

   

    void Awake()
    {
        SingletonT<BuildingManager>.Instance.AddBuilding(this);

    }

	void Start () {
		
	}
	
	
    public void Show()
    {
        foreach(KeyValuePair<BuildingManager.BuildingType, int[]> keyValue in SingletonT<BuildingManager>.Instance.BuildingTypeDic)
        {
            bool isShow = true;
            for(int i=0;i<4;i++)
            {
                if(GetMaskByIndex(i)!=null&&GetMaskByIndex(i).currID != keyValue.Value[i])
                {
                    isShow = false;
                    break;
                }
                
            }

            if(isShow)
            {
                Show(keyValue.Key);
                break;
            }
        }
    }

    private void Show(BuildingManager.BuildingType buildingType)
    {
        switch(buildingType)
        {
            case BuildingManager.BuildingType.normal:
                this.GetComponent<MeshRenderer>().material.color = Color.white;
                break;
            case BuildingManager.BuildingType.Office:
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
        }
    }

    public MaskPoint GetMaskByIndex(int cubeInnerIndex)
    {
       return  maskPoint.Find(a => cubeInnerIndex == a.innerCubeIndex);
    }
}
