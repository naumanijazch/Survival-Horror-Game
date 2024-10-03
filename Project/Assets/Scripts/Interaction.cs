/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
   [SerializeField] public Transform _interactionPoint;
   [SerializeField] public float _interactionPointRaduis = 0.5f;
   [SerializeField] private LayerMask _interactableMask; 

   private readonly Collider[] _colliders = new Collider[3];
   [SerializeField] private int _numFound;

   private void Update()
   {

   _numFound = Physics.OverlapSphereNonAlloc(_intersectionPoint.position, _interactionPointRadius, _colliders, _interactableMask)
   }

   private void OnDrawGizmos()
   {
		  Gizmos.color = Color.red;
		  Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
   }
}
*/