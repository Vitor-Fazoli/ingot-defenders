using System;
using Godot;
using IngotDefenders.scripts.core;

namespace IngotDefenders.scenes.core.components
{
    public partial class HitboxComponent : Area2D
    {
        public Attack Attack;

        [Export]
        public bool IsProjectile { get; private set; } = false;
    }
}

