using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

namespace vwds.CreatAR
{
    public class ObjectCreationManager : MonoBehaviour
    {
        public static ObjectCreationManager Instance;
        public GameObject PointIndicatorPrefab;
        public GameObject CubeIndicatorPrefab;
        private GameObject cubeIndicatorInstance;
        private GameObject pointIndicatorInstance;
        private CreationState currentCreationState = CreationState.NoCreation;
        private bool isCreating;
        private Vector3 pointStart;
        private Vector3 pointEnd;
        private Vector3 lineRotation;
        private float widthSize = 0f;
        private float heightSize;
        private LineRenderer lineRenderer;
        private ARCameraManager arCameraManager;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                arCameraManager = FindObjectOfType<ARCameraManager>();
                Instance = this;
                transform.parent = arCameraManager.transform;
                transform.position = arCameraManager.transform.position;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isCreating)
            {
                RaycastHit hit;
                switch (currentCreationState)
                {
                    case CreationState.PointCreation:
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
                        {
                            pointIndicatorInstance.transform.position = hit.point;
                        }
                        break;
                    case CreationState.LineCreation:
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
                        {
                            drawLine(hit.point);
                            pointIndicatorInstance.transform.position = hit.point;
                        }
                        break;
                    case CreationState.SquareCreation:
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
                        {
                            drawSquare(hit.point);
                        }
                        break;
                    case CreationState.CubeCreation:
                        drawCube();
                        break;
                    case CreationState.CompleteCreation:
                        CreatARObjectsManager.Instance.AddObject(cubeIndicatorInstance);
                        EndCreating();
                        break;
                    default:
                        break;
                }
            }
        }

        private void FixedUpdate()
        {

        }

        [ContextMenu("StartCreating")]
        public void StartCreating()
        {
            isCreating = true;
            pointIndicatorInstance = Instantiate(PointIndicatorPrefab);
            currentCreationState = CreationState.StartCreation;
            //things related to between creation initialized and point creation
            currentCreationState = CreationState.PointCreation;
        }

        public void WhileCreating()
        {

        }

        public void EndCreating()
        {
            isCreating = false;
            currentCreationState = CreationState.NoCreation;
        }

        [ContextMenu(nameof(confirmPoint))]
        public void confirmPoint()
        {
            if (currentCreationState == CreationState.PointCreation)
            {
                pointStart = pointIndicatorInstance.transform.position;
            }

            NextCreationState();
            lineRenderer.enabled = true;
        }

        [ContextMenu(nameof(confirmLine))]
        public void confirmLine()
        {
            if (currentCreationState == CreationState.LineCreation)
            {
                pointEnd = pointIndicatorInstance.transform.position;
            }
            createSquare();
            NextCreationState();
            Destroy(pointIndicatorInstance);
            lineRenderer.enabled = false;
        }
        public void confirmSquare()
        {
            NextCreationState();
        }
        public void confirmCube()
        {
            NextCreationState();
        }
        public void createSquare()
        {
            cubeIndicatorInstance = Instantiate(CubeIndicatorPrefab);
            cubeIndicatorInstance.transform.position = pointStart;
            //cubeIndicatorInstance.transform.position = Vector3.Lerp(pointStart, pointEnd, 0.5f);
            cubeIndicatorInstance.transform.LookAt(pointEnd);
            cubeIndicatorInstance.transform.localScale = new Vector3(cubeIndicatorInstance.transform.localScale.x, cubeIndicatorInstance.transform.localScale.y, Vector3.Distance(pointStart, pointEnd));
        }
        private void drawLine(Vector3 newPoint)
        {
            lineRenderer.SetPositions(new Vector3[2] { pointStart, newPoint });
        }

        private void drawSquare(Vector3 point)
        {
            float distance = Vector3.Distance(pointStart, point);
            float angle = Vector3.SignedAngle(pointStart - pointEnd, pointStart - point, cubeIndicatorInstance.transform.up);
            widthSize = distance * Mathf.Sin(angle * Mathf.Deg2Rad);

            cubeIndicatorInstance.transform.localScale = new Vector3(widthSize, cubeIndicatorInstance.transform.localScale.y, cubeIndicatorInstance.transform.localScale.z);
        }

        private void drawCube()
        {
            cubeIndicatorInstance.transform.localScale = new Vector3(cubeIndicatorInstance.transform.localScale.x, transform.position.y - cubeIndicatorInstance.transform.position.y, cubeIndicatorInstance.transform.localScale.z);
            //cubeIndicatorInstance.transform.position = new Vector3(cubeIndicatorInstance.transform.position.x, cubeIndicatorInstance.transform.localScale.y / 2f, cubeIndicatorInstance.transform.position.z);
        }

        public void NextCreationState()
        {
            currentCreationState++;
        }
        private enum CreationState
        {
            NoCreation,
            StartCreation,
            PointCreation,
            LineCreation,
            SquareCreation,
            CubeCreation,
            CompleteCreation
        }
    }
}