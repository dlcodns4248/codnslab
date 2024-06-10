using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    private Enemy_Data enemyData;

    // Use this for initialization
    void Start()
    {
        enemyData = new Enemy_Data(HP);
        Debug.Log(gameObject.name + "�� ü�� : " + enemyData.getHP());
    }

    void Update()
    {
        if (enemyData.getHP() <= 0)
        {
            Debug.Log("�ı�!!!!!");
            Destroy(gameObject);
            // ���� ���� ������Ʈ�� �޸�Ǯ������ ������ �ʾұ� ������
            // Destroy�� ó���մϴ�.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε����� collision�� ���� ��ü�� �±װ� "Player Missile"�� ���
        if (collision.CompareTag("Player Missile"))
        {
            Debug.Log("�̻��ϰ� �浹");
            enemyData.decreaseHP(10);   // ü���� 10 ����
            Debug.Log(gameObject.name + "�� ���� ü�� : " + enemyData.getHP());
        }
    }
}