﻿using System.Linq;
using DotJEM.Json.Validation.Context;
using DotJEM.Json.Validation.Descriptive;
using DotJEM.Json.Validation.Results;
using Newtonsoft.Json.Linq;

namespace DotJEM.Json.Validation.Constraints
{
    public sealed class AndJsonConstraint : CompositeJsonConstraint
    {
        public AndJsonConstraint()
        {
        }

        public AndJsonConstraint(params JsonConstraint[] constraints)
            : base(constraints)
        {
        }
        
        public override JsonConstraint Optimize()
            => OptimizeAs<AndJsonConstraint>();

        public override Result DoMatch(JToken token, IJsonValidationContext context)
            => Constraints.Aggregate((Result) null, (a, b) => a & b.DoMatch(token, context));

        public override string ToString() 
            => string.Join(" AND ", Constraints);
    }
}