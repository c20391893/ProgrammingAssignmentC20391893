using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsPlacer : MonoBehaviour
{

    public GameManager gm;
	public GameObject Coins;

    // Start is called before the first frame update

    private void Start()
    {
		gm.Start();
	UpdateSceneFromManager();
		//for (int i = 0; i < 5; i++)
		//{
			// Create 20 coins on a 20x20 grid
			//Instantiate(Resources.Load("Coin"), new Vector3(Random.Range(-24.0f, 24.0f), 1.0f, Random.Range(-24.0f, 24.0f)), Quaternion.identity);
		//}
	}
	public void SaveFromSceneToManager()
	{

	
		gm.gameStatus.Coins.Clear();

	
		GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

	
		for (int i = 0; i < coins.Length; i++)
		{

			// Update each ball position in the Game Manager with the vale from the scene
			gm.gameStatus.Coins.Add(coins[i].transform.position);
		}
	}
	void UpdateSceneFromManager()
	{
		List<GameObject> CoinsList = new List<GameObject>();
		foreach(Vector3 coinPos in gm.gameStatus.Coins)
        {
			GameObject coinobject = Instantiate(Coins, coinPos, Quaternion.identity) as GameObject;
			CoinsList.Add(coinobject);
        }
		


	}
	// Update is called once per frame



	
}
