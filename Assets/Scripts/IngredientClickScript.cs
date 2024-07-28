using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientClickScript : MonoBehaviour
{
    public Vector3 InUsePosition;
    private Vector3 TargetPosition;
    private Vector3 StartPosition;
    public UnityEngine.Events.UnityEvent ReadyToUseCallback;
    private bool InUse = false;
    private bool Moving = false;
    public float MoveSpeed = 10;
    void Start()
    {
        StartPosition = this.transform.position;
    }

    void Update()
    {
        if (Moving)
        {
            if (Vector3.Distance(this.transform.position, TargetPosition) == 0)
            {
                Moving = false;
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPosition, MoveSpeed * Time.deltaTime);
                if (InUse)
                    ReadyToUseCallback.Invoke();
            }
        }
    }

    void OnMouseDown()
    {
        if (Moving)
            return;

        if (InUse)
        {
            TargetPosition = StartPosition;
        }
        else
        {
            TargetPosition = InUsePosition;
        }
        InUse = !InUse;
        Moving = true;
    }
}
