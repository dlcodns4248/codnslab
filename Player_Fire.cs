using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour
{
    public GameObject PlayerMissile;    // ������ �̻��� ������Ʈ
    public Transform MissileLocation;   // �̻����� �߻�� ��ġ
    public float FireDelay;             // �̻��� �߻� �ӵ�(�̻����� ���󰡴� �ӵ�x)
    private bool FireState;            // �̻��� �߻� �ӵ��� ������

    public int MissileMaxPool;          // �޸� Ǯ�� ������ �̻��� ����
    private MemoryPool MPool;           // �޸� Ǯ
    private GameObject[] MissileArray;  // �޸� Ǯ�� �����Ͽ� ����� �̻��� �迭

    // ������ ����Ǹ� �ڵ����� ȣ��Ǵ� �Լ�
    private void OnApplicationQuit()
    {
        // �޸� Ǯ�� ���ϴ�.
        MPool.Dispose();
    }
    void Start()
    {
        // ó���� �̻����� �߻��� �� �ֵ��� ������� true�� ����
        FireState = true;

        // �޸� Ǯ�� �ʱ�ȭ�մϴ�.
        MPool = new MemoryPool();
        // PlayerMissile�� MissileMaxPool��ŭ �����մϴ�.
        MPool.Create(PlayerMissile, MissileMaxPool);
        // �迭�� �ʱ�ȭ �մϴ�.(�̶� ��� ���� null�� �˴ϴ�.)
        MissileArray = new GameObject[MissileMaxPool];
    }

    void Update()
    {
        // �� �����Ӹ��� �̻��Ϲ߻� �Լ��� üũ�Ѵ�.
        playerFire();
    }

    // �̻����� �߻��ϴ� �Լ�
    private void playerFire()
    {
        // ������� true�϶��� �ߵ�
        if (FireState)
        {
            // Ű������ "A"�� ������
            if (Input.GetKey(KeyCode.Space))
            {
                // �ڷ�ƾ "FireCycleControl"�� ����Ǹ�
                StartCoroutine(FireCycleControl());

                // �̻��� Ǯ���� �߻���� ���� �̻����� ã�Ƽ� �߻��մϴ�.
                for (int i = 0; i < MissileMaxPool; i++)
                {
                    // ���� �̻��Ϲ迭[i]�� ����ִٸ�
                    if (MissileArray[i] == null)
                    {
                        // �޸�Ǯ���� �̻����� �����´�.
                        MissileArray[i] = MPool.NewItem();
                        // �ش� �̻����� ��ġ�� �̻��� �߻��������� �����.
                        MissileArray[i].transform.position = MissileLocation.transform.position;
                        // �߻� �Ŀ� for���� �ٷ� ����������.
                        break;
                    }
                }
            }
        }

        // �̻����� �߻�ɶ����� �̻����� �޸�Ǯ�� ���������� ���� üũ�Ѵ�.
        for (int i = 0; i < MissileMaxPool; i++)
        {
            // ���� �̻���[i]�� Ȱ��ȭ �Ǿ��ִٸ�
            if (MissileArray[i])
            {
                // �̻���[i]�� Collider2D�� ��Ȱ�� �Ǿ��ٸ�
                if (MissileArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    // �ٽ� Collider2D�� Ȱ��ȭ ��Ű��
                    MissileArray[i].GetComponent<Collider2D>().enabled = true;
                    // �̻����� �޸𸮷� ����������
                    MPool.RemoveItem(MissileArray[i]);
                    // ����Ű�� �迭�� �ش� �׸� null(�� ����)�� �����.
                    MissileArray[i] = null;
                }
            }
        }
    }

    // �ڷ�ƾ �Լ�
    IEnumerator FireCycleControl()
    {
        // ó���� FireState�� false�� �����
        FireState = false;
        // FireDelay�� �Ŀ�
        yield return new WaitForSeconds(FireDelay);
        // FireState�� true�� �����.
        FireState = true;
    }
}