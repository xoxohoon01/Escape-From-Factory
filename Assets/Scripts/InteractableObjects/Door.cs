using System;
using System.Collections;
using UnityEngine;

public enum DoorType
{
    Sliding, // 슬라이드형, 위아래로 여닫힘. 예 : 셔터
    Swinging // 회전형, 회전하며 여닫힘. 예 : 일반적인 문
}
public class Door : MonoBehaviour, IInteractable
{
    [Header(" Info ")]
    [SerializeField] private DoorType type;
    [SerializeField] private Transform doorTransform;
    [SerializeField] private float openSpeed;         // 움직이는 속도
    [SerializeField] private float openAngle;         // 열리는 각도 ( Swinging )
    [SerializeField] private float openDistance;      // 열리는 거리 ( Sliding )

    private bool isOpen = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isAnimating = false;

    void Start()
    {
        if(doorTransform == null)
        {
            doorTransform = transform;
        }

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void Interact()
    {
        if (isAnimating)
            return;

        if (isOpen)
        {
            StartCoroutine(CoCloseDoor());
            Debug.Log("문이 열립니다.");
        }
        else
        {
            StartCoroutine(CoOpenDoor());
            Debug.Log("문이 닫힙니다.");
        }

    }

    public void Update()
    {
        //InvokeRepeating("Interact", 1, 2);
    }

    public IEnumerator CoOpenDoor()
    {
        isAnimating = true;
        float elapsedTime = 0f;

        if (type == DoorType.Swinging) // 회전형일 경우
        {
            Quaternion targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);

            while (elapsedTime < 1f)
            {
                doorTransform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime);
                elapsedTime += Time.deltaTime * openSpeed;
                yield return null;
            }

            doorTransform.rotation = targetRotation;
        }
        else if (type == DoorType.Sliding) // 슬라이드의 경우
        {
            Vector3 targetPosition = initialPosition + new Vector3(0, openDistance, 0);

            while (elapsedTime < 1f)
            {
                doorTransform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime);
                elapsedTime += Time.deltaTime * openSpeed;
                yield return null;
            }

            doorTransform.position = targetPosition;
        }

        isOpen = true;
        isAnimating = false;
    }
    public IEnumerator CoCloseDoor()
    {
        isAnimating = true;
        float elapsedTime = 0f;

        if (type == DoorType.Swinging)
        {
            Quaternion targetRotation = initialRotation;

            while (elapsedTime < 1f)
            {
                doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, targetRotation, elapsedTime);
                elapsedTime += Time.deltaTime * openSpeed;
                yield return null;
            }

            doorTransform.rotation = targetRotation;
        }
        else if (type == DoorType.Sliding)
        {
            Vector3 targetPosition = initialPosition;

            while (elapsedTime < 1f)
            {
                doorTransform.position = Vector3.Lerp(doorTransform.position, targetPosition, elapsedTime);
                elapsedTime += Time.deltaTime * openSpeed;
                yield return null;
            }

            doorTransform.position = targetPosition;
        }

        isOpen = false;
        isAnimating = false;
    }
}
