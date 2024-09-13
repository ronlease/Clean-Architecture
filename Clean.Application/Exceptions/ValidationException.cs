// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

using FluentValidation.Results;

namespace Clean.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IList<string> Errors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            Errors = [];

            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
