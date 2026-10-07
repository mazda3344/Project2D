using UnityEngine;
using UnityEngine.SceneManagement;
namespace Game.Scripts.Canvases {
    public class MainCanvas : MonoBehaviour {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject losePanel;
        public static MainCanvas instance;

        private void Awake() {
            if (instance == null) {
                instance = this;
            }
        }

        public void ShowLosePanel() {
            mainPanel.SetActive(true);
            losePanel.SetActive(true);
        }

        public void RestartGame() {
            SceneManager.LoadScene(0);
        }
    }
}