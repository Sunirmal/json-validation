﻿using System;
using System.Collections.Generic;
using System.Linq;
using DotJEM.Json.Validation.Constraints.Common.Length;
using DotJEM.Json.Validation.Constraints.Generic;
using DotJEM.Json.Validation.Context;
using DotJEM.Json.Validation.Factories;
using Newtonsoft.Json.Linq;

namespace DotJEM.Json.Validation.Constraints.Common
{
    public static class CommonConstraintFactoryExtensions
    {
        public static CapturedConstraint Defined(this IBeConstraintFactory self) 
            => self.Capture(new IsDefinedConstraint());

        public static CapturedConstraint EqualTo(this IBeConstraintFactory self, object value)
            => self.Capture(new EqualToConstraint(value));

        public static CapturedConstraint In<T>(this IBeConstraintFactory self, IEnumerable<T> elements) 
            => self.Capture(new InConstraint<T>(elements));

        public static CapturedConstraint In<T>(this IBeConstraintFactory self, params T[] elements)
            => self.In(elements.AsEnumerable());

        public static CapturedConstraint Matching(this IGuardConstraintFactory self, Func<JToken, bool> constraintFunc, string explain)
            => self.Capture(new FunctionalConstraint((c, t) => constraintFunc(t), explain));

        public static CapturedConstraint Matching(this IGuardConstraintFactory self, Func<IJsonValidationContext, JToken, bool> constraintFunc, string explain) 
            => self.Capture(new FunctionalConstraint(constraintFunc, explain));

        public static CapturedConstraint Match(this IValidatorConstraintFactory self, Func<JToken, bool> constraintFunc, string explain) 
            => self.Capture(new FunctionalConstraint((c, t) => constraintFunc(t), explain));

        public static CapturedConstraint Match(this IValidatorConstraintFactory self, Func<IJsonValidationContext, JToken, bool> constraintFunc, string explain) 
            => self.Capture(new FunctionalConstraint(constraintFunc, explain));

        public static CapturedConstraint ExactLength(this IHaveConstraintFactory self, int length)
            => self.Capture(new ExactLengthConstraint(length));

        public static CapturedConstraint MinLength(this IHaveConstraintFactory self, int minLength)
            => self.Capture(new MinLengthConstraint(minLength));

        public static CapturedConstraint MaxLength(this IHaveConstraintFactory self, int maxLength)
            => self.Capture(new MaxLengthConstraint(maxLength));

        public static CapturedConstraint LengthBetween(this IHaveConstraintFactory self, int minLength, int maxLength)
            => self.Capture(new LengthConstraint(minLength, maxLength));
    }
}