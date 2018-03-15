using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiChiUI : MonoBehaviour {

	[SerializeField] private GameObject _boundingBox;
	[SerializeField] private GameObject _castBox;
	[SerializeField] private TaiChiControllerInput _rControllerInput;

	[SerializeField] private GameObject _testPointer;

	private Mesh _castBoxMesh;

	private TaiChiIcon _iconOver;

	public TaiChiIcon IconOver 
	{ 
		get
		{
			return _iconOver;
		}
		set
		{
			_iconOver = value;
		}
	}

	void OnEnable()
	{
		_rControllerInput.OnTouchpadPressDown += OnSelect;
	}

	void OnDisable()
	{
		_rControllerInput.OnTouchpadPressDown -= OnSelect;
	}

	void Start () 
	{
		 _castBoxMesh = _castBox.GetComponent<MeshFilter>().mesh;
		 Bounds bounds = _castBoxMesh.bounds;
	}
	
	void LateUpdate () 
	{
		if(Game.Instance.UIEnabled)
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
				if(IconOver == null)
					if(hit.transform.GetComponent<TaiChiIcon>() != null)
					{
						IconOver = hit.transform.GetComponent<TaiChiIcon>();
						HighlightIcon(hit.transform);
					}

				if(IconOver != null)
					if(hit.transform != IconOver.transform && hit.transform.GetComponent<TaiChiIcon>() != null)
					{
						IconOver = hit.transform.GetComponent<TaiChiIcon>();
						HighlightIcon(hit.transform);
					}
			}
			else
			{
				IconOver = null;
				_boundingBox.SetActive(false);
			}
		}
	}

	void HighlightIcon(Transform t)
	{
		_boundingBox.transform.position = t.position;
		if(!_boundingBox.activeSelf)
		{
			_boundingBox.SetActive(true);
		}
	}

	public void OnSelect()
	{
		if(IconOver != null)
			IconOver.Select();
	}
}
