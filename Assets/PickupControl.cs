using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;
public class PickupControl : MonoBehaviour
{
    bool isPicked = false;
    [SerializeField] Transform PickTransform;
    [SerializeField] float Radius;
    Collider[] Cols;
    [SerializeField] LayerMask LayerMask;
    GameObject _PickedItem;
    HingeJoint hj;
    // Start is called before the first frame update
    void Start()
    {
        hj = PickTransform.GetComponent<HingeJoint>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(PickTransform.position, Radius);
        Gizmos.color = Color.red;
    }
    // Update is called once per frame
    void Update()
    {
        Cols = Physics.OverlapSphere(PickTransform.position, Radius, LayerMask);
        foreach (Collider item in Cols)
        {
            if (!isPicked)
            {
                isPicked = true;
                _PickedItem = item.gameObject;
                Debug.Log(_PickedItem.name);
                Rigidbody ItemRb = item.GetComponent<Rigidbody>();
                hj.connectedBody = ItemRb;
                GetComponent<PlayerController>().SwitchMove();
                GetComponent<AnimatorIKDemo>().SwitchPos();
            }


        }

    }
}
