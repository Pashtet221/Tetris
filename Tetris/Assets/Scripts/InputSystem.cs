using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public void LeftButton()
    {
        FindObjectOfType<TetrisBlock>().LeftButton();
    }

    public void RightButton()
    {
        FindObjectOfType<TetrisBlock>().RightButton();
    }

    public void RotateButton()
    {
        FindObjectOfType<TetrisBlock>().RotateButton();
    }
}
