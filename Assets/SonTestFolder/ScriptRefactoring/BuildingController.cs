using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.InputSystem;

public class BuildingController : MonoBehaviour
{
    public StructureUIDataSO structureUIDataSO;
    public BuildUIDataSO objectData;

    private StructurePool pool;
    private GameObject pendingObject;
    private Transform parentObject;
    private Camera camera;
    private Vector3 position;
    private RaycastHit hit;
    private bool isHit;
    private bool isBuildingMode;
    private bool isMovingMode;
    private bool isDestroyMode;
    private bool isOpen;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float gridSize;
    [SerializeField] private float rotateAmount;


    private void Awake()
    {
        pool = GetComponent<StructurePool>();
        layerMask = LayerMask.GetMask("Ground");
    }

    private void OnEnable()
    {
        structureUIDataSO.OnObjectMoveEvent += OnMoveObject;
        structureUIDataSO.OnObjectDestroyEvent += OnDestroyObject;
        objectData.OnSelectedEvent += OnSelectObject;
    }

    private void OnDisable()
    {
        structureUIDataSO.OnObjectMoveEvent -= OnMoveObject;
        structureUIDataSO.OnObjectDestroyEvent -= OnDestroyObject;
        objectData.OnSelectedEvent -= OnSelectObject;
    }

    private void Start()
    {
        camera = Camera.main;
        pool.InitializedPool(objectData.selectableObjects.Count);
    }

    private void Update()
    {
        if (pendingObject == null && isMovingMode && !isDestroyMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectObjectToMove();
            }
        }
        else if (pendingObject != null && (isBuildingMode || isMovingMode))
        {
            pendingObject.transform.position = new Vector3(
                RoundToNearestGrid(position.x),
                RoundToNearestGrid(position.y),
                RoundToNearestGrid(position.z)
                );

            SetPositionOnGround();

            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }

        if (isDestroyMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DestroyStucture();
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            isHit = true;
            Vector3 _setPosition = hit.point;
            _setPosition = _setPosition + 0.5f * transform.forward;
            position = _setPosition;
        }
        else
        {
            isHit = false;
        }
    }

    #region /grid move
    private float RoundToNearestGrid(float position)
    {
        float _xDiff = position % gridSize;
        position -= _xDiff;
        if (_xDiff > (gridSize / 2))
        {
            position += gridSize;
        }
        return position;
    }

    private void SetPositionOnGround()
    {
        Vector3 _setPosition = position;
        _setPosition.y += pendingObject.transform.localScale.y / 2;
        pendingObject.transform.position = _setPosition;
    }

    private void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount, Space.Self);
    }
    #endregion
    
    private void OnSelectObject(int index)
    {
        pendingObject = pool.GetObject(objectData.selectableObjects[index], index);
        if (pendingObject.TryGetComponent(out BoxCollider _collider))
        {
            _collider.isTrigger = true;
        }
        isBuildingMode = true;
    }

    private void PlaceObject()
    {
        pendingObject.TryGetComponent(out TriggerDetector trigger);
        if (isBuildingMode && !trigger.Istrigger)
        {
            if (parentObject == null)
            {
                parentObject = new GameObject("Structure").transform;
            }

            GameObject _newObject = Instantiate(pendingObject, pendingObject.transform.position, pendingObject.transform.rotation);
            _newObject.transform.SetParent(parentObject, true);
            _newObject.TryGetComponent(out BoxCollider _collider);
            _collider.isTrigger = false;
            _newObject.TryGetComponent(out TriggerDetector detector);
            Destroy(detector);
            pool.ReturnObject(pendingObject);
            isBuildingMode = false;
            pendingObject = null;
            Cursor.lockState = CursorLockMode.None;
            UIManager.Instance.BuildingUI.SetActive(true);
        }
        else if (isMovingMode && !trigger.Istrigger)
        {
            if (parentObject == null)
            {
                parentObject = new GameObject("Structure").transform;
            }
            GameObject _movedObject = pendingObject;
            pendingObject = null;
            _movedObject.transform.SetParent(parentObject, true);
            _movedObject.TryGetComponent(out BoxCollider _collider);
            _collider.isTrigger = false;
            _movedObject.TryGetComponent(out TriggerDetector detector);
            Destroy(detector);
            ToStructureUI(isBack: true);
        }
    }

    private void OnMoveObject()
    {
        isMovingMode = true;
        layerMask &= ~(LayerMask.NameToLayer("Ground"));
        layerMask = LayerMask.GetMask("Interactable");
    }

    private void SelectObjectToMove()
    {
        if (!isHit)
        {
            ToStructureUI(isBack: true);
        }
        else if (hit.collider.TryGetComponent(out StructureSOHolder test))
        {
            pendingObject = hit.collider.gameObject;
            pendingObject.transform.SetParent(transform, true);
            pendingObject.TryGetComponent(out BoxCollider _collider);
            _collider.isTrigger = true;
            pendingObject.AddComponent<TriggerDetector>();
            ToStructureUI(isBack: false);
        }
    }

    private void OnDestroyObject()
    {
        isDestroyMode = true;
        layerMask &= ~(LayerMask.NameToLayer("Ground"));
        layerMask = LayerMask.GetMask("Interactable");
    }

    private void DestroyStucture()
    {
        if(!isHit)
        {
            ToStructureUI(isBack:true);
        }
        else if (hit.collider.TryGetComponent(out StructureSOHolder test))
        {
            pendingObject = hit.collider.gameObject;
            Destroy(pendingObject); 
            ToStructureUI(isBack:true);
        }
    }

    private void ToStructureUI(bool isBack)
    {
        layerMask &= ~(LayerMask.NameToLayer("Interactable"));
        layerMask = LayerMask.GetMask("Ground");
        if (isBack)
        {
            isMovingMode = false;
            isDestroyMode = false;
            Cursor.lockState = CursorLockMode.None;
            UIManager.Instance.StructureUIManager.SetActive(true);
        }
    }

    public void OnBuildMode(InputAction.CallbackContext context)
    {
        isOpen = !isOpen;
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log(isOpen);
            OnToggle();
            UIManager.Instance.StructureUIManager.SetActive(isOpen);
        }
    }

    private void OnToggle()
    {
        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}