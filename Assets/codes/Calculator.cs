using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TMP_InputField inputA;
    public TMP_InputField inputB;
    public TMP_Dropdown operationDropdown;
    public TMP_Text resultText;

    float GetNumber(TMP_InputField input)
    {
        float.TryParse(input.text, out float number);
        return number;
    }

    long Factorial(int n)
    {
        if (n < 0) return -1;
        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public void Calculate()
    {
        float a = GetNumber(inputA);
        float b = GetNumber(inputB);
        string result;

        switch (operationDropdown.value)
        {
            case 0: // +
                result = $"{a + b}";
                break;
            case 1: // -
                result = $"{a - b}";
                break;
            case 2: // ×
                result = $"{a * b}";
                break;
            case 3: // ÷
                result = (b != 0) ? $"{a / b}" : "Dalyba iš nulio negalima!";
                break;
            case 4: // √a
                result = (a >= 0) ? $"√{a} = {Mathf.Sqrt(a)}" : "Negalima šaknies iš neigiamo!";
                break;
            case 5: // a^b
                result = $"{a}^{b} = {Mathf.Pow(a, b)}";
                break;
            case 6: // log10(a)
                result = (a > 0) ? $"log({a}) = {Mathf.Log10(a)}" : "log galima tik su teigiamais!";
                break;
            case 7: // ln(a)
                result = (a > 0) ? $"ln({a}) = {Mathf.Log(a)}" : "ln galima tik su teigiamais!";
                break;
            case 8: // |a|
                result = $"|{a}| = {Mathf.Abs(a)}";
                break;
            case 9: // a % b
                result = $"{a} % {b} = {a % b}";
                break;
            case 10: // a!
                result = (a >= 0 && a == Mathf.Floor(a)) ? $"{a}! = {Factorial((int)a)}" : "Faktorialas tik sveikiems ≥ 0!";
                break;
            case 11: // 1/a
                result = (a != 0) ? $"1/{a} = {1 / a}" : "Negalima dalinti iš nulio!";
                break;
            default:
                result = "Nežinoma operacija";
                break;
        }

        resultText.text = result;
    }
}
