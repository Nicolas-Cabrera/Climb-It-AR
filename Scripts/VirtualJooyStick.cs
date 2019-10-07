using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

    public class VirtualJooyStick : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	private Image JoyStickBG;
	private Image joystick;

	public Vector3 InputDirection{ set; get;}

	private void Start()
	{
        JoyStickBG = GetComponent<Image>(); 
		joystick = transform.GetChild(0).GetComponent<Image> ();
		InputDirection = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (JoyStickBG.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
		{
			pos.x = (pos.x / JoyStickBG.rectTransform.sizeDelta.x);// position on click within image
			pos.y = (pos.y / JoyStickBG.rectTransform.sizeDelta.y);

			float x = (JoyStickBG.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (JoyStickBG.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			InputDirection = new Vector3 (x, 0, y);

			InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
            //moving the joystick
            joystick.rectTransform.anchoredPosition= new Vector3(InputDirection.x *(JoyStickBG.rectTransform.sizeDelta.x/3), InputDirection.z*(JoyStickBG.rectTransform.sizeDelta.y/3));

		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)// resets the joystick position when it's released 
	{
		InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
	}
}
