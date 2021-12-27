using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class RoadDrawManager : MonoBehaviour
{
	public Camera cam = null;
	public LineRenderer lineRenderer = null;
	private Vector3 mousePos;
	private Vector3 Pos, newPos;
	private Vector3 previousPos;
	private List<Vector3> linePositions = new List<Vector3>();
	public float minimumDistance = 0.05f;
	private float distance = 0;

	private Vector3[] lineRendererPose;
	public PathCreator _pathCreator;
	public PathPlacer _PathPlacer;
	private GameObject _pathCreatorGameObject;
	private float zpos = 20;
	public GameObject pathCreatorPrefab;
	public MakeCrystles _MakeCrystles;

	public float waitTime;
	private float timeStamp = Mathf.Infinity;

	private void Start()
	{
		FindObjectOfType<Camera>().GetComponent<CameraFollow>().enabled = true;
	}

	public void MinusCrystles ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			timeStamp = Time.time + waitTime;
		}
		if (Input.GetMouseButtonUp(0))
		{
			timeStamp = Mathf.Infinity;
		}

		if (Time.time >= timeStamp)
		{
			Debug.Log("MinusCrystles");

			if (_MakeCrystles.crystles.Count > 0)
            {
                Destroy(_MakeCrystles.crystles[_MakeCrystles.crystles.Count - 1].gameObject);
                _MakeCrystles.crystles.Remove(_MakeCrystles.crystles[_MakeCrystles.crystles.Count - 1]);
				_MakeCrystles.yPos--;

            }

            timeStamp = Time.time + waitTime;
		}
	}

    void Update()
	{
		
			if (Input.GetMouseButtonDown(0) && _MakeCrystles.crystles.Count > 0)
			{
				linePositions.Clear();
				mousePos = Input.mousePosition;
				mousePos.z = zpos;
				Pos = cam.ScreenToWorldPoint(mousePos);
				newPos = new Vector3(Pos.x, Pos.y, 0);
				previousPos = Pos;
				linePositions.Add(newPos);
			}
			else if (Input.GetMouseButton(0) && _MakeCrystles.crystles.Count > 0)
			{
				mousePos = Input.mousePosition;
				mousePos.z = zpos;
				Pos = cam.ScreenToWorldPoint(mousePos);
				newPos = new Vector3(Pos.x, Pos.y, 0);
				distance = Vector3.Distance(Pos, previousPos);
				if (distance >= minimumDistance)
				{
					previousPos = Pos;
					linePositions.Add(newPos);
					lineRenderer.positionCount = linePositions.Count;
					lineRenderer.SetPositions(linePositions.ToArray());
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				lineRendererPose = new Vector3[lineRenderer.positionCount];
				lineRenderer.GetPositions(lineRendererPose);

			    if(lineRendererPose.Length > 0)
				MakeSpline();
			}
		

		MinusCrystles();
	}

	public void MakeSpline()
	{
		lineRenderer.positionCount = 0;

		_pathCreatorGameObject = Instantiate(pathCreatorPrefab, transform.position, transform.rotation);
		_pathCreator = _pathCreatorGameObject.GetComponentInChildren<PathCreator>();
		_PathPlacer = _pathCreatorGameObject.GetComponentInChildren<PathPlacer>();

		_pathCreator.bezierPath = new BezierPath(lineRendererPose);
		_pathCreator.bezierPath.AutoControlLength = 0.01f;
		_pathCreator.bezierPath.Space = PathSpace.xy;

		_PathPlacer.Generate();

		//Destroy(roadMeshHolder.GetComponent<MeshCollider>());
		//roadMeshHolder.AddComponent<MeshCollider>();
	}
}
