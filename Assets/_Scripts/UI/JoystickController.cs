using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image joystickBackground;
    [SerializeField] private Image joystickArea;
    [SerializeField] private Image joystickHead;
    
    private Vector2 tapStartPosition;

    protected Vector2 _inputVector;

    private bool isActive;

    void Start()
    {
        ClickEffect();
        tapStartPosition = joystickBackground.rectTransform.anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, null, out position))
        {
            position.x = (position.x * 2 / joystickBackground.rectTransform.sizeDelta.x);
            position.y = (position.y * 2 / joystickBackground.rectTransform.sizeDelta.y);

            _inputVector = new Vector2(position.x, position.y);

            _inputVector = (_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector;

            joystickHead.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), _inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickEffect();
        
        Vector2 backgroundPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickArea.rectTransform, eventData.position, null, out backgroundPosition))
        {
            joystickBackground.rectTransform.anchoredPosition = new Vector2(backgroundPosition.x, backgroundPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBackground.rectTransform.anchoredPosition = tapStartPosition;

        ClickEffect();

        //joystickArea.color
        
        _inputVector = Vector2.zero;
        joystickHead.rectTransform.anchoredPosition = Vector2.zero;
    }

    private void ClickEffect() => isActive = !isActive;
}
