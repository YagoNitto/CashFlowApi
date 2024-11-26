using System.Text.RegularExpressions;
using CashFlow.Exception;
using FluentValidation;
using FluentValidation.Validators;

namespace CashFlow.Application.UseCases.Users;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ErrorMessageKey = "ErrorMessage";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ErrorMessageKey}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (UpperCaseLetterRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        if (LowerCaseLetterRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        if (NumbersRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        if (SpecialCaractersRegex().IsMatch(password) == false)
        {
            context.MessageFormatter.AppendArgument(ErrorMessageKey, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }
        
        return true;
    }

    public override string Name => "PasswordValidator";

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseLetterRegex();
    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowerCaseLetterRegex();
    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex NumbersRegex();
    [GeneratedRegex(@"[\!\@\#\$\%\&\*\(\)\.\?\<\>]+")]
    private static partial Regex SpecialCaractersRegex();
}