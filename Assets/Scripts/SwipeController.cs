using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeController : MonoBehaviour
{
    public static bool SwipeRight { get; private set; }
    public static bool SwipeLeft { get; private set; }
    public static bool SwipeUp { get; private set; }
    public static bool SwipeDown { get; private set; }
    public static bool Tap { get; private set; }
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        if (GameManager.IsGameStarted)
        {
            Tap = SwipeDown = SwipeUp = SwipeLeft = SwipeRight = false;
            #region Standalone Inputs
            if (Input.GetMouseButtonDown(0))
            {
                Tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }
            #endregion

            #region Mobile inputs
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    Tap = true;
                    isDraging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    Reset();
                }
            }
            #endregion

            //Просчитать дистанцию
            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (Input.touches.Length < 0)
                {
                    swipeDelta = Input.touches[0].position - startTouch;
                }
                else if (Input.GetMouseButton(0))
                {
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
                }
            }

            //Проверка на пройденность расстояния
            if (swipeDelta.magnitude > 100)
            {
                //Определение направления
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {

                    if (x < 0)
                    {
                        SwipeLeft = true;
                    }
                    else
                    {
                        SwipeRight = true;
                    }
                }
                else
                {

                    if (y < 0)
                    {
                        SwipeDown = true;
                    }
                    else
                    {
                        SwipeUp = true;
                    }
                }

                Reset();
            }
        }
        else
        {
            return;
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}

