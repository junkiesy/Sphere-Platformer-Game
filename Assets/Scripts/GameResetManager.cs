using UnityEngine;

public class GameResetManager : MonoBehaviour
{
    public PlayerMovement player;
    public CollectibleManager collectibleManager;
    private Vector3 playerStartPosition;

    void Start()
    {
        playerStartPosition = player.transform.position; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); 
        }
    }

    public void ResetGame()
    {
        
        player.transform.position = playerStartPosition;
        player.ResetPlayer();

        
        ScoreManager.instance.ResetScore();

        
        collectibleManager.ResetCollectibles();
        ResetEnemies();
    }

    void ResetEnemies()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
        foreach (EnemyMovement enemy in enemies)
        {
            enemy.ResetPosition();
        }
    }
}
