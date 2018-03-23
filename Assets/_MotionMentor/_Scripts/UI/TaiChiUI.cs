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
			Vector3 fwd = _castBox.transform.TransformDirection(Vector3.forward);
			
			float xOffset = ((_castBox.transform.localScale.x * transform.localScale.x) / 2) * _rControllerInput.Touchpad.x;
			float yOffset = ((_castBox.transform.localScale.y * transform.localScale.y) / 2) * _rControllerInput.Touchpad.y;

			Vector3 offset = new Vector3(xOffset, yOffset, 0);

			// Vector3 cursorPos = _castBox.transform.position;
			// cursorPos += _castBox.transform.up * yOffset;
			// cursorPos += _castBox.transform.right * xOffset;
			_testPointer.transform.position = _castBox.transform.position + offset; //Vector3.Scale(offset, transform.forward);

			//_testPointer.transform.localPosition += offset;

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
    public void Update()
    {
        print(_rControllerInput.touchpadX);
    }
}
