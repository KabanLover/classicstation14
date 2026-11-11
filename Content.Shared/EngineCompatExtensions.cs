using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Robust.Shared.Audio;
using Robust.Shared.Console;
using Robust.Shared.Containers;
using Robust.Shared.ContentPack;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Maths;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Components;
using Robust.Shared.Physics.Systems;
using Robust.Shared.Player;
using Robust.Shared.Players;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;

namespace Robust.Shared.GameObjects
{
    public static class EngineCompatExtensions
    {
        public static bool MoveNext<TComp1>(
            this ref EntityQueryEnumerator<TComp1> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1)
            where TComp1 : Component
        {
            if (enumerator.MoveNext(out comp1))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1, TComp2>(
            this ref EntityQueryEnumerator<TComp1, TComp2> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1,
            [NotNullWhen(true)] out TComp2? comp2)
            where TComp1 : Component
            where TComp2 : Component
        {
            if (enumerator.MoveNext(out comp1, out comp2))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1, TComp2, TComp3>(
            this ref EntityQueryEnumerator<TComp1, TComp2, TComp3> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1,
            [NotNullWhen(true)] out TComp2? comp2,
            [NotNullWhen(true)] out TComp3? comp3)
            where TComp1 : Component
            where TComp2 : Component
            where TComp3 : Component
        {
            if (enumerator.MoveNext(out comp1, out comp2, out comp3))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1, TComp2, TComp3, TComp4>(
            this ref EntityQueryEnumerator<TComp1, TComp2, TComp3, TComp4> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1,
            [NotNullWhen(true)] out TComp2? comp2,
            [NotNullWhen(true)] out TComp3? comp3,
            [NotNullWhen(true)] out TComp4? comp4)
            where TComp1 : Component
            where TComp2 : Component
            where TComp3 : Component
            where TComp4 : Component
        {
            if (enumerator.MoveNext(out comp1, out comp2, out comp3, out comp4))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1>(
            this ref AllEntityQueryEnumerator<TComp1> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1)
            where TComp1 : Component
        {
            if (enumerator.MoveNext(out comp1))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1, TComp2>(
            this ref AllEntityQueryEnumerator<TComp1, TComp2> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1,
            [NotNullWhen(true)] out TComp2? comp2)
            where TComp1 : Component
            where TComp2 : Component
        {
            if (enumerator.MoveNext(out comp1, out comp2))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1, TComp2, TComp3>(
            this ref AllEntityQueryEnumerator<TComp1, TComp2, TComp3> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1,
            [NotNullWhen(true)] out TComp2? comp2,
            [NotNullWhen(true)] out TComp3? comp3)
            where TComp1 : Component
            where TComp2 : Component
            where TComp3 : Component
        {
            if (enumerator.MoveNext(out comp1, out comp2, out comp3))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static bool MoveNext<TComp1, TComp2, TComp3, TComp4>(
            this ref AllEntityQueryEnumerator<TComp1, TComp2, TComp3, TComp4> enumerator,
            out EntityUid uid,
            [NotNullWhen(true)] out TComp1? comp1,
            [NotNullWhen(true)] out TComp2? comp2,
            [NotNullWhen(true)] out TComp3? comp3,
            [NotNullWhen(true)] out TComp4? comp4)
            where TComp1 : Component
            where TComp2 : Component
            where TComp3 : Component
            where TComp4 : Component
        {
            if (enumerator.MoveNext(out comp1, out comp2, out comp3, out comp4))
            {
                uid = comp1.Owner;
                return true;
            }

            uid = default;
            return false;
        }

        public static MapCoordinates ToMap(this EntityCoordinates coords, IEntityManager entMan, SharedTransformSystem transformSystem)
            => coords.ToMap(entMan);

        public static Vector2 ToMapPos(this EntityCoordinates coords, IEntityManager entMan, SharedTransformSystem transformSystem)
            => coords.ToMapPos(entMan);

        public static bool InRange(this EntityCoordinates coords, IEntityManager entMan, SharedTransformSystem transformSystem, EntityCoordinates other, float range)
            => coords.InRange(entMan, other, range);

        public static bool AnchorEntity(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform, EntityUid gridUid, MapGridComponent grid, Vector2i tileIndices)
            => sys.AnchorEntity(xform, grid, tileIndices);

        public static bool AnchorEntity(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform, MapGridComponent grid, Vector2i tileIndices)
            => sys.AnchorEntity(xform, grid, tileIndices);

        public static bool AnchorEntity(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform, MapGridComponent grid)
            => sys.AnchorEntity(xform, grid);

        public static bool AnchorEntity(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform)
            => sys.AnchorEntity(xform);

        public static void Unanchor(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform, bool setPhysics = true)
            => sys.Unanchor(xform, setPhysics);

        public static void SetCoordinates(
            this SharedTransformSystem sys,
            EntityUid uid,
            TransformComponent xform,
            EntityCoordinates value,
            Angle? rotation = null,
            bool unanchor = true,
            TransformComponent? newParent = null,
            TransformComponent? oldParent = null)
            => sys.SetCoordinates(xform, value, rotation, unanchor, newParent, oldParent);

        public static void SetParent(
            this SharedTransformSystem sys,
            EntityUid uid,
            TransformComponent xform,
            EntityUid parent,
            TransformComponent? parentXform = null)
            => sys.SetParent(xform, parent, parentXform);

        public static void SetParent(
            this SharedTransformSystem sys,
            EntityUid uid,
            TransformComponent xform,
            EntityUid parent,
            EntityQuery<TransformComponent> xformQuery,
            TransformComponent? parentXform = null)
            => sys.SetParent(xform, parent, xformQuery, parentXform);

        public static void AttachToGridOrMap(this SharedTransformSystem sys, EntityUid uid, TransformComponent? xform = null)
        {
            xform ??= IoCManager.Resolve<IEntityManager>().GetComponent<TransformComponent>(uid);
            xform.AttachToGridOrMap();
        }

        public static void AttachToGridOrMap(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform, EntityQuery<TransformComponent> query)
        {
            xform.AttachToGridOrMap();
        }

        public static void DetachParentToNull(this SharedTransformSystem sys, EntityUid uid, TransformComponent xform)
            => sys.DetachParentToNull(xform);

        public static void DetachParentToNull(
            this SharedTransformSystem sys,
            EntityUid uid,
            TransformComponent xform,
            EntityQuery<TransformComponent> xformQuery,
            EntityQuery<MetaDataComponent> metaQuery,
            TransformComponent? oldXform = null)
            => sys.DetachParentToNull(xform, xformQuery, metaQuery, oldXform);

        public static IPlayingAudioStream? PlayPredicted(
            this SharedAudioSystem audio,
            SoundSpecifier? sound,
            EntityCoordinates coordinates,
            EntityUid? user,
            AudioParams? audioParams = null)
            => audio.PlayPredicted(sound, user ?? coordinates.EntityId, user, audioParams);

        public static IPlayingAudioStream? PlayPvs(
            this SharedAudioSystem audio,
            SoundSpecifier? sound,
            EntityCoordinates coordinates,
            AudioParams? audioParams = null)
        {
            if (sound == null)
                return null;
            return audio.Play(sound, Filter.Pvs(coordinates, entityMan: IoCManager.Resolve<IEntityManager>()), coordinates, true, audioParams);
        }

        public static void ApplyTorque(
            this SharedPhysicsSystem sys,
            EntityUid uid,
            float torque,
            FixturesComponent? manager = null,
            PhysicsComponent? body = null)
        {
            var entMan = IoCManager.Resolve<IEntityManager>();
            if (body == null && !entMan.TryGetComponent(uid, out body))
                return;
            if ((body.BodyType & (BodyType.Dynamic | BodyType.KinematicController)) == 0x0 || !sys.WakeBody(uid, manager: manager, body: body))
                return;
            body.Torque += torque;
            entMan.Dirty(body);
        }
    }
}

namespace Robust.Shared.Maths
{
    public struct Box2iEdgeEnumerator
    {
        private readonly bool _corners;
        private readonly Box2i _box;
        private readonly int _offset;
        private int _x;
        private int _y;

        public Box2iEdgeEnumerator(Box2i box, bool corners, int offset = 1)
        {
            _box = box;
            _corners = corners;
            _x = _box.Left - offset;
            _y = _box.Bottom - offset;
            _offset = offset;
        }

        public bool MoveNext(out Vector2i index)
        {
            for (var x = _x; x < _box.Right + _offset; x++)
            {
                for (var y = _y; y < _box.Top + _offset; y++)
                {
                    if (x != _box.Left - _offset &&
                        x != _box.Right + (_offset - 1) &&
                        y != _box.Bottom - _offset &&
                        y != _box.Top + (_offset - 1))
                    {
                        continue;
                    }

                    if (!_corners &&
                        (x == _box.Left - _offset && (y == _box.Bottom - _offset || y == _box.Top + (_offset - 1)) ||
                        x == _box.Right && (y == _box.Bottom - _offset || y == _box.Top + (_offset - 1))))
                    {
                        continue;
                    }

                    _x = x;
                    _y = y + 1;

                    if (_y == _box.Top + _offset)
                    {
                        _x++;
                        _y = _box.Bottom - _offset;
                    }

                    index = new Vector2i(x, y);
                    return true;
                }
            }

            index = default;
            return false;
        }
    }
}

namespace Content.Shared
{
    public static class ContentCompletionHelper
    {
        public static IEnumerable<CompletionOption> Booleans => Robust.Shared.Console.CompletionHelper.Booleans;

        public static IEnumerable<CompletionOption> ContentFilePath(string arg, IResourceManager? res = null)
        {
            res ??= IoCManager.Resolve<IResourceManager>();
            return Robust.Shared.Console.CompletionHelper.ContentFilePath(arg, res);
        }

        public static IEnumerable<CompletionOption> UserFilePath(string arg, IWritableDirProvider provider)
            => Robust.Shared.Console.CompletionHelper.UserFilePath(arg, provider);

        public static IEnumerable<CompletionOption> PrototypeIDs<T>(bool sorted = true, IPrototypeManager? proto = null)
            where T : class, IPrototype
            => Robust.Shared.Console.CompletionHelper.PrototypeIDs<T>(sorted, proto);

        public static IEnumerable<CompletionOption> SessionNames(bool sorted = true, ISharedPlayerManager? players = null)
            => Robust.Shared.Console.CompletionHelper.SessionNames(sorted, players);

        public static IEnumerable<CompletionOption> MapIds(IEntityManager? entManager = null)
        {
            entManager ??= IoCManager.Resolve<IEntityManager>();
            return entManager.EntityQuery<MapComponent>(true).Select(o => new CompletionOption(o.WorldMap.ToString()));
        }

        public static IEnumerable<CompletionOption> MapUids(IEntityManager? entManager = null)
        {
            entManager ??= IoCManager.Resolve<IEntityManager>();
            var query = entManager.AllEntityQueryEnumerator<MapComponent>();
            while (query.MoveNext(out var comp))
            {
                yield return new CompletionOption(comp.Owner.ToString());
            }
        }

        public static IEnumerable<CompletionOption> EntityUids(string text, IEntityManager? entManager = null)
        {
            entManager ??= IoCManager.Resolve<IEntityManager>();
            foreach (var ent in entManager.GetEntities())
            {
                var entString = ent.ToString();
                if (!entString.StartsWith(text))
                    continue;
                yield return new CompletionOption(entString);
            }
        }

        public static IEnumerable<CompletionOption> Components<T>(string text, IEntityManager? entManager = null) where T : Component
        {
            entManager ??= IoCManager.Resolve<IEntityManager>();
            var query = entManager.AllEntityQueryEnumerator<T>();
            while (query.MoveNext(out var comp))
            {
                var uidStr = comp.Owner.ToString();
                if (!uidStr.StartsWith(text))
                    continue;
                yield return new CompletionOption(uidStr);
            }
        }
    }
}

namespace Robust.Shared.Containers
{
    public static class ContainerCompatExtensions
    {
        public static List<EntityUid> EmptyContainer(
            this SharedContainerSystem sys,
            IContainer container,
            bool force = false,
            EntityCoordinates? moveTo = null,
            bool reparent = true,
            MetaDataComponent? meta = null)
        {
            var list = new List<EntityUid>(container.ContainedEntities);
            sys.EmptyContainer(container, force, moveTo, reparent, (IEntityManager?) null);
            return list;
        }
    }
}

namespace Robust.Shared.IoC
{
    public static class DynamicTypeFactoryCompatExtensions
    {
        public static object CreateInstance(this IDynamicTypeFactory factory, Type type, object[] args, bool inject)
            => factory.CreateInstance(type, args);
    }
}

namespace Robust.Shared.Localization
{
    public static class LocalizationCompatExtensions
    {
        public static void SetFallbackCluture(this ILocalizationManager loc, CultureInfo culture)
        {
        }
    }
}

namespace Robust.Shared.Random
{
    public static class RandomCompatExtensions
    {
        public static bool Prob(this System.Random random, float chance)
            => random.NextDouble() < chance;

        public static bool Prob(this System.Random random, double chance)
            => random.NextDouble() < chance;

        public static bool Prob(this IRobustRandom random, double chance)
            => random.Prob((float) chance);

        public static void Shuffle<T>(this IRobustRandom rng, Robust.Shared.Collections.ValueList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n -= 1;
                var k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static void Shuffle<T>(this System.Random rng, IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n -= 1;
                var k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}

namespace Robust.Shared.GameObjects
{
    [RegisterComponent, Robust.Shared.GameStates.NetworkedComponent]
    public sealed class PlacementReplacementComponent : Component
    {
        [Robust.Shared.Serialization.Manager.Attributes.DataField("key")]
        public string Key = "";
    }

    [RegisterComponent, Robust.Shared.GameStates.NetworkedComponent]
    public sealed class SyncSpriteComponent : Component
    {
    }
}

namespace Robust.Client.UserInterface.RichText
{
    [Robust.Shared.Prototypes.Prototype("font")]
    public sealed class FontPrototype : Robust.Shared.Prototypes.IPrototype
    {
        [Robust.Shared.Prototypes.IdDataField]
        public string ID { get; } = default!;

        [Robust.Shared.Serialization.Manager.Attributes.DataField("path", required: true)]
        public Robust.Shared.Utility.ResourcePath Path { get; } = default!;
    }
}

namespace Robust.Shared.Serialization.TypeSerializers.Implementations
{
    using System.Globalization;
    using Robust.Shared.IoC;
    using Robust.Shared.Maths;
    using Robust.Shared.Serialization.Manager;
    using Robust.Shared.Serialization.Manager.Attributes;
    using Robust.Shared.Serialization.Markdown;
    using Robust.Shared.Serialization.Markdown.Validation;
    using Robust.Shared.Serialization.Markdown.Value;
    using Robust.Shared.Serialization.TypeSerializers.Interfaces;

    [TypeSerializer]
    public sealed class Box2iSerializer : ITypeSerializer<Box2i, ValueDataNode>, ITypeCopyCreator<Box2i>
    {
        public Box2i Read(ISerializationManager serializationManager, ValueDataNode node, IDependencyCollection dependencies,
            SerializationHookContext hookCtx, ISerializationContext? context = null, ISerializationManager.InstantiationDelegate<Box2i>? instanceProvider = null)
        {
            var args = node.Value.Split(',');
            if (args.Length != 4)
                throw new InvalidMappingException($"Could not parse {nameof(Box2i)}: '{node.Value}'");

            var l = int.Parse(args[0], CultureInfo.InvariantCulture);
            var b = int.Parse(args[1], CultureInfo.InvariantCulture);
            var r = int.Parse(args[2], CultureInfo.InvariantCulture);
            var t = int.Parse(args[3], CultureInfo.InvariantCulture);

            return new Box2i(l, b, r, t);
        }

        public DataNode Write(ISerializationManager serializationManager, Box2i value, IDependencyCollection dependencies,
            bool alwaysWrite = false, ISerializationContext? context = null)
        {
            var nodeValue =
                $"{value.Left.ToString(CultureInfo.InvariantCulture)}," +
                $"{value.Bottom.ToString(CultureInfo.InvariantCulture)}," +
                $"{value.Right.ToString(CultureInfo.InvariantCulture)}," +
                $"{value.Top.ToString(CultureInfo.InvariantCulture)}";

            return new ValueDataNode(nodeValue);
        }

        public ValidationNode Validate(ISerializationManager serializationManager, ValueDataNode node,
            IDependencyCollection dependencies, ISerializationContext? context = null)
        {
            var args = node.Value.Split(',');
            if (args.Length != 4)
                return new ErrorNode(node, "Invalid amount of args for Box2i.");

            return int.TryParse(args[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out _) &&
                   int.TryParse(args[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out _) &&
                   int.TryParse(args[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out _) &&
                   int.TryParse(args[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out _)
                ? new ValidatedValueNode(node)
                : new ErrorNode(node, "Failed parsing values of Box2i.");
        }

        public Box2i CreateCopy(ISerializationManager serializationManager, Box2i source, SerializationHookContext hookCtx,
            ISerializationContext? context = null)
        {
            return new Box2i(source.Left, source.Bottom, source.Right, source.Top);
        }
    }
}
