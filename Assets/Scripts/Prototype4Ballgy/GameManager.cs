using TMPro;
using UnityEngine;

namespace Prototype4.Ballgy
{

    public class GameManager : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_Text scoreUiText;
        [SerializeField] private GameObject uiGameobject;

        [Header("Counter")]
        [SerializeField] private TMP_Text counterUiText;
        [SerializeField] private int maxCount;

        [SerializeField]
        private Countdown counter;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject generatorPrefab;
        private int score;

        [Header("Player")]
        [SerializeField] private Rigidbody playerRigidbody;

        #region Publics

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void PlayGame()
        {
            Time.timeScale = 1.0f;
        }

        public void QuitGame()
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit();
#endif
            Debug.Log("Exit !!!");
        }

        public void ShowUi()
        {
            uiGameobject.SetActive(true);
        }

        public void HideUi()
        {
            uiGameobject.SetActive(false);
        }

        public void SendPoint(int point)
        {
            score = score + point;
            //UI
            //Debug.Log($"SCORE : {score}");
            scoreUiText.text = $"Score:{score}";

        }

        #endregion

        #region Privates

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1.0f;
            playerRigidbody.isKinematic = true;
            GenerateGenerators(4);
            scoreUiText.text = "Score: ";
            counterUiText.text = maxCount.ToString();
            counter.StartCounter(maxCount);
        }

        // Update is called once per frame
        void Update()
        {
            // Pause 
            if (Input.GetKeyDown(KeyCode.Escape)) {
                PauseGame();
                ShowUi();
            }

            // Time control
            //if (Input.GetKeyDown(KeyCode.P)) {
            //    if (Time.timeScale == 1.0f)
            //        Time.timeScale = 0f;
            //    else
            //        Time.timeScale = 1.0f;
            //}
        }

        public void Tick(int tickCount)
        {
            //Debug.Log($"Tick");
            counterUiText.text = tickCount.ToString();
            // "Start" yaz�s� DELAY (coroutine)
            playerRigidbody.isKinematic = false;
        }

        private void PlayerInputEnabler()
        {

        }



        private void GenerateGenerators(int numberOfGen)
        {
            // Spawning 
            for (int i = 0; i < numberOfGen; i++) {
                Instantiate(generatorPrefab, new Vector3(i + (i * .5f) - 2.2f, 1.8f, 8), Quaternion.identity);
            }
        }

        #endregion
    }
}