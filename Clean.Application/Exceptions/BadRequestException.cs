// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Exceptions
{
    public class BadRequestException(string message) : Exception(message)
    {
    }
}
