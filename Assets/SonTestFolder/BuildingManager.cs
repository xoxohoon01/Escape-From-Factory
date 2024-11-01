using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public InteractableObjectSO[] objects;
    private GameObject pendingObject;
    private Vector3 position;

    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;
    public float gridSize;
    public float rotateAmount;
    bool isGrid;
    [SerializeField] private Toggle gridToggle;

    private void Update()
    {
        if (pendingObject != null)
        {
            if (isGrid)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(position.x),
                    RoundToNearestGrid(position.y),
                    RoundToNearestGrid(position.z)
                    );
            }
            else
            {
                SetPositionOnGround();
            }

            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            position = hit.point;
        }
    }

    private void SetPositionOnGround()
    {
        Vector3 _setPosition = position;
        _setPosition.y += pendingObject.transform.localScale.y / 2;
        pendingObject.transform.position = _setPosition;
    }

    public void PlaceObject()
    {
        pendingObject = null;
    }

    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index].prefab, position, transform.rotation);
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            isGrid = true;
        }
        else
        {
            isGrid = false;
        }

    }

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
}
