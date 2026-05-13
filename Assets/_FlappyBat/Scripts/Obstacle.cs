using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Add points
        ScoreBehaviour.Instance.AddScore();
    }
}
