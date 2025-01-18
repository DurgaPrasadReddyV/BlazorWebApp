﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAppStarter.Shared.Common
{
    public class HttpValidationProblemDetails : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HttpValidationProblemDetails"/>.
        /// </summary>
        public HttpValidationProblemDetails()
            : this(new Dictionary<string, string[]>(StringComparer.Ordinal))
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="HttpValidationProblemDetails"/> using the specified <paramref name="errors"/>.
        /// </summary>
        /// <param name="errors">The validation errors.</param>
        public HttpValidationProblemDetails(IDictionary<string, string[]> errors)
            : this((IEnumerable<KeyValuePair<string, string[]>>)errors)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="HttpValidationProblemDetails"/> using the specified <paramref name="errors"/>.
        /// </summary>
        /// <param name="errors">The validation errors.</param>
        public HttpValidationProblemDetails(IEnumerable<KeyValuePair<string, string[]>> errors)
            : this(new Dictionary<string, string[]>(errors ?? throw new ArgumentNullException(nameof(errors)), StringComparer.Ordinal))
        {
        }

        private HttpValidationProblemDetails(Dictionary<string, string[]> errors)
        {
            Title = "One or more validation errors occurred.";
            Errors = errors;
        }

        /// <summary>
        /// Gets the validation errors associated with this instance of <see cref="HttpValidationProblemDetails"/>.
        /// </summary>
        [JsonPropertyName("errors")]
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
    }
}