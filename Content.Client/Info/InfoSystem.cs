using Content.Shared.Info;
using Robust.Shared.ContentPack;
using Robust.Shared.Localization;
using Robust.Shared.Log;

namespace Content.Client.Info;

public sealed class InfoSystem : EntitySystem
{
    public RulesMessage Rules = new RulesMessage("Правила сервера Classic Station (MRP)", "");
    [Dependency] private readonly RulesManager _rules = default!;
    [Dependency] private readonly IResourceManager _res = default!;

    public override void Initialize()
    {
        base.Initialize();
        try
        {
            var title = Loc.GetString("ui-rules-header");
            var text = _res.ContentFileReadAllText("/ServerInfo/Rules.txt");
            Rules = new RulesMessage(title, text);
        }
        catch (Exception)
        {
            // Fallback if resource isn't loaded yet
        }

        SubscribeNetworkEvent<RulesMessage>(OnRulesReceived);
        Logger.DebugS("info", "Requested server info.");
        RaiseNetworkEvent(new RequestRulesMessage());
    }

    public void RequestRules()
    {
        RaiseNetworkEvent(new RequestRulesMessage());
    }

    private void OnRulesReceived(RulesMessage message, EntitySessionEventArgs eventArgs)
    {
        Logger.DebugS("info", "Received server rules.");
        Rules = message;
        _rules.UpdateRules();
    }
}
