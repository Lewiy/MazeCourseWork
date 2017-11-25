using UnityEngine;
using System.Collections;
using UnityEditor;

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
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine (mazeInstance.Generate());
        Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Player.prefab", typeof(GameObject));
        playerInstance = Instantiate(prefab) as Player;
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
       

    }
	
	private void RestartGame() {
		
		StopAllCoroutines();
		if (playerInstance != null) {
			Destroy(mazeInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}

}
