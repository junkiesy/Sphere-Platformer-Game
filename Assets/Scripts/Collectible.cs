using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(scoreValue);
            gameObject.SetActive(false); 
        }
    }
}
