using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class Building : MonoBehaviour
{
    public string index;
    //public List<MaskPoint> maskPoint = new List<MaskPoint>();
    public ScannerGridGroup gridGroup;
    public int showColorId;

    public List<Building> linkedBuildingList;

    void Awake()
    {
        index = this.gameObject.name;
        if (this.GetComponent<MeshRenderer>() != null)
        {
            SingletonT<BuildingManager>.Instance.AddBuilding(this);
            showColorId = -1;
        }

        Clear();
    }

    public void SetBuildingData()
    {
        JObject jo = SingletonTMono<Scanners>.Instance.buildingSettingJO;
        if (jo[index] == null)
        {
            //Debug.Log("SetBuildingData......." + index);
            return;
        }
        Debug.Log("SetBuildingData......." + index);
        List<string> obj = jo[index].ToObject<List<string>>();
        for (int i = 0; i < obj.Count; i++)
        {   

            if (SingletonT<BuildingManager>.Instance.buildingDic.ContainsKey(obj[i]))
            {
                
                linkedBuildingList.Add(SingletonT<BuildingManager>.Instance.buildingDic[obj[i].ToString()]);
            }else
            {
                Debug.Log("@@@@@1!!!!!"+obj[i]);
            }

        }
    }

    public Color HexToColor(string hex)
    {
        byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        float r = br / 255f;
        float g = bg / 255f;
        float b = bb / 255f;
        //float a = cc / 255f;
        return new Color(r, g, b, 1);
    }


    public void Show(ScannerGridGroup gridGroup)
    {
        int[] groupCode = gridGroup.GetGroupCode();
        bool isShow = true;

        foreach (KeyValuePair<int, int[]> keyValue in SingletonT<BuildingManager>.Instance.BuildingTypeDic)
        {
            isShow = true;
            for (int offset = 0; offset < 4; offset++)
            {
                isShow = true;
                for (int i = 0; i < 4; i++)
                {
                    int s = (offset + i) % 4;
                    if (groupCode[s] != keyValue.Value[i])
                    {
                        isShow = false;
                        break;
                    }
                }

                if (isShow)
                {
                    break;
                }
            }

            if (isShow)
            {
                Show(keyValue.Key);
                break;
            }
        }

        if (!isShow)
        {
            Show(-1);
        }
    }


    public void Show(int colorId)
    {
        if (this.showColorId != colorId)
        {
            if (SingletonTMono<Scanners>.Instance.inShowDock && this.index != "S2B203")
            {
                return;
            }

            this.Clear();

            
            foreach (Building building in this.linkedBuildingList)
            {
                building.Clear();
            }

            
            //if (true) {
            ShowTexture(colorId, 1);
            this.showColorId = colorId;
            foreach (Building building in this.linkedBuildingList)
            {
                building.SetColor(colorId);
            }

            if (this.index == "S2B203")
            {
                SingletonTMono<Scanners>.Instance.ShowDock0(colorId);
            }
            else if (colorId >= 2 && colorId < 8)
            {
                if (linkedBuildingList.Count > 1)
                {
                    linkedBuildingList[1].ShowTexture(colorId, 3);
                }
            }
            else if (colorId >= 8 && colorId < 20)
            {
                if (linkedBuildingList.Count > 0)
                {
                    linkedBuildingList[0].ShowTexture(colorId, 2);
                }

                if (linkedBuildingList.Count > 1)
                {
                    linkedBuildingList[1].ShowTexture(colorId, 3);
                }

                if (linkedBuildingList.Count > 2)
                {
                    linkedBuildingList[2].ShowTexture(colorId, 4);
                }
            }
        }
    }

    private void ShowTexture(int textureId, int index, bool showTexture = true)
    {
        SetColor(textureId);

        if (textureId == -1 || !showTexture)
        {
            Tool.GetChildInDepth("Quad", this.gameObject).gameObject.SetActive(false);
        }
        else {
            Tool.GetChildInDepth("Quad", this.gameObject).gameObject.SetActive(true);
            Tool.GetChildInDepth("Quad", this.gameObject).GetComponent<MeshRenderer>().material.mainTexture = (Texture)Resources.Load("Pic/L" + textureId + "-" + index);
        }

    }

    public void Clear()
    {
        if (Tool.GetChildInDepth("Quad", this.gameObject) != null)
            Tool.GetChildInDepth("Quad", this.gameObject).gameObject.SetActive(false);
        if (this.GetComponent<MeshRenderer>() != null)
            this.GetComponent<MeshRenderer>().material.color = HexToColor("DF0B37");

    }

    public void SetColor(int textureId)
    {
        string colorString = "DF0B37";
        switch (textureId)
        {
            case -1:
                colorString = "DF0B37";
                break;
            case 2:
                colorString = "D62797";
                break;
            case 3:
                colorString = "2D6042";
                break;
            case 4:
                colorString = "8C530E";
                break;
            case 5:
                colorString = "C11E1E";
                break;
            case 6:
                colorString = "1C55BA";
                break;
            case 7:
                colorString = "F4CD0B";
                break;
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
                colorString = "9842F4";
                break;
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
                colorString = "D67205";
                break;
        }
        this.GetComponent<MeshRenderer>().material.color = HexToColor(colorString);
    }
}
