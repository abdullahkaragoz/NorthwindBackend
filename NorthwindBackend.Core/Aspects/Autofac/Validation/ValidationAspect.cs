using Castle.DynamicProxy;
using FluentValidation;
using NorthwindBackend.Core.CrossCuttingConcerns.Validation;
using NorthwindBackend.Core.Utilities.Interceptors;
using NorthwindBackend.Core.Utilities.Messages;
using System;
using System.Linq;

namespace NorthwindBackend.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
       private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongType);
            }
            _validatorType = validatorType;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];  
            var entities = invocation.Arguments.Where(t=>t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

        }
    }
}
