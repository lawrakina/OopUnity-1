using UnityEngine;


namespace Units
{
    public interface IBaseUnitView
    {
        Transform    Transform();
        Collider     Collider();
        Rigidbody    Rigidbody();
        MeshRenderer MeshRenderer();
    }
}