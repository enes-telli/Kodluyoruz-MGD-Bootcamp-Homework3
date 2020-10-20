using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isMyTurn = false;

    private bool isPassed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPassed)
        {
            if (isMyTurn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                isMyTurn = false;
                isPassed = true;
                CheckpointManager.instance.checkpoints.RemoveAt(0);
                if (CheckpointManager.instance.checkpoints.Count > 0)
                {
                    CheckpointManager.instance.checkpoints[0].isMyTurn = true;
                }
                else
                {
                    SceneLoader.instance.LoadNextScene();
                }
            }
            else
            {
                StartCoroutine(WrongCheckpointPassed());
            }
            
        }
    }

    IEnumerator WrongCheckpointPassed()
    {
        Color originalColor = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }
}
