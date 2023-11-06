namespace Services.Common.Domain;

public record ImageUrl
{
    private const string ImageUrlPattern = @"^(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)$";

    public string Value { get; private set; }

    private ImageUrl(string value) => Value = value;


    public static ImageUrl Create(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            throw new ArgumentException("Image url cannot be empty", nameof(imageUrl));
        }

        imageUrl = imageUrl.Trim();

        if (!IsImageUrl(imageUrl))
        {
            throw new ArgumentException("Image url is invalid", nameof(imageUrl));
        }

        return new ImageUrl(imageUrl);
    }

    public static bool IsImageUrl(string imageUrl) => Regex.IsMatch(imageUrl, ImageUrlPattern);


    public static implicit operator string(ImageUrl imageUrl) => imageUrl.Value;
}