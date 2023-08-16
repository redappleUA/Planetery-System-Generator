using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorService
{
    public static Color StarRandomColor()
    {
        List<Color> colors = new();
        string[] hexs = { "#f06000", "#db8e00", "bf0000", "00bc85", "7ad0e7"};

        foreach (var hex in hexs)
        {
            ColorUtility.TryParseHtmlString(hex, out Color color);
            colors.Add(color);
        }
        return colors[Random.Range(0, colors.Count)];
    }
    public static Color PlanetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return color;
    }
}
