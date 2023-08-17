using UnityEngine;

public class OtherLineTeleport : MonoBehaviour
{

	[SerializeField] private Vector3 _addPos;
	[SerializeField] private MainLine _line;
	[SerializeField] private OtherLine _target;

	private void OnTriggerEnter (Collider other)
	{
        if (other.tag == "line")
        {
	        _target.transform.position = new Vector3(_line.transform.position.x + _addPos.x, _line.transform.position.y + _addPos.y, _line.transform.position.z + _addPos.z);
        }
	}
}
