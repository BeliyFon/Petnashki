using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class MoveChip : MonoBehaviour
{
    private int number_chip;
    private int row_position;
    private int col_position;
    private int speed;
    private Vector3 empty_position = new Vector3(0,0,0);
    private GameObject ui_motion;
    private GameObject ui_completed;

    private bool can_move;
    void Start()
    {
        speed = 2;
        number_chip = int.Parse(gameObject.name);
        ui_motion = GameObject.Find("Motion");
        ui_completed = GameObject.Find("Completed");
    }
    void Update()
    {
        if (can_move)
        {
            MoveChipOnBoard();
        }
    }

    void OnMouseDown()
    {
        if (!can_move)
        {
            FindOnBoard();
            CalculateDirection();
        }
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
    void MotionCountPlus()
    {
        Global.count++;
        ui_motion.GetComponent<Text>().text = "КОЛИЧЕСТВО ХОДОВ\n\n " + Global.count.ToString();
    }
    void MoveChipOnBoard()
    {
        if (transform.position != empty_position)
        {
            transform.position = Vector3.MoveTowards(transform.position, empty_position, speed * Time.deltaTime);
        }
        else
        {
            can_move = false;
            MotionCountPlus();
            CheckOnComplete();
        }
    }
    void CheckOnComplete()
    {
        int count = 1;

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (Global.board[row,col] == count)
                    {
                    Debug.Log(count);
                    }
                    else
                    {
                        return;
                    }
                count++;
                if (count == 15)
                {
                    ui_completed.GetComponent<Text>().enabled = true;
                }
            }
        }
    }
    void CalculateDirection()
    {
        try
        {
            if (Global.board[row_position + 1, col_position] == 0) 
            { 
                empty_position = new Vector3(transform.position.x + 1.5f, 0, transform.position.z); 
                Global.board[row_position, col_position] = 0;
                Global.board[row_position + 1,col_position] = number_chip;
                PlaySound();
                can_move = true;
            }
        }
        catch { }

        try
        {
            if (Global.board[row_position - 1, col_position] == 0)
            { 
                empty_position = new Vector3(transform.position.x - 1.5f, 0, transform.position.z);
                Global.board[row_position, col_position] = 0; 
                Global.board[row_position - 1, col_position] = number_chip;
                PlaySound();
                can_move = true;
            }
        }
        catch { }

        try
        {
            if (Global.board[row_position, col_position + 1] == 0)
            {
                empty_position = new Vector3(transform.position.x, 0, transform.position.z + 1.5f); 
                Global.board[row_position, col_position] = 0; 
                Global.board[row_position, col_position + 1] = number_chip;
                PlaySound();
                can_move = true;
            }
        }
        catch { }

        try
        {
            if (Global.board[row_position, col_position - 1] == 0)
            {
                empty_position = new Vector3(transform.position.x, 0, transform.position.z - 1.5f);
                Global.board[row_position, col_position] = 0;
                Global.board[row_position, col_position - 1] = number_chip;
                PlaySound();
                can_move = true;
            }
        }
        catch { }
    }
    void FindOnBoard()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (Global.board[row,col] == number_chip)
                {
                    row_position = row;
                    col_position = col;
                }
            }
        }
    }
}
