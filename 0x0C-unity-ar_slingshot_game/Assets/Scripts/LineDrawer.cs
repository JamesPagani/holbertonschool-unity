using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    ///<summary>Amount of vertices the line has.</summary>
    public int vertexAmount;
    ///<summary>Amount of time before placing another vertix.</summary>
    public float interval;

    private LineRenderer _lineRender;

    void Start()
    {
        _lineRender = GetComponent<LineRenderer>();
    }

    public void DrawLine(Vector3 start, Vector3 pull, float slingForce)
    {
        _lineRender.positionCount = vertexAmount;
        List<Vector3> vertices = new List<Vector3>();
        Vector3 startingVelocity = pull * slingForce;
        

        for (float t = 0; t < vertexAmount; t += interval)
        {
            Vector3 newVertex = start + t * startingVelocity;
            newVertex.y = start.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            vertices.Add(newVertex);
        }
        _lineRender.SetPositions(vertices.ToArray());
    }

    public void Toggle()
    {
        if (_lineRender.enabled)
            _lineRender.enabled = false;
        else
            _lineRender.enabled = true;
    }
}
