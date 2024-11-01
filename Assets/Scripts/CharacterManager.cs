using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();
                if (instance == null)
                {
                    instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
                }
            }
            return instance;
        }
    }

    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}