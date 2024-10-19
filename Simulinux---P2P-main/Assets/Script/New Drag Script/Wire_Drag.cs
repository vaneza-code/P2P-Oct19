using UnityEngine;

public class WireDrag : MonoBehaviour
{
    private Vector3 startPos;
    private bool dragging = false;
    public Transform connectedEnd; // The end point to snap to
    public Color wireColor; // Assign the wire color in the inspector

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;

        // Check if connected to the correct end point
        if (connectedEnd && Vector3.Distance(transform.position, connectedEnd.position) < 0.5f)
        {
            transform.position = connectedEnd.position;
            GameController.Instance.CheckConnection(wireColor, connectedEnd.GetComponent<WireEnd>().wireColor);
        }
        else
        {
            transform.position = startPos;
        }
    }

    void Update()
    {
        if (dragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // Distance from the camera
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}
