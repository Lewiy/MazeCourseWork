using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;
	private Maze mazeInstance;

	public Player playerPrefab;
	private Player playerInstance;
    private GameObject[] players;                                                                                                    
	// Use this for initialization
	private void Start () {
        //playerPrefab = new Player();
		StartCoroutine(BeginGame());	
	}
	
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}

	private IEnumerator BeginGame() {
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        mazeInstance = Instantiate(mazePrefab) as Maze;
        //playerInstance = Instantiate(playerPrefab) as Player;
        // playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
		yield return StartCoroutine (mazeInstance.Generate());
        players = GameObject.FindGameObjectsWithTag("Player");
         playerInstance = (Player)players[0];
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        //StartCoroutine(mazeInstance.Generate());

    }
	
	private void RestartGame() {
		
		StopAllCoroutines();
		if (playerInstance != null) {
			Destroy(mazeInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}

}
