using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab;
    [SerializeField] [Range(10, 100)] int resolution = 10;

    private Transform[] points;


    private void Awake()
    {
        points = new Transform[resolution];

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = new Vector3();

        for(int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step -1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            point.gameObject.name = "Point X: " + point.position.x + " Y: " + point.position.y;

            points[i] = point;
        }
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * position.x + Time.time);
            point.localPosition = position;
        }
    }
}
