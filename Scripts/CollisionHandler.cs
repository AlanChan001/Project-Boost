using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] Canvas canvas;
    AudioSource audioSource;

    public string cheatMode= "Off";
    public int levelInt;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        RespondToDebugKeys();

    }

    void RespondToDebugKeys()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {

            Invoke("LoadNextLevel",1f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
            if (collisionDisabled)
            {
                cheatMode = "On";
            }
            else 
            {
                cheatMode = "Off";
            }
        }
    }


        void OnCollisionEnter(Collision other)
        {
            if (isTransitioning || collisionDisabled) { return; }
            switch (other.gameObject.tag)
            {
                case "Friendly":

                    break;
                case "Finish":
                    StartSuccessSequence();

                    break;
                case "Fuel":

                    break;
                default:

                    StartCrashSequence();
                    break;

            }

        }

        void StartCrashSequence()
        {
            isTransitioning = true;
            audioSource.Stop();
            //todo add SFX upon crash

            audioSource.PlayOneShot(crash, 0.5f);



            //todo add partical effect upon crash
            crashParticles.Play();
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", levelLoadDelay);

        }

        void StartSuccessSequence()
        {
            isTransitioning = true;
            audioSource.Stop();
            //todo add SFX upon success
            audioSource.PlayOneShot(success, 0.5f);



            //todo add partical effect upon success
            successParticles.Play();
            GetComponent<Movement>().enabled = false;
            Invoke("LoadNextLevel", levelLoadDelay);

        }

        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            
            SceneManager.LoadScene(nextSceneIndex);
            
            


        }
        void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);

        }




}

