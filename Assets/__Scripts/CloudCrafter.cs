using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{

    public int numClouds = 40;
    public GameObject[] cloudPrefabs;
    public Vector3 cloudPosMin;
    public Vector3 cloudPosMax;
    public float cloudScaleMin = 1;
    public float cloudScaleMax = 5;
    public float cloudSpeedMult = 0.5f;

    public GameObject[] cloudInstances;

    void Awake()
    {
        cloudInstances = new GameObject[numClouds];
        GameObject anchor = GameObject.Find("CloudAnchor");
        GameObject cloud;
        for (int i = 0; i < numClouds; i++)
        {
            int prefabNum = Random.Range(0, cloudPrefabs.Length);
            cloud = Instantiate(cloudPrefabs[prefabNum]) as GameObject;
            Vector3 cpos = Vector3.zero;
            cpos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cpos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);
            cpos.y = Mathf.Lerp(cloudPosMin.y, cpos.y, scaleU);
            cpos.z = 100 - 90 * scaleU;
            cloud.transform.position = cpos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            cloud.transform.parent = anchor.transform;
            cloudInstances[i] = cloud;


        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    foreach (GameObject cloud in cloudInstances)
	    {
	        float scaleVal = cloud.transform.localScale.x;
	        Vector3 cpos = cloud.transform.position;
	        cpos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
	        if (cpos.x <= cloudPosMin.x)
	        {
	            cpos.x = cloudPosMax.x;
	        }
	        cloud.transform.position = cpos;


	    }

    }
}
