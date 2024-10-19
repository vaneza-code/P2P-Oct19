//using UnityEngine;

//public class DragScript : MonoBehaviour
//{
//    public enum DragDirection { Free, Horizontal, Vertical }
//    public DragDirection dragDirection = DragDirection.Free;
//    public float snapDistance = 0.5f;
//    public delegate void DragEndedDelegate(Transform transform);
//    public DragEndedDelegate dragEndedDelegate;

//    public string objectColorHex; // Assign this in the Inspector

//    private Camera cam;
//    private Vector3 offset;
//    private bool holding;
//    private float zDepth;
//    private bool isSnapped;
//    private GameObject closestSnapTarget;

//    void Start()
//    {
//        cam = Camera.main;
//    }

//    void Update()
//    {
//        if (holding && !isSnapped)
//        {
//            Vector3 mousePos = Input.mousePosition;
//            mousePos.z = zDepth;
//            Vector3 newPos = cam.ScreenToWorldPoint(mousePos) + offset;

//            if (dragDirection == DragDirection.Horizontal)
//                newPos.y = transform.position.y;
//            else if (dragDirection == DragDirection.Vertical)
//                newPos.x = transform.position.x;

//            transform.position = newPos;

//            float closestDistance = float.MaxValue;
//            GameObject[] snapTargets = GameObject.FindGameObjectsWithTag("SnapTarget");

//            foreach (var snapTarget in snapTargets)
//            {
//                SnapTarget target = snapTarget.GetComponent<SnapTarget>();
//                if (target != null && target.targetColorHex == objectColorHex)
//                {
//                    float distance = Vector3.Distance(transform.position, snapTarget.transform.position);
//                    Debug.Log($"Checking distance from {transform.name} to {snapTarget.name}: {distance}");

//                    if (distance < closestDistance)
//                    {
//                        closestDistance = distance;
//                        closestSnapTarget = snapTarget;
//                    }
//                }
//            }

//            if (closestSnapTarget != null && closestDistance <= snapDistance)
//            {
//                Debug.Log($"Snapping {transform.name} to {closestSnapTarget.name} at distance {closestDistance}");
//                transform.position = closestSnapTarget.transform.position;
//                isSnapped = true;
//            }
//            else
//            {
//                Debug.Log($"{transform.name} not snapping, closest distance: {closestDistance}");
//            }

//            Debug.Log($"Dragging {transform.name} at position: {transform.position}");
//        }
//    }

//    void OnMouseDown()
//    {
//        holding = true;
//        zDepth = cam.WorldToScreenPoint(transform.position).z;
//        Vector3 mousePos = Input.mousePosition;
//        mousePos.z = zDepth;
//        offset = transform.position - cam.ScreenToWorldPoint(mousePos);
//    }

//    void OnMouseUp()
//    {
//        holding = false;

//        if (!isSnapped && dragEndedDelegate != null)
//        {
//            dragEndedDelegate(transform);
//        }
//    }

//    public void Unsnap()
//    {
//        isSnapped = false;
//    }
//}
