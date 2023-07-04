using UnityEngine;

public class EnemyColorChange : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _targget;

    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _light2;

    const float MAX_DISTANCE = 100;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            float val = GetLerpValue();
            _light.SetActive(false);
            _light2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _light.SetActive(true);
            _light2.SetActive(false);
        }
    }
    public float GetLerpValue()
    {
        float distanceApart = GetSqrDistance(_player.transform.position, _targget.transform.position);

        float lerp = MapValue(distanceApart, 0, MAX_DISTANCE, 0f, 1f);

        return lerp;
    }

    public float GetSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }

    float MapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return 1f - ((mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin)) + outValueMin;
    }

}
