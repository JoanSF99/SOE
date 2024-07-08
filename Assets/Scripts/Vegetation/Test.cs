using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float radius = 100;
    public int rejectionSamples = 30;
    public float displayRadius = 1;
    public MeshFilter meshFilter; // Referencia al MeshFilter
    public HeightMap heightMap; // Referencia al HeightMap

    private Vector3 regionSize; // Ahora es una variable privada
    List<Vector3> points; // Ahora es una lista de Vector3

    void OnValidate()
    {
        // Obtiene el tamaño del plano
        Renderer renderer = meshFilter.GetComponent<Renderer>();
        regionSize = new Vector3(renderer.bounds.size.x, renderer.bounds.size.y, renderer.bounds.size.z);

        // Pasa el HeightMap a GeneratePoints
        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, heightMap, rejectionSamples);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(regionSize / 2, regionSize);
        if (points != null)
        {
            foreach (Vector3 point in points)
            {
                Gizmos.DrawSphere(point, displayRadius);
            }
        }
    }
}
