using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Missile_Move : MonoBehaviour
{
    public float MoveSpeed;     // �̻����� ���󰡴� �ӵ�
    public float DestroyYPos;   // �̻����� ������� ����

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �� �����Ӹ��� �̻����� MoveSpeed ��ŭ up����(Y�� +����)���� ���󰩴ϴ�.
        transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
        // ���࿡ �̻����� ��ġ�� DestroyYPos�� �Ѿ��
        if (transform.position.y >= DestroyYPos)
        {
            // �̻����� ����
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε����� collision�� ���� ��ü�� �±װ� "Enemy"�� ���
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("�� ��ü�� �浹");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
