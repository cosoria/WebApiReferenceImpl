using System;
using System.Reflection;

namespace WebApiReferenceImpl.Core.Messaging
{
    public class WeakFunc<TResult>
    {
        private Func<TResult> _staticFunc;

        protected MethodInfo Method { get; set; }
        protected WeakReference FuncReference { get; set; }
        protected WeakReference Reference { get; set; }

        public bool IsStatic { get { return _staticFunc != null; } }
        
        public virtual string MethodName
        {
            get
            {
                if (_staticFunc != null)
                {
                    return _staticFunc.Method.Name;
                }

                return Method.Name;
            }
        }
        
        protected WeakFunc()
        {
        }
        
        public WeakFunc(Func<TResult> func) : this(func.Target, func)
        {
        }
        
        public WeakFunc(object target, Func<TResult> func)
        {
            if (func.Method.IsStatic)
            {
                _staticFunc = func;

                if (target != null)
                {
                    // Keep a reference to the target to control the
                    // WeakAction's lifetime.
                    Reference = new WeakReference(target);
                }

                return;
            }

            Method = func.Method;
            FuncReference = new WeakReference(func.Target);
            Reference = new WeakReference(target);
        }

        public virtual bool IsAlive
        {
            get
            {
                if (_staticFunc == null && Reference == null)
                {
                    return false;
                }

                if (_staticFunc != null)
                {
                    if (Reference != null)
                    {
                        return Reference.IsAlive;
                    }

                    return true;
                }

                return Reference.IsAlive;
            }
        }
        
        public object Target
        {
            get
            {
                if (Reference == null)
                {
                    return null;
                }

                return Reference.Target;
            }
        }
        
        protected object FuncTarget
        {
            get
            {
                if (FuncReference == null)
                {
                    return null;
                }

                return FuncReference.Target;
            }
        }
        
        public TResult Execute()
        {
            if (_staticFunc != null)
            {
                return _staticFunc();
            }

            if (IsAlive)
            {
                if (Method != null
                    && FuncReference != null)
                {
                    return (TResult)Method.Invoke(FuncTarget, null);
                }
            }

            return default(TResult);
        }

        public void MarkForDeletion()
        {
            Reference = null;
            FuncReference = null;
            Method = null;
            _staticFunc = null;
        }
    }
}