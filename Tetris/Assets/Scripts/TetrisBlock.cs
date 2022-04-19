using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint; //переменная отвечает за вращение обьекта
    private float previousTime;
    public float fallTime = 0.8f; //скорость падения блоков

    public static int height = 20; //высота поля
    public static int width = 10; //ширина поля

    private static Transform[,] grid = new Transform[width, height]; // переменная задает размеры поля




    private void Update()
    {
        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime)) //при нажатии стрелки вниз происходит более быстрое движение вниз
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();

                this.enabled = false; // при спуске на нижнию линию (включая блоки), блок становиться неактивным 
                FindObjectOfType<SpawnBlocks>().NewBlock(); //спавниться новый блок
            }
            previousTime = Time.time;
        }
    }


    public void LeftButton()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!ValidMove()) //проверяет позицию игрока после каждого нажатия, если блок выходит за границы поля, то эта функция вовзращает значение
            transform.position -= new Vector3(-1, 0, 0);
    }


    public void RightButton()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!ValidMove()) //проверяет позицию игрока после каждого нажатия, если блок выходит за границы поля, то эта функция вовзращает значение
            transform.position -= new Vector3(1, 0, 0);
    }

    public void RotateButton()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        if (!ValidMove())
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
    }


    void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }


    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }


    void DeleteLine(int i) //метод удаляет линию цельных блоков
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i) //метод опускает ряд блоков вниз
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }


    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;


            if (roundedY >= 16)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }


    bool ValidMove() //функция проверки позиции (не дает блоку выйти за пределы экрана)
    {
        foreach (Transform children in transform) //цикл перебирает все дочерние элементы(блоки)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x); //округляет позицию блока по оси X
            int roundedY = Mathf.RoundToInt(children.transform.position.y); //округляет позицию блока по оси Y

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
