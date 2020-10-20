using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.checkpoints[0].isMyTurn = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
