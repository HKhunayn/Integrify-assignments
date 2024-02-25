using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class ArabicManger : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text=null;
    void Awake()
    {
        if (TryGetComponent(out TMP_Text t))
            text = GetComponent<TMP_Text>();
        FixArabic();
    }

    private void FixArabic()
    {
        if (text == null)
            return;
        text.isRightToLeftText = true;
        StringBuilder stringBuilder = new StringBuilder();
        string[] arrayOfWords =text.text.Split(" ");
        foreach (string s in arrayOfWords) 
        {
            // the foreach loop is for testing
            foreach (char c in s) 
            {
                Debug.Log($"{c} = {(int)c}");
            }

            if (!IsTheStringHasAnyArabicChar(s)) 
                stringBuilder.Append(s.Reverse());
            else
                stringBuilder.Append(s);


            stringBuilder.Append(IsTheStringHasAnyArabicChar(s) ? s: s.Reverse());

        }
    }

    // Range of arabic chars from 1570 to 1610
    private bool IsTheStringHasAnyArabicChar(string word) 
    {
        for (int i = 0; i < word.Length; i++) 
        {
            if ((int)word[i] >= 1570 && (int)word[i] <= 1610)
                return true;
        }
        return false;
    }

}
