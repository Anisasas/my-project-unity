using UnityEngine;

public class EndZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MazePlayerMove>() != null) // Tikrina, ar įėjo žaidėjas pagal skriptą
        {
            Debug.Log("Reached End Zone!");
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
                gm.WinGame();
        }
    }
}

