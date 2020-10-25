using UnityEngine;

public class LaserDisplay : MonoBehaviour
{
    public float lineWidth = 0.2f;
    public float lineLength = 2;
    public Color color = Color.white;
    public Material material;
    public float rotationSpeed = 0.1f;
    
    private LineRenderer _lineRenderer;
    
    Vector3 lineStart;

    void Awake()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.material = material;
        _lineRenderer.positionCount = 2;
        _lineRenderer.startWidth = lineWidth; _lineRenderer.material.SetColor("_Color", color);
        lineStart = transform.position;
        _lineRenderer.SetPosition(0, lineStart);
        drawLaser();
    }

    void Update()
    {
        if(rotationSpeed != 0)
        {
            drawLaser();
        }
    }

    private void drawLaser()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 lineEnd = transform.position + forward * lineLength;
        _lineRenderer.SetPosition(1, lineEnd);
        transform.Rotate(0, rotationSpeed, 0);
    }
}
