﻿using System.Linq;
using DotJEM.Json.Validation.Context;
using DotJEM.Json.Validation.Descriptive;
using DotJEM.Json.Validation.Results;
using Newtonsoft.Json.Linq;

namespace DotJEM.Json.Validation.Constraints
{
    [JsonConstraintDescription("{Described}")]
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
        {
            return OptimizeAs<AndJsonConstraint>();
        }

        internal override AbstractResult DoMatch(JToken token, IJsonValidationContext context)
        {
            return Constraints.Aggregate((AbstractResult) null, (a, b) => a & b.DoMatch(token, context));
        }

        public override string ToString()
        {
            return "( " + string.Join(" AND ", Constraints.Select(c => c.Describe())) + " )";
        }
        
        // ReSharper disable UnusedMember.Local
        // Note: Used by description attribute
        private string Described => ToString();
        // ReSharper restore UnusedMember.Local
    }
}