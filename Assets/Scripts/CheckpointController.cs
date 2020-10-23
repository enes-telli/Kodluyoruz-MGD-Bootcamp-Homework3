using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] GameObject[] checkpoints;
    [SerializeField] Color[] colors = new Color[2];  // transition from first color to last color

    float[] coordinates = new float[] { -12, -6, 0, 6, 12 };
    List<Vector3> list = new List<Vector3>();

    const float SPAWNING_HEIGHT = -0.9f;

    private void Awake()
    {
        SetThePositions();
        SetTheColors();
        Destroy(this);
    }

    private void SetThePositions()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            bool validPosition = false;
            Vector3 position = Vector3.zero;

            while (!validPosition)
            {
                position = new Vector3(coordinates[Random.Range(0, coordinates.Length)], SPAWNING_HEIGHT, coordinates[Random.Range(0, coordinates.Length)]);
                validPosition = true;
                if (!list.Contains(position))
                {
                    list.Add(position);
                } 
                else
                {
                    validPosition = false;
                }
            }
            checkpoints[i].transform.position = position;
        }
    }

    private void SetTheColors()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].GetComponent<Renderer>().material.color = Color.Lerp(colors[0], colors[1], (float)(i + 1) / (checkpoints.Length + 1));
        }
    }

}

