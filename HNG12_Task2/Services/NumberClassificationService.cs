using HNG12_Task2.DTOs;

namespace HNG12_Task2.Services;

public class NumberClassificationService : INumberClassificationService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NumberClassificationService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<NumberClassificationResponse> ClassifyNumberAsync(int number)
    {
        var response = new NumberClassificationResponse
        {
            Number = number,
            IsPrime = IsPrime(number),
            IsPerfect = IsPerfect(number),
            Properties = GetProperties(number),
            DigitSum = CalculateDigitSum(number),
            FunFact = await GetFunFact(number)
        };

        return response;
    }

    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    private bool IsPerfect(int number)
    {
        if (number == 0) return false;

        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
                sum += i;
        }
        return sum == number;
    }

    private List<string> GetProperties(int number)
    {
        var properties = new List<string>();

        if (IsArmstrong(number))
            properties.Add("armstrong");

        if (number % 2 == 0)
            properties.Add("even");
        else
            properties.Add("odd");

        return properties;
    }

    private bool IsArmstrong(int number)
    {
        var digits = number.ToString().Select(d => int.Parse(d.ToString())).ToList();
        int sum = digits.Sum(d => (int)Math.Pow(d, digits.Count));
        return sum == number;
    }

    private int CalculateDigitSum(int number)
    {
        return number.ToString().Sum(digit => int.Parse(digit.ToString()));
    }

    private async Task<string> GetFunFact(int number)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://numbersapi.com/{number}/math");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return "No fun fact available";
    }
}
