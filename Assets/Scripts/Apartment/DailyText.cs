using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DailyTextObject", order = 1)]
public class DailyText : ScriptableObject
{
    [TextArea(1, 2)]
    public List<string> letterSender;
    [TextArea(1, 15)]
    public List<string> letters;
    [TextArea(1, 15)]
    public List<string> emails;

    //maybe add letter sprite art later?

}
