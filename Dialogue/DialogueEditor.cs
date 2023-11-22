using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class DialogueSave : EditorWindow
{

    DialogueAssets dialogueAssets;
    // Start is called before the first frame update



    public static void SaveDialogue(DialogueAssets dialogueAssets)
    {
        string dialogueJson = JsonUtility.ToJson(dialogueAssets, true);
        string path = EditorUtility.SaveFilePanelInProject("Save Dialogue", dialogueAssets.name + "Dialogue", "json", "Please save dialogue");
        System.IO.File.WriteAllText(path, dialogueJson);
    }

    public static void ImportDialogue(DialogueAssets dialogueAssets)
    {
        string dialogueJson = EditorUtility.OpenFilePanel("Import Dialogue", "Assets", "json");
        string dialogueJsonContents = System.IO.File.ReadAllText(dialogueJson);

        Debug.Log(dialogueJsonContents);

        JsonUtility.FromJsonOverwrite(dialogueJsonContents, dialogueAssets);
        
    }

    
}

[ExecuteInEditMode]
[CustomEditor(typeof(DialogueAssets))]
public class DialogueEditor : Editor
{
    // Start is called before the first frame update

    DialogueAssets dialogueAssets;

    


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        dialogueAssets = (DialogueAssets)target;

        if (GUILayout.Button("Save to Json"))
        {
            DialogueSave.SaveDialogue(dialogueAssets);
        }

        if (GUILayout.Button("Import from Json"))
        {
            DialogueSave.ImportDialogue(dialogueAssets);
            
        }
    }


    
}
