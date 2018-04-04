using System.Collections.Generic;

public class InputState  {

    public List<KeyValuePair<string, bool>> Buttons;
    public List<KeyValuePair<string, float>> Axes;

    public static InputState GetBlankState()
    {
        InputState IS = new InputState();
        IS.Buttons = new List<KeyValuePair<string, bool>>();
        IS.Axes = new List<KeyValuePair<string, float>>(); 
        return IS;
    }

    public void AddButton(string command, bool value)
    {
        Buttons.Add(new KeyValuePair<string, bool>(command, value)); 
    }
    public void AddAxis(string command, float value)
    {
        Axes.Add(new KeyValuePair<string, float>(command, value)); 
    }

    public override string ToString()
    {
        string output = "InputState:\n";
        output += "Buttons: "; 
        foreach (KeyValuePair<string, bool> item in Buttons )
        {
            output += " [" + item.Key + "::" + item.Value + "]"; 
        }
        output += "Axes: ";
        foreach (KeyValuePair<string, float> item in Axes)
        {
            output += " [" + item.Key + "::" + item.Value + "]";
        }

        return output; 
    }

}
