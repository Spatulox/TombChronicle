using Discord;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Discord_Controller : MonoBehaviour
{
    public long applicationID;
    [Space]
    //public string details = "Walking around the world";
    public string state = "Current velocity: ";
    [Space]
    public string largeImage = "game_logo";
    public string largeText = "Discord Tutorial";

    private Rigidbody rb;
    private long time;

    private static bool instanceExists;
    public Discord.Discord discord;

    
    void Awake() 
    {
        // Transition the GameObject between scenes, destroy any duplicates
        if (!instanceExists)
        {
            instanceExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    

    void Start()
    {
        // Log in with the Application ID
        discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
        
        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();

        UpdateStatus();
    }

    void Update()
    {
        // Destroy the GameObject if Discord isn't running
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate() 
    {
        UpdateStatus();
    }

    void UpdateStatus()
    {
        // Update Status every frame
        try
        {
            string sceneName = SceneManager.GetActiveScene().name;
            var activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = sceneName,
                State = state,
                Assets = 
                {
                    LargeImage = largeImage,
                    LargeText = largeText
                },
                Timestamps =
                {
                    Start = time
                }
            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogWarning("Failed connecting to Discord!");
            });
        }
        catch
        {
            // If updating the status fails, Destroy the GameObject
            Destroy(gameObject);
        }
    }
    
    void OnApplicationQuit()
    {
        // Fermer la connexion Discord RPC lorsque l'application se ferme
        if (discord != null)
        {
            discord.Dispose();
        }
    }
}