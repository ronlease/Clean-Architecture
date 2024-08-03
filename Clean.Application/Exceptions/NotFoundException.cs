// Copyright 2024 Ron Lease
// SPDX - License - Identifier: Apache - 2.0

namespace Clean.Application.Exceptions
{
    public class NotFoundException(string name, object key) : Exception($"{name} ({key}) not found.")
    {
    }
}
