using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public static string convert(int[] t_input)
    {
        string resultString = null;
        for (int i = 0; i < t_input.Length; i++)
        {
            resultString += System.Convert.ToChar(t_input[i]);
        }

        return resultString;
    }
}
