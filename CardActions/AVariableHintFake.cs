﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CountJest.Wizbo;
public class AVariableHintFake : AVariableHint
{
    public int displayAmount;
    public string? iconName;

    public AVariableHintFake() : base()
    {
        hand = true;
    }
    public override Icon? GetIcon(State s)
    {
            Icon value = default(Icon);
            value.path = ModEntry.Instance.EHeat.Sprite;
            switch (iconName)
            {
                case "Highest Status":
                    value.path = ModEntry.Instance.HStat.Sprite;
                    break;
                case "Sum Highest Status":
                    value.path = ModEntry.Instance.SumHStat.Sprite;
                    break;
                case "Exhausted Cards":
                    value.path = ModEntry.Instance.ExhstCards.Sprite;
                    break;
                case "Enemy Heat":
                    value.path = ModEntry.Instance.EHeat.Sprite;
                    break;
                default: return value;
            }
            return value;
    }
    public override List<Tooltip> GetTooltips(State s)
    {
        Spr iconTT = ModEntry.Instance.HStat.Sprite;
        switch (iconName)
        {
            case "Highest Status":
            iconTT = ModEntry.Instance.HStat.Sprite;
                break;
            case "Sum Highest Status":
            iconTT = ModEntry.Instance.SumHStat.Sprite;
                break;
            case "Exhausted Cards":
            iconTT = ModEntry.Instance.ExhstCards.Sprite;
                break;
            case "Enemy Heat":
            iconTT = ModEntry.Instance.EHeat.Sprite;
                break;
        }

        var resultTT = new List<Tooltip>()
        {
            new CustomTTGlossary(
                CustomTTGlossary.GlossaryType.actionMisc,
                () => iconTT,
                () => ModEntry.Instance.Localizations.Localize(["Action", $"{iconName}", "name"]),
                () => ModEntry.Instance.Localizations.Localize(["Action", $"{iconName}", "description"]),
                key: $"{ModEntry.Instance.Package.Manifest.UniqueName}::Action{iconName}"
            )
        };
        return resultTT;
    }

}