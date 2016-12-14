﻿using DotJEM.Json.Validation.Context;
using DotJEM.Json.Validation.Descriptive;
using Newtonsoft.Json.Linq;

namespace DotJEM.Json.Validation.Constraints.Types
{
    [JsonConstraintDescription("of type array")]
    public class OfTypeArrayJsonConstraint : JsonConstraint
    {
        public override bool Matches(IJsonValidationContext context, JToken token)
        {
            return token.Type == JTokenType.Array;
        }
    }
}