//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class AnimParamTriggerEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IAnimParamTriggerListener> _listenerBuffer;

    public AnimParamTriggerEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IAnimParamTriggerListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.AnimParamTrigger)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasAnimParamTrigger && entity.hasAnimParamTriggerListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.animParamTrigger;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.animParamTriggerListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnAnimParamTrigger(e, component.name);
            }
        }
    }
}