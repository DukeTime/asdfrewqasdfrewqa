namespace Assets.Scripts.Water
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class GameController : MonoBehaviour
    {
        //[SerializeField] private WaterPropertyBlockSetter water;
        public int game_phase = 0;
        public float max_rod_hp = 100;
        public float rod_hp;
        [SerializeField] private Spawner spawner_script;
        [SerializeField] private Camera game_camera;
        [SerializeField] private GameObject boat;
        [SerializeField] private Animator boat_animator;
        [SerializeField] private Animator succes_animation;
        [SerializeField] private Image hp_bar;
        System.Random ran = new System.Random();
        private Moving moving_script;
        private GameObject fish;
        void Start()
        {
            rod_hp = max_rod_hp;
            //water = GameObject.FindGameObjectWithTag("Water").GetComponent<WaterPropertyBlockSetter>();
        }

        void FixedUpdate()
        {
            if (game_phase == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShipStop();
                    game_phase = 1;
                }
            }
            else
            {
                if (fish.transform.position.z - moving_script.start_fish_z < -24)
                {
                    fish.SetActive(false);
                    EndFishing(moving_script.FishType);
                }
                if (transform.position.x - moving_script.start_fish_x > 11)
                {
                    FisherDamage();
                }
                else if (transform.position.x - moving_script.start_fish_x < -11)
                {
                    FisherDamage();
                }
            }
        }
        private void FisherDamage()
        {
            rod_hp -= 0.5f;
            hp_bar.transform.localScale = hp_bar.transform.localScale + new Vector3(-1, 0, 0);
        }

        private void ShipStop()
        {
            boat_animator.SetBool("going", false);
            fish = GameObject.FindGameObjectWithTag("Fish");
            moving_script = fish.GetComponent<Moving>();

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
            boat.transform.position = fish_position + new Vector3(0, 10.3f, -25);
            timer = 0;
            while (timer < 1.5)
            {
                game_camera.transform.position = Vector3.Lerp(game_camera.transform.position, fish_position + new Vector3(0, 57.6f, -16.5f), Time.deltaTime * 2);
                timer += Time.deltaTime;
                yield return null;
            }
            FishCatching();
        }

        private void FishCatching()
        {
            StartCoroutine(moving_script.FishDodjing(fish.transform.position));
            
        }

        public void BackTo(int scene_num)
        {
            SceneManager.LoadScene(scene_num);
        }
        private void EndFishing(string fish_type)
        {
            string fish = fish_type;
            int is_already_catched = PlayerPrefs.GetInt(fish);

            if (is_already_catched == 0){    // если новая
                PlayerPrefs.SetInt(fish, 1);
                Debug.Log("new ");
            }
            else{
                Debug.Log("not new");
                
            }
            int money = PlayerPrefs.GetInt("money");
            money = money + 10;
            PlayerPrefs.SetInt("money", money);
            succes_animation.SetTrigger("PlaySuccesAnim");
        }
    }
}