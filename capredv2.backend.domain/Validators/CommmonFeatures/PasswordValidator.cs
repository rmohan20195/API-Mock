namespace capredv2.backend.domain.Validators.CommmonFeatures
{
    public class PasswordValidator
    {
        public static bool IsValid(string value) => !string.IsNullOrWhiteSpace(value);
    }
}
