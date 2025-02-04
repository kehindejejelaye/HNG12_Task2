using System.Text.Json.Serialization;

namespace HNG12_Task2.DTOs;

public class NumberClassificationResponse
{
    [JsonPropertyName("number")]
    public int Number { get; set; }
    [JsonPropertyName("is_prime")]
    public bool IsPrime { get; set; }
    [JsonPropertyName("is_perfect")]
    public bool IsPerfect { get; set; }
    [JsonPropertyName("properties")]
    public List<string> Properties { get; set; }
    [JsonPropertyName("digit_sum")]
    public int DigitSum { get; set; }
    [JsonPropertyName("fun_fact")]
    public string FunFact { get; set; }
}
