using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CreateBoard : MonoBehaviour
{
    public GameObject [] chips = new GameObject[17];
    public Vector3 board_position = new Vector3(-2f, -10f, -2f);
    public float split_x = 1.1f;
    public float split_z = 1.1f;
    void Start()
    {
        GenerateBoard();
        ShowBoard();
    }
    void Update()
    {
        
    }
    void GenerateBoard()
    {
        for (int i = 1; i < 16; i++)
        {
            bool cancel = false;
            do
            {
                int row = Random.Range(0, 4);
                int col = Random.Range(0, 4);
                if (Global.board[row, col] == 0)
                {
                    cancel = true;
                    Global.board[row, col] = i;
                }
            } while (!cancel);
        }
    }
    void ShowBoard()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (Global.board[row,col] != 0)
                {
                    Vector3 coardinate = new Vector3(board_position.x + row * split_x, board_position.y, board_position.z + col * split_z);
                    int chip = Global.board[row, col] - 1;
                    var obj = Instantiate(chips[chip], coardinate, Quaternion.Euler(new Vector3(-90, 0, 0)));
                    obj.name = chips[chip].name;
                }
            }
        }
    }
}
