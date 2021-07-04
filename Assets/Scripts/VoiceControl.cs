using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("right", Right);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("left", Left);
        //actions.Add("echo", Echo);
        //actions.Add("shoot", Shoot);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Right()
    {
        transform.Translate(200, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 200, 0);
    }

    private void Down()
    {
        transform.Translate(0, -200, 0);
    }

    private void Left()
    {
        transform.Translate(-200, 0, 0);
    }
}
