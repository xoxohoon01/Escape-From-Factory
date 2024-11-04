using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private GameObject pendingObject;
    private Vector3 position;
    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float gridSize;
    [SerializeField] private float rotateAmount;
    private bool isBuildingMode;

    private void Update()
    {
        if (pendingObject != null)
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
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            position = hit.point;
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

    private void SetPositionOnGround()
    {
        Vector3 _setPosition = position;
        _setPosition.y += pendingObject.transform.localScale.y / 2;
        pendingObject.transform.position = _setPosition;
    }

    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    public void SelectObject(int index)
    {
        //pendingObject = Instantiate(objects[index].prefab, position, transform.rotation);
    }


    public void PlaceObject()
    {
        pendingObject = null;
    }

}
