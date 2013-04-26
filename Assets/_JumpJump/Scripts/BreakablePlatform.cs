using UnityEngine;
using System.Collections;

public class BreakablePlatform : MonoBehaviour {
	public Transform brittlePlatform;
	private ArrayList brittlePlatformList;
	private float SpawnPlatformRange = 0.0f;
	 private float nextPlatformCheck = 0.0f;
	
	// Use this for initialization
	void Start () {
		brittlePlatformList = new ArrayList();
		CreatePlatform (20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		
	void CreatePlatform(float height)
	{
		float platformHeight = height;
		while (platformHeight < SpawnPlatformRange)
		{
			float x = Random.Range (-10.0f, 9.0f);
			Vector3 platformPosition = new Vector3(x, platformHeight, 0.0f);
			
		     Transform bPlatform = (Transform)Instantiate(brittlePlatform, platformPosition, Quaternion.identity);
			brittlePlatformList.Add (bPlatform);
			platformHeight += 18;
		}
		SpawnPlatformRange = SpawnPlatformRange;
	}
}