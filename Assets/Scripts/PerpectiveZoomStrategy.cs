using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpectiveZoomStrategy : IZoomStrategy {

    Vector3 normalizedCameraPosition;
    float currentZoomLevel;

    public PerpectiveZoomStrategy(Camera cam, Vector3 offset, float startingZoom) {
        normalizedCameraPosition = new Vector3(0f, Mathf.Abs(offset.y), -Mathf.Abs(offset.x)).normalized;
        currentZoomLevel = startingZoom;
        PositionCamera(cam);
    }

    private void PositionCamera(Camera cam) {
        cam.transform.localPosition = normalizedCameraPosition * currentZoomLevel;
    }

    public void ZoomIn(Camera cam, float delta, float zoomLimit) {
        if (currentZoomLevel <= zoomLimit)
            return;
        currentZoomLevel = Mathf.Max(currentZoomLevel - delta, zoomLimit);
        PositionCamera(cam);
    }

    public void ZoomOut(Camera cam, float delta, float zoomLimit) {
        if (currentZoomLevel >= zoomLimit)
            return;
        currentZoomLevel = Mathf.Min(currentZoomLevel + delta, zoomLimit);
        PositionCamera(cam);
    }

}

public interface IZoomStrategy {
}