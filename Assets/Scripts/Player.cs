using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform gunPosition;

    [SerializeField] int bulletType = 0;
    [SerializeField] int bulletType1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager.Instance.GetPooledObjects(bulletType, gunPosition.position, gunPosition.rotation);
            
            if(bullet != null)
            {
                bullet.SetActive(true);
            }
            else
            {
                Debug.LogError("Pool de bullet demasiado pequeño");
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject bullet1 = PoolManager.Instance.GetPooledObjects(bulletType1, gunPosition.position, gunPosition.rotation);
            
            if(bullet1 != null)
            {
                bullet1.SetActive(true);
            }
            else
            {
                Debug.LogError("Pool de bullet1 demasiado pequeño");
            }
        }
        
    }
}
