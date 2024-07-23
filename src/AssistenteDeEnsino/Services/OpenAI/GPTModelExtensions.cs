namespace AssistenteDeEnsino.Services.OpenAI;

public static class GPTModelExtensions
{
    public static string ToApiModel(this GPTModel model)
    {
        return model switch
        {
            GPTModel.Gpt3_5Turbo => "gpt-3.5-turbo",
            GPTModel.Gpt4 => "gpt-4",
            GPTModel.Gpt4o => "gpt-4o",
            _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
        };
    }
}