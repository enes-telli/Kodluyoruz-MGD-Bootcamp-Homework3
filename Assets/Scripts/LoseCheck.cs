using UnityEngine;

public class LoseCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneLoader.instance.LoadCurrentScene();
        }
    }
}
