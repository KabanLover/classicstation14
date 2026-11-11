using Content.Shared.Examine;
using Robust.Shared.Utility;

namespace Content.Shared.Construction.Steps
{
    public abstract class ArbitraryInsertConstructionGraphStep : EntityInsertConstructionGraphStep
    {
        [DataField("name")] private string _name = string.Empty;

        public string Name =>
            Loc.TryGetString(_name, out var loc) ? loc :
            Loc.TryGetString($"construction-step-{_name.ToLowerInvariant().Replace(' ', '-')}", out var stepLoc) ? stepLoc : _name;

        [DataField("icon")] public SpriteSpecifier? Icon { get; private set; }

        public override void DoExamine(ExaminedEvent examinedEvent)
        {
            if (string.IsNullOrEmpty(Name))
                return;

            examinedEvent.Message.AddMarkup(Loc.GetString("construction-insert-arbitrary-entity", ("stepName", Name)));
        }

        public override ConstructionGuideEntry GenerateGuideEntry()
        {
            return new ConstructionGuideEntry
            {
                Localization = "construction-presenter-arbitrary-step",
                Arguments = new (string, object)[]{("name", Name)},
                Icon = Icon,
            };
        }
    }
}
