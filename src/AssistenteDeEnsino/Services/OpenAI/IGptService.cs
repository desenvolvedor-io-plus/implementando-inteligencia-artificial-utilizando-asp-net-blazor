namespace AssistenteDeEnsino.Services.OpenAI
{
    public interface IGptService
    {
        Task<string> ProcessarPergunta(string pergunta, string transcript);
    }
}