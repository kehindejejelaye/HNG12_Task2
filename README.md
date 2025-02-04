# Number Classification API

This is an API that accepts a number and returns interesting mathematical properties about it, along with a fun fact. The API can classify numbers as Armstrong numbers, odd/even, perfect numbers, and provides additional details about them.

## Requirements

- .NET 6 or higher
- Visual Studio or Visual Studio Code (for development)


## API Endpoint

**GET** `https://<your-url>/api/classify-number?number=<number>`

### Query Parameter

- `number`: The number to classify (required). Must be a valid integer.

### Response Format (200 OK)

```json
{
    "number": 371,
    "is_prime": false,
    "is_perfect": false,
    "properties": ["armstrong", "odd"],
    "digit_sum": 11,
    "fun_fact": "371 is an Armstrong number because 3^3 + 7^3 + 1^3 = 371"
}
```

```json
{
    "number": "string",
    "error": "error message"
}
```