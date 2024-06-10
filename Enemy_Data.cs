using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data : MonoBehaviour
{
    private int HP; // �� ��ü�� ü��

    public Enemy_Data(int _HP)  // ������
    {
        HP = _HP;
    }
    // Enemy_Data enemy = new Enemy_Data(50); -> ü���� 50�� ���� ������

    public void decreaseHP(int damage)  // damage��ŭ ü���� ��´�.
    {
        HP -= damage;
    }
    // Enemy_Data enemy = new Enemy_Data(50); -> ü���� 50�� ���� ������
    // enemy.decreaseHP(20); -> ü���� 20��ŭ ��´�.

    public int getHP()
    {
        return HP;
    }
    // Enemy_Data enemy = new Enemy_Data(50); -> ü���� 50�� ���� ������
    // enemy.getHP(); -> ���� ü���� ��ȯ
}
