using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public float buffer;

    private Camera _cam;

    public void CenterCamera()
    {
        _cam = GetComponent<Camera>();
        var (center, size) = CalculateOrthoSize();
        _cam.transform.position = center;
        _cam.orthographicSize = size;
    }

    private (Vector3 center, float size) CalculateOrthoSize()
    {
        Bounds bounds = new Bounds();

        foreach (var col in MapManager.Instance.tilesColliders)
        bounds.Encapsulate(col.bounds);

        bounds.Expand (buffer);

        float vertical = bounds.size.y;

        float horizontal = bounds.size.x * _cam.pixelHeight / _cam.pixelWidth;

        float size = Mathf.Max(horizontal, vertical) * 0.5f;
        Vector3 center = bounds.center + new Vector3(0, 10, 0);

        return (center, size);
    }
}
