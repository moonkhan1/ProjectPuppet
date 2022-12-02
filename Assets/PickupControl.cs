using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;
using DG.Tweening;
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


    private void OnTriggerEnter(Collider other) 
    {   
        if(other.CompareTag("DropArea") && isPicked)
        {
         hj.connectedBody = null;
        GetComponent<AnimatorIKDemo>().SwitchPos();
        // Transform _Dtransform = other.GetComponent<DropArea>()._dropTransform;
        DropArea _DA = other.GetComponent<DropArea>();
        Transform _DTrans = _DA._dropTransform;
         GetComponent<PlayerController>().SwitchMove();
        _PickedItem.transform.DOJump(_DTrans.position,7,1,0.75f).OnComplete(()=>
        {
          _PickedItem.layer = 0;
         isPicked = false;
         _PickedItem = null;
         _DA.TransformMoveOnY();
         
        });


        }

        
    }
}
