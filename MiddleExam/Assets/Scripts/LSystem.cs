using System.Collections.Generic;

using UnityEngine;

public struct TransformInfo
{
    public Vector3 Position;
    public Quaternion Rotation;
}

public class LSystem : MonoBehaviour
{
    [SerializeField] private GameObject _leep;

    [SerializeField] private GameObject _parent;

    private const string axiom = "X";
    private float angle = 25.0f;
    private string currentString = string.Empty;
    private readonly Dictionary<char, string> rules = new Dictionary<char, string>();
    private readonly Stack<TransformInfo> transformStack = new Stack<TransformInfo>();

    private float length = 0.05f;
    private bool isGenerating = false;

    private void Start()
    {
        rules.Add('X', "F+[[X]-X]-F[-FX]+X");
        rules.Add('F', "FF");
        currentString = axiom;
        for (int i = 0; i < 4; i++)
        {
            GenChar();
        }
        DrawChar();
    }

    private void GenChar()
    {
        string newString = string.Empty;
        char[] stringChar = currentString.ToCharArray();
        for (int i = 0; i < stringChar.Length; i++)
        {
            char currentChar = stringChar[i];
            if (rules.ContainsKey(currentChar))
            {
                newString += rules[currentChar];
            }
            else
            {
                newString += currentChar.ToString();
            }

            currentString = newString;
            Debug.Log(currentString);
        }
    }
    private void DrawChar()
    {
        char[] stringChar = currentString.ToCharArray();
        for (int i = 0; i < stringChar.Length; i++)
        {
            char currentChar = stringChar[i];

            if (currentChar == 'F')
            {
                // Vector3 initPosition = transform.position;
                transform.Translate(Vector3.forward * length);
                Instantiate(_leep, transform.position, Quaternion.identity, _parent.transform);
                // Debug.DrawLine(initPosition, transform.position, Color.green, 100.0f, false);
            }
            else if (currentChar == '+')
            {
                transform.Rotate(Vector3.up * angle);
            }
            else if (currentChar == '-')
            {
                transform.Rotate(Vector3.up * -angle);
            }
            else if (currentChar == '[')
            {
                TransformInfo ti = new TransformInfo
                {
                    Position = transform.position,
                    Rotation = transform.rotation
                };
                transformStack.Push(ti);
            }
            else if (currentChar == ']')
            {
                TransformInfo ti = transformStack.Pop();
                transform.position = ti.Position;
                transform.rotation = ti.Rotation;
            }
        }

        isGenerating = false;
    }
}
