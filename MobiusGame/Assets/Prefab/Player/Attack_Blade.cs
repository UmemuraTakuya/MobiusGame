using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Blade : MonoBehaviour
{
    bool AttackCast = false;
    bool AttackOn   = false;
    int  AttackTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && AttackTime == 0 && AttackOn == false)
        {
           if(AttackCast == false)
            {
                AttackTime = 120;
                AttackOn   = true;
                AttackCast = true;
            }
           else
            {
                if(AttackCast == true)
                {
                    AttackTime = 60;
                    AttackOn = true;
                    AttackCast = false;
                }
            }
         }

        if(AttackOn == true)
        {
            if(AttackCast == true)
            {
                while(0 < AttackTime)
                {
                    transform.Rotate(new Vector3(0, 2, 0));
                    AttackTime--; 
                }
                AttackTime = 0;
                AttackOn = false;
            }
            else
            if (AttackCast == false)
            {
                while (0 < AttackTime)
                {
                    transform.Rotate(new Vector3(0, 3, 0));
                    AttackTime--;
                }
                AttackTime = 0;
                AttackOn = false;
            }
        }
        
    }
}
