using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private Vector3[] initialCollectiblePositions;
    private GameObject[] collectibles;
    private GameObject[] initialCollectibles;

    void Start()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        initialCollectiblePositions = new Vector3[collectibles.Length];
        initialCollectibles = new GameObject[collectibles.Length];

        for (int i = 0; i < collectibles.Length; i++)
        {
            initialCollectiblePositions[i] = collectibles[i].transform.position;
            initialCollectibles[i] = collectibles[i];
        }
    }

    public void ResetCollectibles()
    {
        for (int i = 0; i < collectibles.Length; i++)
        {
            if (collectibles[i] == null)
            {
                collectibles[i] = Instantiate(initialCollectibles[i], initialCollectiblePositions[i], Quaternion.identity);
            }
            else
            {
                collectibles[i].transform.position = initialCollectiblePositions[i];
                collectibles[i].SetActive(true);
            }
        }
    }
}
