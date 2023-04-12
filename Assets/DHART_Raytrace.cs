using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DHARTAPI;
using DHARTAPI.RayTracing;
using DHARTAPI.Geometry;
using UnityEngine.XR;

public class HFExampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create arrays for the plane's vertices and indices
        float[] plane_vertices = {
            -10f, 10f, 0f,
            -10f, -10f, 0f,
             10f, 10f, 0f,
             10f, -10f, 0f
        };
        int[] plane_indices = {
          3, 1, 0,
          2, 3, 0
        };

        // Construct a meshinfo instance for the plane
        MeshInfo Plane = new MeshInfo(plane_indices, plane_vertices);

        // Generate a BVH from the MeshInfo instance
        EmbreeBVH bvh = new EmbreeBVH(Plane);

        // Define origin and direction
        Vector3D origin = new Vector3D(1, 0, 1);
        Vector3D direction = new Vector3D(0, 0, -1);

        // Cast the ray, store the hitpoint
        Vector3D intersection_point = EmbreeRaytracer.IntersectForPoint(bvh, origin, direction);

        // Print the x, y, and z components of the intersection_point
        Debug.Log(
            "(" + intersection_point.x +
            "," + intersection_point.y +
            "," + intersection_point.z +
        ")");
    }

    // Update is called once per frame
    void Update()
    {

    }
}