using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerGrid : MonoBehaviour {

    private Texture2D hitTex;

    private ColorClassifier colorClassifier;

    public int scannerId;
    public Color color;

    void Start () {
		
	}

    public int UpdateColor()
    {
        RaycastHit hit;
        hitTex = SingletonTMono<Scanners>.Instance.hitTex;
        colorClassifier = SingletonTMono<Scanners>.Instance.colorClassifier;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 6))
        {
            // Get local tex coords w.r.t. triangle
            if (!hitTex)
            {
                Debug.Log("No hit texture");
                GetComponent<Renderer>().material.color = Color.magenta;
                return -1;
            }
            else
            {
                int _locX = Mathf.RoundToInt(hit.textureCoord.x * hitTex.width);
                int _locY = Mathf.RoundToInt(hit.textureCoord.y * hitTex.height);
                Color pixel = hitTex.GetPixel(_locX, _locY);
                int currID = colorClassifier.GetClosestColorId(pixel);

                //if (isGrid)
                //{
                //    if (_useBuffer)
                //        currID = GetIdAverage(i, j, currID);

                //    // Save colors for 3D visualization
                //    if (setup || _isCalibrating)
                //        allColors[i + numOfScannersX * j] = pixel;
                //}

                Color minColor;

                // Display 3D colors & use scanned colors for scanner color
                //if (SingletonTMono<Scanners>.Instance._isCalibrating && isGrid)
                if (SingletonTMono<Scanners>.Instance._isCalibrating)
                {
                    minColor = pixel;
                }
                else
                    minColor = colorClassifier.GetColor(currID);

                if (SingletonTMono<Scanners>.Instance._showDebugLines)
                {
                    // Could improve by drawing only if sphere locations change
                    Vector3 origin = SingletonTMono<Scanners>.Instance._colorSpaceParent.transform.position;
                    Debug.DrawLine(origin + new Vector3(pixel.r, pixel.g, pixel.b), origin + new Vector3(SingletonTMono<Scanners>.Instance.sampleColors[currID].r, SingletonTMono<Scanners>.Instance.sampleColors[currID].g, SingletonTMono<Scanners>.Instance.sampleColors[currID].b), pixel, 1, false);
                }

                // Display rays cast at the keystoned quad
                if (SingletonTMono<Scanners>.Instance._showRays)
                {
                    Debug.DrawLine(transform.position, hit.point, pixel, 200, false);
                    Debug.Log(hit.point);
                }

                // Paint scanner with the found color 
                GetComponent<Renderer>().material.color = minColor;
                color = minColor;
                return currID;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.magenta; //paint scanner with Out of bounds / invalid  color 
            return -1;
        }
    }

}
