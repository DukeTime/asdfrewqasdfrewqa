using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //[SerializeField] private WaterPropertyBlockSetter water;
    public int game_phase = 0;
    [SerializeField] private Spawner spawner_script;
    [SerializeField] private Camera game_camera;
    [SerializeField] private GameObject boat;
    void Start()
    {
        //water = GameObject.FindGameObjectWithTag("Water").GetComponent<WaterPropertyBlockSetter>();
    }

    void Update()
    {
        if (game_phase == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShipStop();
                game_phase = 1;
            }
        }
    }

    private void ShipStop()
    {
        GameObject fish = GameObject.FindGameObjectWithTag("Fish");
        Moving moving_script = fish.GetComponent<Moving>();

        moving_script.StopMoving = true;
        spawner_script.StopSpawning = true;

        StartCoroutine(CameraMoving(fish.transform.position));
        //StartCoroutine(CameraMoving(fish_pos));
    }

    private IEnumerator CameraMoving(Vector3 fish_position)
    {
        float timer = 0;
        while (timer < 1.5)
        {
            game_camera.transform.position = Vector3.Lerp(game_camera.transform.position, fish_position + new Vector3(0, 20, 0), Time.deltaTime * 2);
            timer += Time.deltaTime;
            yield return null;
        }
        boat.transform.position = fish_position + new Vector3(0, 10.3f, -20);
        timer = 0;
        while (timer < 1.5)
        {
            game_camera.transform.position = Vector3.Lerp(game_camera.transform.position, fish_position + new Vector3(0, 57.6f, -16.5f), Time.deltaTime * 2);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
