using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    private bool isCaught;

    private Transform target;
    
    private bool isDragging;

    private Vector3 mousePosition;
    private Vector3 offsetMouse;

    private Pin pin;
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x -= 50;

        RaycastHit2D hit2D = Physics2D.Raycast(mousePosition, Vector3.zero, 1, LayerMask.GetMask("Pin"));

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            if (hit2D)
            {
                target = hit2D.transform;
                offsetMouse = new Vector3(mousePosition.x - target.position.x, mousePosition.y - target.position.y, 0);
                pin = hit2D.transform.GetComponent<Pin>();
            }
        }

        if (hit2D && isDragging && pin != null)
        {
            isCaught = true;
        }

        if (isCaught)
        {
            MovePin(ref target);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            isCaught = false;
            target = null;
            pin = null;
        }

    }

    private void MovePin(ref Transform pinTransform)
    {
        Vector3 pos = new Vector3(mousePosition.x - offsetMouse.x, mousePosition.y - offsetMouse.y, 0);

        Vector2 limitPos = new Vector2(pin.StartPosition.x + pin.Distance, pin.StartPosition.y + pin.Distance);

        float direction = pin.Distance / Mathf.Abs(pin.Distance);

        direction *= -1;

        if (pin.Horizontal)
        {
            if (CheckPinPosition(pin.StartPosition.x, pos.x, direction))
            {
                pinTransform.position = pin.StartPosition;
            }
            else
            {
                if (CheckPinLimit(pos.x, limitPos.x, direction))
                {
                    pos.x = limitPos.x;
                }
                pinTransform.position = new Vector3(pos.x, pinTransform.position.y, 0);
            }
        }
        if (pin.Vertical)
        {
            if (CheckPinPosition(pin.StartPosition.y, pos.y, direction))
            {
                pinTransform.position = pin.StartPosition;
            }
            else
            {
                if (CheckPinLimit(pos.y, limitPos.y, direction))
                {
                    pos.y = limitPos.y;
                }
                pinTransform.position = new Vector3(pinTransform.position.x, pos.y, 0);
            }
        }
    }

    private bool CheckPinPosition(float pinAxis, float posAxis, float direction)
    {
        return direction * pinAxis < posAxis * direction;
    }

    private bool CheckPinLimit(float pinAxis, float limitAxis, float direction)
    {
        if(direction > 0)
        {
            if(pinAxis < limitAxis)
            {
                return true;
            }
        }
        else
        {
            if(pinAxis > limitAxis)
            {
                return true;
            }
        }

        return false;
    }
}
