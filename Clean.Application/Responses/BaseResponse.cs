// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Responses
{
    // TODO: Consider making abstract.
    public class BaseResponse(string message, bool success)
    {
        public IList<string> Errors { get; set; } = [];

        public string Message { get; set; } = message;

        public bool Success { get; set; } = success;

        public BaseResponse() : this(string.Empty) { }

        public BaseResponse(string message) : this(message, true) { }
    }
}
