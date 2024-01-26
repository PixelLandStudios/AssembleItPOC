using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Linq;

public class LevelProgressionSystem : MonoBehaviour
{
    #region Singleton
    private static LevelProgressionSystem _instance;

    // Property to access the singleton instance
    public static LevelProgressionSystem Instance
    {
        get
        {
            // If the instance hasn't been assigned yet, try to find it in the scene
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelProgressionSystem>();

                // If it still hasn't been found, create a new GameObject and add the singleton script to it
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("LevelProgressionSystem");
                    _instance = singletonObject.AddComponent<LevelProgressionSystem>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField]
    List<LevelParts> CurrentLevelParts;

    [SerializeField]
    TMPro.TextMeshProUGUI LevelProgressText;

    [HideInInspector]
    List<string> AssembledLevelParts;

    // Start is called before the first frame update
    void Start()
    {
        AssembledLevelParts = new List<string>();

        UpdateProgressText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateProgress(string partName)
    {
        AssembledLevelParts.Add(partName);

        UpdateProgressText();
    }

    void UpdateProgressText()
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine("<align=center><b>Level Parts Progress:</b></align>");
        text.AppendLine();

        foreach (var item in CurrentLevelParts)
        {
            int assembledPartCount = AssembledLevelParts.Count(p => p == item.Name);
            text.AppendLine(string.Format("{0} Assembled: <color=red> {1}/{2} </color>", item.Name, assembledPartCount, item.Count));
        }

        LevelProgressText.text = text.ToString();
    }
}