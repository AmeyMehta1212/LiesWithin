using UnityEngine;

public class FakeEnding : MonoBehaviour
{
    public bool isFake = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isFake)
                Debug.Log("You've been tricked. Try again.");
            else
                Debug.Log("You found the truth.");
        }
    }
}
