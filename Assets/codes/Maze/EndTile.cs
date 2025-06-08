using UnityEngine;

public class EndTile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Reached end!");
            GameObject.Find("GameManager").GetComponent<GameManager>().WinGame();
        }
    }
}
