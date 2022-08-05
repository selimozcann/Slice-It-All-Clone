using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private bool isTouch;
    public bool IsTouch() => isTouch;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }
}
