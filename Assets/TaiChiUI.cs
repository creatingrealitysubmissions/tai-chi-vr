using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiUI : MonoBehaviour {

	[SerializeField] private GameObject _boundingBox;
	[SerializeField] private GameObject _castBox;
	[SerializeField] private TaiChiControllerInput _rControllerInput;

	[SerializeField] private GameObject _testPointer;

	private Mesh _castBoxMesh;

	void Start () 
	{
		 _castBoxMesh = _castBox.GetComponent<MeshFilter>().mesh;
		 Bounds bounds = _castBoxMesh.bounds;
		 print(bounds.extents);
	}
	
	void LateUpdate () 
	{
        Vector3 fwd = _castBox.transform.TransformDirection(Vector3.forward);
		
		float xOffset = ((_castBox.transform.localScale.x * transform.localScale.x) / 2) * _rControllerInput.touchpadX;
		float yOffset = ((_castBox.transform.localScale.y * transform.localScale.y) / 2) * _rControllerInput.touchpadY;

		Vector3 offset = new Vector3(xOffset, yOffset, 0);

		_testPointer.transform.position = _castBox.transform.position + offset;
		RaycastHit hit;

		LayerMask mask = LayerMask.GetMask("HandUI");

        if (Physics.Raycast(_castBox.transform.position + offset, fwd, out hit, Mathf.Infinity, mask))
		{
            print(hit.transform.gameObject.name);
			_boundingBox.transform.position = hit.transform.position;
			if(!_boundingBox.activeSelf)
			{
				_boundingBox.SetActive(true);
			}
		}
	}
}
