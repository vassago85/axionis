namespace AxionisPos.Api.Services;

public interface IEffectiveMailgunProvider
{
    ValueTask<EffectiveMailgunOptions> GetAsync(CancellationToken ct = default);
}
