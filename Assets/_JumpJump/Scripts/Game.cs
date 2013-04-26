using UnityEngine;
using System.Collections;

public enum GameState1
	{
		playing,
		gameover
	};

public class Game : MonoBehaviour
{

    public Transform platformPrefab;
    private Transform playerTransform;
		
    public static GameState1 gameState;
	
	private ArrayList platforms;
	
    private float platformsSpawnedUpTo = 0.0f;
    private float nextPlatformCheck = 0.0f;
	
	public int yPosition;
	void Awake ()
	{
		// gets the player through tag.
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		// create an array for the platforms.
        platforms = new ArrayList();
		
		// spawn new platforms with its range.
        CreatePlatforms(30.0f);
		// call start.
        Start();
	}

    void Start()
    {
		// realtime speed.
        Time.timeScale = 1.0f;
        gameState = GameState1.playing;
    }


	void Update ()
	{
        // adding new platforms update.
        float playerHeight = playerTransform.position.y;
        if (playerHeight > nextPlatformCheck)
        {
			// add new platforms.
            PlatformManager();
        }
		
		// updates camera position.
        float cameraPosition = transform.position.y;
        float currentCameraPosition = Mathf.Lerp(cameraPosition, playerHeight, Time.deltaTime * 10);
        	if (playerTransform.position.y > cameraPosition)
        	{
				// set camera position.
            	transform.position = new Vector3(transform.position.x, currentCameraPosition, transform.position.z);
        	}
			else
			{
				//player too low, call game over.
				if (playerHeight < (cameraPosition - 7.1))
					GameOver();
        	}
		// put some score here.
}
   

    void CreatePlatforms(float rangeHeight)
    {
        float platformHeight = platformsSpawnedUpTo;
        while (platformHeight <= rangeHeight)
        {
			// platform x constraint.
            float xRange = Random.Range(-10.0f, 9.0f);
			// platform range.
            Vector3 pos = new Vector3(xRange, platformHeight, 0.0f);
			
			// clones platforms.
            Transform plat = (Transform)Instantiate(platformPrefab, pos, Quaternion.identity);
			// adds clone to array.
            platforms.Add(plat);

            platformHeight += yPosition;
        }
        platformsSpawnedUpTo = rangeHeight; 
    }
	
	 void PlatformManager()
    {
		// add platforms if there are no more platforms 10 blocks from the player.
        nextPlatformCheck = playerTransform.position.y + 10;

        // destroy all platforms below.
        for(int i = platforms.Count - 1;		i>=0;		i--)
        {
			// get all platforms.
            Transform plat = (Transform)platforms[i];
			//check all platforms with this condition.
			if (plat.position.y < (transform.position.y - 4))
            {
				// destroy platform
                Destroy(plat.gameObject);
                platforms.RemoveAt(i);
            }            
        }

        //Spawn new platforms, 25 units in advance.
        CreatePlatforms(nextPlatformCheck + 25);
    }

	   void GameOver()
	{
		// pause time.
        Time.timeScale = 0.0f;
		// destroy player.
		Destroy(playerTransform.gameObject);
        gameState = GameState1.gameover;
    }

}