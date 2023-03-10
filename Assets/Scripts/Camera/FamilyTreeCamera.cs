using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyTreeCamera : MonoBehaviour
{

    [SerializeField] public Camera m_camera;

    [HideInInspector] private Vector3 resetCamera;
    [HideInInspector] private Vector3 origin;
    [HideInInspector] private Vector3 difference;

    [SerializeField] public float zoomLevel;
    [SerializeField] public float zoomSmoothFactor;
    [SerializeField] public float maxZoomIn, maxZoomOut;

    void Start()
    {
        resetCamera = m_camera.transform.position; //Records original position of Camera
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DragCameraPosition());
        }

        if(Input.mouseScrollDelta.y != 0)
        {
            StartCoroutine(ZoomCameraScale());
        }

        if(Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Space))
        {
            ResetCamera(); //Resets Camera to default
        }
    }

    Vector3 MouseToWorldPosition()
    {
        return m_camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private IEnumerator DragCameraPosition()
    {
        origin = MouseToWorldPosition();

        while(Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = MouseToWorldPosition();
            difference = currentMousePosition - origin;

            m_camera.transform.Translate(-difference, Space.World);

            yield return null;
        }
    }

    private IEnumerator ZoomCameraScale()
    {
        m_camera.orthographicSize -= zoomLevel * Time.deltaTime * zoomSmoothFactor * Input.mouseScrollDelta.y;

        m_camera.orthographicSize = Mathf.Clamp(m_camera.orthographicSize, maxZoomIn, maxZoomOut);

        yield return null;
    }

    public void ResetCamera()
    {
        m_camera.transform.position = resetCamera;
    }
}
