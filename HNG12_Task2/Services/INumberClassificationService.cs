using HNG12_Task2.DTOs;

namespace HNG12_Task2.Services;

public interface INumberClassificationService
{
    Task<NumberClassificationResponse> ClassifyNumberAsync(int number);
}
