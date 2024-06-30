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
        public bool MobilePlatform = false;
        public int game_phase = 0;
        public float max_rod_hp = 100;
        public float rod_hp;
        [SerializeField] private Spawner spawner_script;
        [SerializeField] private Camera game_camera;
        [SerializeField] private GameObject boat;
        [SerializeField] private Animator boat_animator;
        [SerializeField] private Animator succes_animation;
        [SerializeField] private Image hp_bar;
        [SerializeField] private Image gradient1;
        [SerializeField] private Image gradient2;
        [SerializeField] private RayForRod rfr;
        System.Random ran = new System.Random();
        private Moving moving_script;
        private GameObject fish;

        [SerializeField] public Image title_image;

        [SerializeField] public Image fish_image;

        [SerializeField] public Sprite neww;

        [SerializeField] public Sprite not_new;

        [SerializeField] public Image image3;

    
        [SerializeField] public Sprite Щука;
        [SerializeField] public Sprite Карп;
        [SerializeField] public Sprite Осетр;
        [SerializeField] public Sprite Судак;
        [SerializeField] public Sprite Горбуша;
        [SerializeField] public Sprite Толстолобик;
        [SerializeField] public Sprite Голавль;
        [SerializeField] public Sprite Акула;
        [SerializeField] public Sprite Арапаима;
        [SerializeField] public Sprite Скат;
        [SerializeField] public Sprite Краб;
        [SerializeField] public Sprite Пиранья;
        [SerializeField] public Sprite Сом;
        [SerializeField] public Sprite Угорь;


        [SerializeField] public Sprite Щука_надпись;
        [SerializeField] public Sprite Карп_надпись;
        [SerializeField] public Sprite Осетр_надпись;
        [SerializeField] public Sprite Судак_надпись;
        [SerializeField] public Sprite Горбуша_надпись;
        [SerializeField] public Sprite Толстолобик_надпись;
        [SerializeField] public Sprite Голавль_надпись;
        [SerializeField] public Sprite Акула_надпись;
        [SerializeField] public Sprite Арапаима_надпись;
        [SerializeField] public Sprite Скат_надпись;
        [SerializeField] public Sprite Краб_надпись;
        [SerializeField] public Sprite Пиранья_надпись;
        [SerializeField] public Sprite Сом_надпись;
        [SerializeField] public Sprite Угорь_надпись;


        void Start()
        {
            rod_hp = max_rod_hp;
            //water = GameObject.FindGameObjectWithTag("Water").GetComponent<WaterPropertyBlockSetter>();
        }

        void FixedUpdate()
        {
            if (game_phase == 0)
            {
                if (MobilePlatform)
                {
                    if (Input.touchCount != 0)
                    {
                        ShipStop();
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ShipStop();
                    }
                }
            }
            else
            {
                StartCoroutine(rfr.RodCor(fish));
                if (fish.transform.position.z - moving_script.start_fish_z < -24)
                {
                    fish.SetActive(false);
                    fish.transform.position = new Vector3(fish.transform.position.x, fish.transform.position.y, fish.transform.position.z+5);
                    moving_script.IsSucces = true;
                    EndFishing(moving_script.FishType);
                }
                if (fish.transform.position.x - moving_script.start_fish_x > 11)
                {
                    gradient2.color = new Color(255, 255, 255, 255);
                    FisherDamage();
                }
                else if (fish.transform.position.x - moving_script.start_fish_x < -11)
                {
                    gradient1.color = new Color(255, 255, 255, 255);
                    FisherDamage();
                }
                else
                {
                    gradient1.color = new Color(255, 255, 255, 0);
                    gradient2.color = new Color(255, 255, 255, 0);
                }
            }
        }
        private void FisherDamage()
        {
            rod_hp -= 1.5f;
            if (rod_hp < 0)
            {
                moving_script.IsSucces = true;
                EndFishing(null);
            }

        }

        private void ShipStop()
        {
            fish = GameObject.FindGameObjectWithTag("Fish");
            if (fish != null)
            {
                if (fish.transform.position.z > -7 && fish.transform.position.z < 27)
                {
                    game_phase = 1;
                    boat_animator.SetBool("going", false);
                    moving_script = fish.GetComponent<Moving>();

                    moving_script.StopMoving = true;
                    spawner_script.StopSpawning = true;

                    StartCoroutine(CameraMoving(fish.transform.position));
                    //StartCoroutine(CameraMoving(fish_pos));
                }
            }
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
            if (fish_type != null)
            {
                string fish = fish_type;
                int is_already_catched = PlayerPrefs.GetInt(fish);

                if (is_already_catched == 0){    // если новая
                    PlayerPrefs.SetInt(fish, 1);
                    Debug.Log("new ");
                    image3.sprite = neww;
                }
                else{
                    Debug.Log("not new");
                    image3.sprite = not_new;
                
                }
                int money = PlayerPrefs.GetInt("money");
                money = money + 10;
                PlayerPrefs.SetInt("money", money);
            }

            if (fish_type == null)
            {
                image3.color = new Color(0,0,0,0);
                title_image.color = new Color(0, 0, 0, 0);
                fish_image.color = new Color(0, 0, 0, 0);
                succes_animation.SetBool("PlayLoseAnim", true);
                return;
            }
            if (fish_type == "Щука"){
                title_image.sprite = Щука;
                fish_image.sprite = Щука_надпись;
            }
            if (fish_type == "Осетр"){
                title_image.sprite = Осетр;
                fish_image.sprite = Осетр_надпись;
            }
            if (fish_type == "Карп"){
                title_image.sprite = Карп;
                fish_image.sprite = Карп_надпись;
            }
            if (fish_type == "Судак"){
                title_image.sprite = Судак;
                fish_image.sprite = Судак_надпись;
            }
            if (fish_type == "Горбуша"){
                title_image.sprite = Горбуша;
                fish_image.sprite = Горбуша_надпись;
            }
            if (fish_type == "Толстолобик"){
                title_image.sprite = Толстолобик;
                fish_image.sprite = Толстолобик_надпись;
            }
            if (fish_type == "Голавль"){
                title_image.sprite = Голавль;
                fish_image.sprite = Голавль_надпись;
            }
            if (fish_type == "Акула"){
                title_image.sprite = Акула;
                fish_image.sprite = Акула_надпись;
            }
            if (fish_type == "Арапаима"){
                title_image.sprite = Арапаима;
                fish_image.sprite = Арапаима_надпись;
            }
            if (fish_type == "Скат"){
                title_image.sprite = Скат;
                fish_image.sprite = Скат_надпись;
            }
            if (fish_type == "Краб"){
                title_image.sprite = Краб;
                fish_image.sprite = Краб_надпись;
            }
            if (fish_type == "Пиранья"){
                title_image.sprite = Пиранья;
                fish_image.sprite = Пиранья_надпись;
            }
            if (fish_type == "Сом"){
                title_image.sprite = Сом;
                fish_image.sprite = Сом_надпись;
            }
            if (fish_type == "Угорь"){
                title_image.sprite = Угорь;
                fish_image.sprite = Угорь_надпись;
            }



            succes_animation.SetTrigger("PlaySuccesAnim");
        }
    }
}