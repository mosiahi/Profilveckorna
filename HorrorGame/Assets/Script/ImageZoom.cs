using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageZoom : ScrollRect
{
    [SerializeField] float minZoom = 0.1f, maxZoom = 20, zoomLerpSpeed = 10;
    public float currentZoom = 1;
    float startPinchDist, startPinchZoom, mouseWheelSensitivity = 1;
    bool isPinching = false;
    Vector2 startPinchCenterPos, startPinchScreenPos;
    bool blockPan = false;


    protected override void  Awake()
    {
        Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2)
        {
            if (!isPinching)
            {
                isPinching = true;
                OnPinchStart();
            }
            OnPinch();
        }
        else
        {
            if (isPinching)
            {
                StartCoroutine(KeepsInLimit());
            }
            isPinching = false;
            if(Input.touchCount == 0)
            {
                blockPan = false;
            }
        }
        // pc Input
        float ScrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if(Mathf.Abs(ScrollWheelInput) > float.Epsilon)
        {
            currentZoom *= 1 + ScrollWheelInput * mouseWheelSensitivity;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            startPinchScreenPos = (Vector3)Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(content, startPinchScreenPos, null, out startPinchCenterPos);
            Vector2 pivotpos = new Vector3(content.pivot.x * content.rect.size.x, content.pivot.y * content.rect.size.y);
            Vector2 posFromBottomLeft = pivotpos + startPinchCenterPos;
            SetPivot(content, new Vector2(posFromBottomLeft.x / content.rect.width, posFromBottomLeft.y / content.rect.height));
        }
        // pc input end
        if(Mathf.Abs(content.localScale.x - currentZoom) > 0.001f)
        {
            content.localScale = Vector3.Lerp(content.localScale, Vector3.one * currentZoom, zoomLerpSpeed * Time.deltaTime);
        }
    }

    void OnPinchStart()
    {
        Vector2 pos1 = Input.touches[0].position;
        Vector2 pos2 = Input.touches[1].position;

        startPinchDist = Distance(pos1, pos2) * content.localScale.x;
        startPinchZoom = currentZoom;
        startPinchScreenPos = (pos1 + pos2) / 2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, startPinchScreenPos, null, out startPinchCenterPos);

        Vector2 pivotPos = new Vector3(content.pivot.x * content.rect.size.x, content.pivot.y * content.rect.size.y);
        Vector2 posFromBottomLeft = pivotPos + startPinchCenterPos;
        SetPivot(content, new Vector2(posFromBottomLeft.x / content.rect.width, posFromBottomLeft.y / content.rect.height));
        blockPan = true;
    }

    float Distance(Vector2 pos1, Vector2 pos2)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, pos1, null, out pos1);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, pos2, null, out pos2);
        return Vector2.Distance(pos1, pos2);
    }

    void SetPivot(RectTransform rectTransform, Vector2 pivot)
    {
        if (rectTransform == null) return;

        Vector2 Size = rectTransform.rect.size;
        Vector2 deltaPivot = rectTransform.pivot - pivot;
        Vector3 deltaPos = new Vector3(deltaPivot.x * Size.x, deltaPivot.y * Size.y) * rectTransform.localScale.x;
        rectTransform.pivot = pivot;
        rectTransform.localPosition -= deltaPos;
    }
    void OnPinch()
    {
        float currentPinchDist = Distance(Input.touches[0].position, Input.touches[1].position) * content.localScale.x;
        currentZoom = (currentPinchDist / startPinchDist) * startPinchZoom;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    protected override void SetContentAnchoredPosition(Vector2 position)
    {
        if (isPinching || blockPan) return;
        base.SetContentAnchoredPosition(position);
    }

    IEnumerator KeepsInLimit()
    {
        this.movementType = MovementType.Elastic;
        yield return new WaitForSeconds(2f);
        this.movementType = MovementType.Clamped;
    }


}
